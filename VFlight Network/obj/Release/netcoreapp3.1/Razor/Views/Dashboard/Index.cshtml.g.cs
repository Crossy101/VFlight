#pragma checksum "C:\Users\Callu\source\repos\VFlight Network\VFlight Network\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe884bbb4c6520b889686bd10623a8f5b0837fd3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Index), @"mvc.1.0.view", @"/Views/Dashboard/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Callu\source\repos\VFlight Network\VFlight Network\Views\_ViewImports.cshtml"
using VFlight_Network;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Callu\source\repos\VFlight Network\VFlight Network\Views\_ViewImports.cshtml"
using VFlight_Network.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe884bbb4c6520b889686bd10623a8f5b0837fd3", @"/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b9f177a946334425767e025aad0e6cae2081fc6", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Callu\source\repos\VFlight Network\VFlight Network\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- page-content -->
    <div aria-live=""polite"" aria-atomic=""true"" style=""position: absolute; right: 1%; top: 1%; min-width: 350px; z-index: 5"">

        <!-- Then put toasts within -->
        <div class=""toast"" role=""alert"" aria-live=""assertive"" aria-atomic=""true"" data-autohide=""true"" data-delay=""5000"">
            <div class=""toast-body"">
                <i class=""fa fa-user pr-2""></i>See? Just like this.
            </div>
        </div>

        <div class=""toast notification-success"" role=""alert"" aria-live=""assertive"" aria-atomic=""true"" data-autohide=""true"" data-delay=""5000"">
            <div class=""toast-body"">
                <i class=""fa fa-check pr-2""></i>Heads up, toasts will stack automatically
            </div>
        </div>

        <div class=""toast notification-info"" role=""alert"" aria-live=""assertive"" aria-atomic=""true"" data-autohide=""true"" data-delay=""5000"">
            <div class=""toast-body"">
                <i class=""fa fa-info pr-2""></i>Heads up, toasts will stack ");
            WriteLiteral(@"automatically
            </div>
        </div>

        <div class=""toast notification-warning"" role=""alert"" aria-live=""assertive"" aria-atomic=""true"" data-autohide=""true"" data-delay=""5000"">
            <div class=""toast-body"">
                <i class=""fa fa-exclamation pr-2""></i>Heads up, toasts will stack automatically
            </div>
        </div>

        <div class=""toast notification-fail"" role=""alert"" aria-live=""assertive"" aria-atomic=""true"" data-autohide=""true"" data-delay=""5000"">
            <div class=""toast-body"">
                <i class=""fa fa-globe pr-2""></i>Heads up, toasts will stack automatically
            </div>
        </div>
    </div>

    <section class=""my-2 py-2"">
        <div class=""row"">

            <!-- NOTICE -->
            <div class=""col-12"">
                <div class=""card text-white bg-danger"">
                    <div class=""card-body d-flex align-items-center"">
                        <span");
            BeginWriteAttribute("class", " class=\"", 2084, "\"", 2092, 0);
            EndWriteAttribute();
            WriteLiteral(@">YOUR MEMBERSHIP IS ABOUT TO EXPIRE IN 7 DAYS.</span>
                        <btn class='btn btn-sm btn-white ml-auto'>RENEW</btn>

                    </div>
                </div>
            </div>



            <!-- ACTIVE FLIGHTS -->
            <div class=""col-12 mt-3"">
                <div class=""card "" style=""background-color: #343434"">
                    <div class=""card-header text-white"">
                        ACTIVE FLIGHTS
                    </div>
                    <div class=""card-body p-0"" style=""background-color: #232323"">

                        <div class=""table-responsive"">
                            <table class=""table table-striped text-white table-borderless"">
                                <thead>
                                    <tr class=""text-white-50"">
                                        <th scope=""col"">#</th>
                                        <th scope=""col"">Airline</th>
                                        <th scope=""col"">Flight</");
            WriteLiteral(@"th>
                                        <th scope=""col"">Departure</th>
                                        <th scope=""col"">Arrival</th>
                                        <th scope=""col"">Aircraft</th>
                                        <th scope=""col"">Remarks</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <!-- FLIGHT DATA -->
                                    <tr>
                                        <th scope=""row"">1</th>
                                        <td>
                                            <img src=""https://upload.wikimedia.org/wikipedia/en/thumb/d/d7/American_Airlines_logo.svg/800px-American_Airlines_logo.svg.png"" style=""height: 15px"">
                                        </td>
                                        <td>BA294</td>
                                        <td>London</td>
                                        <td>W");
            WriteLiteral(@"ho cares</td>
                                        <td>Boeing 747-800</td>
                                        <td>Cruising</td>
                                    </tr>
                                    <tr>
                                        <th scope=""row"">1</th>
                                        <td>
                                            <img src=""https://upload.wikimedia.org/wikipedia/en/thumb/d/d7/American_Airlines_logo.svg/800px-American_Airlines_logo.svg.png"" style=""height: 15px"">
                                        </td>
                                        <td>BA294</td>
                                        <td>London</td>
                                        <td>Who cares</td>
                                        <td>Boeing 747-800</td>
                                        <td>Cruising</td>
                                    </tr>
                                    <tr>
                                        <th scope=""row"">1</th>
  ");
            WriteLiteral(@"                                      <td>
                                            <img src=""https://upload.wikimedia.org/wikipedia/en/thumb/d/d7/American_Airlines_logo.svg/800px-American_Airlines_logo.svg.png"" style=""height: 15px"">
                                        </td>
                                        <td>BA294</td>
                                        <td>London</td>
                                        <td>Who cares</td>
                                        <td>Boeing 747-800</td>
                                        <td>Cruising</td>
                                    </tr>
                                    <tr>
                                        <th scope=""row"">1</th>
                                        <td>
                                            <img src=""https://upload.wikimedia.org/wikipedia/en/thumb/d/d7/American_Airlines_logo.svg/800px-American_Airlines_logo.svg.png"" style=""height: 15px"">
                                        </td>
    ");
            WriteLiteral(@"                                    <td>BA294</td>
                                        <td>London</td>
                                        <td>Who cares</td>
                                        <td>Boeing 747-800</td>
                                        <td>Cruising</td>
                                    </tr>
                                    <tr>
                                        <th scope=""row"">1</th>
                                        <td>
                                            <img src=""https://upload.wikimedia.org/wikipedia/en/thumb/d/d7/American_Airlines_logo.svg/800px-American_Airlines_logo.svg.png"" style=""height: 15px"">
                                        </td>
                                        <td>BA294</td>
                                        <td>London</td>
                                        <td>Who cares</td>
                                        <td>Boeing 747-800</td>
                                        <td>Cruising</td");
            WriteLiteral(@">
                                    </tr>

                                </tbody>
                            </table>
                        </div>

                    </div>
                </div>
            </div>

            <!-- NEWS -->
            <div class=""col-12 col-md-6 mt-3"">
                <div class=""card text-white"" style=""background-color: #343434"">
                    <div class=""card-header"">
                        NEWS
                    </div>
                    <div class=""card-body p-0"">
                        <div class=""list-group"">
                            <!-------------------------------->
                            <a href=""#!"" class=""list-group-item list-group-item-action flex-column align-items-start clearfix"" style=""background-color: #232323"">

                                <div class=""d-flex justify-content-between mb-2"">
                                    <h5 class=""text-white font-weight-lighter m-0"">News about our community</h5>
 ");
            WriteLiteral(@"                                   <small class=""text-white-50 text-monospace"">3 days ago</small>
                                </div>

                                <p class=""mb-0 text-truncate text-white-50"">
                                    Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius this is a blandit.Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius this is a blandit.
                                </p>
                                <div class=""text-right"">
                                    <small class=""text-muted pt-2 font-italics text-monospace"">
                                        Published by
                                        <span class=""font-italic"">Maverick</span>
                                    </small>
                                </div>
                            </a>
                            <!-------------------------------->
                            <a href=""#!"" cla");
            WriteLiteral(@"ss=""list-group-item list-group-item-action flex-column align-items-start clearfix"" style=""background-color: #232323"">

                                <div class=""d-flex justify-content-between mb-2"">
                                    <h5 class=""text-white font-weight-lighter m-0"">News about our community</h5>
                                    <small class=""text-white-50 text-monospace"">3 days ago</small>
                                </div>

                                <p class=""mb-0 text-truncate text-white-50"">
                                    Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius this is a blandit.Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius this is a blandit.
                                </p>
                                <div class=""text-right"">
                                    <small class=""text-muted pt-2 font-italics text-monospace"">
                                        Publish");
            WriteLiteral(@"ed by
                                        <span class=""font-italic"">Maverick</span>
                                    </small>
                                </div>
                            </a>
                            <!-------------------------------->
                            <a href=""#!"" class=""list-group-item list-group-item-action flex-column align-items-start clearfix"" style=""background-color: #232323"">

                                <div class=""d-flex justify-content-between mb-2"">
                                    <h5 class=""text-white font-weight-lighter m-0"">News about our community</h5>
                                    <small class=""text-white-50 text-monospace"">3 days ago</small>
                                </div>

                                <p class=""mb-0 text-truncate text-white-50"">
                                    Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius this is a blandit.Donec id elit non mi porta ");
            WriteLiteral(@"gravida at eget metus. Maecenas sed diam eget risus varius this is a blandit.
                                </p>
                                <div class=""text-right"">
                                    <small class=""text-muted pt-2 font-italics text-monospace"">
                                        Published by
                                        <span class=""font-italic"">Maverick</span>
                                    </small>
                                </div>
                            </a>
                            <!-------------------------------->
                        </div>
                    </div>
                </div>
            </div>

            <!-- STATS -->
            <div class=""col-12 col-md-6 mt-3"">
                <div class=""card"">
                    <div class=""card-header"">
                        STATS
                    </div>
                    <div class=""card-body"">
                        STATS HERE

                    </d");
            WriteLiteral("iv>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n<!-- page-content -->\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591