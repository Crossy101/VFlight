using System;
using System.Collections.Generic;
using System.Text;
using VFlightNetwork.Data.Models.Notification;

namespace VFlightNetwork.Data.Models.Login
{
    public class LoginPageModel
    {
        public LoginDetails LoginDetails { get; set; }
        public RegisterDetails RegisterDetails { get; set; }
        public AlertNotification Notification { get; set; }
    }
}
