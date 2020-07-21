using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using VFlight_Network.Models.Identity;
using VFlightNetwork.Data.Models.Login;
using VFlightNetwork.Data.Models.Stats;
using VFlight_Network.Data;
using System.ComponentModel;
using System.Configuration;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Web;
using VFlightNetwork.Data.Models.Notification;
using VFlightNetwork.Data.Enums.Notification;

namespace VFlight_Network.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager { get; }
        private SignInManager<AppUser> _signInManager { get; }
        private ApplicationDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            LoginPageModel viewModel = new LoginPageModel
            {
                LoginDetails = new LoginDetails(),
                RegisterDetails = new RegisterDetails(),
                Notification = null
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginPageModel loginModel)
        {
            LoginDetails loginDetails = loginModel.LoginDetails;

            ViewBag.Message = "";
            try
            {
                if(string.IsNullOrEmpty(loginDetails.Username) || string.IsNullOrEmpty(loginDetails.Password))
                {
                    loginModel.Notification = new AlertNotification(NotificationType.Error, "Please type both a Username and Password");
                    return View("Index", loginModel);
                }

                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginDetails.Username, loginDetails.Password, loginDetails.StayLoggedIn, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (result.IsNotAllowed)
                {
                    loginModel.Notification = new AlertNotification(NotificationType.Error, "Please verify your email! (An email was sent to the attached account and must be verified before logging in.)");
                    return View("Index", loginModel);
                }
                else
                {
                    loginModel.Notification = new AlertNotification(NotificationType.Error, "Username or Password incorrect!");
                    return View("Index", loginModel);
                }
                
            }
            catch (Exception ex)
            {
                loginModel.Notification = new AlertNotification(NotificationType.Error, $"Contact Support: {ex.Message}");
                return View("Index", loginModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginPageModel loginModel)
        {
            RegisterDetails registerDetails = loginModel.RegisterDetails;

            try
            {
                AppUser user = await _userManager.FindByNameAsync(registerDetails.Username);
                if(user == null)
                {
                    user = new AppUser()
                    {
                        UserName = registerDetails.Username,
                        FirstName = registerDetails.FirstName,
                        LastName = registerDetails.LastName,
                        Email = registerDetails.Email,
                        DateOfBirth = registerDetails.DateOfBirth
                    };


                    var accountCreation = _userManager.CreateAsync(user, registerDetails.Password);

                    Task.WaitAll(accountCreation);
                    if(accountCreation.Result.Succeeded)
                    {
                        var accountStatsCreation = CreateAccountStats(user);
                        var emailConfirmation = SendEmailConfirmation(user);

                        Task.WaitAll(accountStatsCreation, emailConfirmation);
                        if (accountStatsCreation.Result && emailConfirmation.Result)
                        {
                            loginModel.Notification = new AlertNotification(NotificationType.Success, "User-Registration Complete! An email has been sent to your email please confirm the verification.");
                            return View("Index", loginModel);
                        }
                        //TODO: Add somekind of log just in-case the AccountStats somehow fail.
                        else
                        {
                            loginModel.Notification = new AlertNotification(NotificationType.Error, $"Failed to Create Account Relations: Please Contact Support!");
                            return View("Index", loginModel);
                        }
                    }
                    else
                    {
                        loginModel.Notification = new AlertNotification(NotificationType.Error, $"Failed to Create Account: Please Contact Support!");
                        return View("Index", loginModel);
                    }
                }
                else
                {
                    loginModel.Notification = new AlertNotification(NotificationType.Error, $"An account has already been registered with those details.");
                    return View("Index", loginModel);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return RedirectToAction("Index");
        }

        public async Task<bool> SendEmailConfirmation(AppUser user)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("VFlight", "noreply@vflight.co.uk"));
                message.To.Add(new MailboxAddress("Callum Cross", $"{user.Email}"));
                message.Subject = "VFlight Email Confirmation";

                string emailToken = HttpUtility.UrlEncode(await _userManager.GenerateEmailConfirmationTokenAsync(user));

                string link = $"https://vflight.co.uk/Account/EmailVerify?token={emailToken}&Id={user.Id}";
                message.Body = new TextPart("plain")
                {
                    Text = @"Click this link to complete your Email Verification: " + $"{link}"
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("mail.vflight.co.uk", 465, true);

                    // Note: only needed if the SMTP server requires authentication
                    string SMTPServer = "noreply@vflight.co.uk";
                    string SMTPPassword = "JGf;SVT}M7cM";
                    await client.AuthenticateAsync(SMTPServer, SMTPPassword);

                    await client.SendAsync(message);

                    await client.DisconnectAsync(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public async Task<bool> CreateAccountStats(AppUser user)
        {
            try
            {
                AccountStats accountStats = new AccountStats
                {
                    UserId = Guid.Parse(user.Id),
                    TotalPoints = 0,
                    TotalHours = 0,
                    TotalFlights = 0,
                    FavouriteRoute = Guid.Empty,
                    FavouriteAircraft = Guid.Empty,
                    LastRouteId = Guid.Empty,
                    LastAircraftId = Guid.Empty
                };

                var result = await _context.AccountStats.AddAsync(accountStats);
                if (result != null)
                {
                    int saveResult = await _context.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        public async Task<IActionResult> EmailVerify(string token, string Id)
        {
            try
            {
                //Create a view model to be returned to the user
                LoginPageModel viewModel = new LoginPageModel
                {
                    LoginDetails = new LoginDetails(),
                    RegisterDetails = new RegisterDetails(),
                    Notification = new AlertNotification()
                };

                AppUser user = await _userManager.FindByIdAsync(Id);
                if (user != null)
                {
                    if(user.EmailConfirmed)
                    {
                        viewModel.Notification.SetNotification(NotificationType.Error, "You have already confirmed your email!");
                        return View("Index", viewModel);
                    }

                    IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);

                    //TODO: Add a notification model to the dashboard model
                    if (result.Succeeded)
                    {
                        viewModel.Notification.SetNotification(NotificationType.Success, "Email Confirmation Success! You can now login.");
                        return View("Index", viewModel);
                    }
                    else
                    {
                        viewModel.Notification.SetNotification(NotificationType.Error, "Token Error: Please Contact Support!");
                        return View("Index", viewModel);
                    }
                }

                viewModel.Notification.SetNotification(NotificationType.Error, "Email Confirmation Failed: User doesn't exist!");
                return View("Index", viewModel);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                LoginPageModel failureViewModel = new LoginPageModel
                {
                    LoginDetails = new LoginDetails(),
                    RegisterDetails = new RegisterDetails(),
                    Notification = new AlertNotification(NotificationType.Error, "Email Confirmation Failed! Please contact support!")
                };
                return View("Index", failureViewModel);
            }
        }
    }
}