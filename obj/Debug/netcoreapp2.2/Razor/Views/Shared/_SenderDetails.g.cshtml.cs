#pragma checksum "F:\Project\Core Map\Graduation Core\Views\Shared\_SenderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b03d15f6f69cd32dea9cb4b0ed154f7c8c871a21"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SenderDetails), @"mvc.1.0.view", @"/Views/Shared/_SenderDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_SenderDetails.cshtml", typeof(AspNetCore.Views_Shared__SenderDetails))]
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
#line 1 "F:\Project\Core Map\Graduation Core\Views\_ViewImports.cshtml"
using Graduation_Core;

#line default
#line hidden
#line 2 "F:\Project\Core Map\Graduation Core\Views\_ViewImports.cshtml"
using Graduation_Core.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b03d15f6f69cd32dea9cb4b0ed154f7c8c871a21", @"/Views/Shared/_SenderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8b3662672c334380a63cfa8494ed8337b5d0c11", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SenderDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Graduation_Core.Models.SenderInfo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 66, true);
            WriteLiteral("<div class=\"alert alert-success mx-auto text-center\">\r\n    Sender ");
            EndContext();
            BeginContext(109, 11, false);
#line 3 "F:\Project\Core Map\Graduation Core\Views\Shared\_SenderDetails.cshtml"
      Write(Model.SName);

#line default
#line hidden
            EndContext();
            BeginContext(120, 142, true);
            WriteLiteral(" Info\r\n</div>\r\n    <table class=\"table table-striped\">\r\n        <tbody>\r\n            <tr>\r\n                <td>Name</td>\r\n                <td>");
            EndContext();
            BeginContext(263, 11, false);
#line 9 "F:\Project\Core Map\Graduation Core\Views\Shared\_SenderDetails.cshtml"
               Write(Model.SName);

#line default
#line hidden
            EndContext();
            BeginContext(274, 97, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Mobile</td>\r\n                <td>");
            EndContext();
            BeginContext(372, 13, false);
#line 13 "F:\Project\Core Map\Graduation Core\Views\Shared\_SenderDetails.cshtml"
               Write(Model.SMobile);

#line default
#line hidden
            EndContext();
            BeginContext(385, 96, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Email</td>\r\n                <td>");
            EndContext();
            BeginContext(482, 12, false);
#line 17 "F:\Project\Core Map\Graduation Core\Views\Shared\_SenderDetails.cshtml"
               Write(Model.SEmail);

#line default
#line hidden
            EndContext();
            BeginContext(494, 94, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>SSN</td>\r\n                <td>");
            EndContext();
            BeginContext(589, 10, false);
#line 21 "F:\Project\Core Map\Graduation Core\Views\Shared\_SenderDetails.cshtml"
               Write(Model.SSsn);

#line default
#line hidden
            EndContext();
            BeginContext(599, 98, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Address</td>\r\n                <td>");
            EndContext();
            BeginContext(698, 14, false);
#line 25 "F:\Project\Core Map\Graduation Core\Views\Shared\_SenderDetails.cshtml"
               Write(Model.SAddress);

#line default
#line hidden
            EndContext();
            BeginContext(712, 98, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Details</td>\r\n                <td>");
            EndContext();
            BeginContext(811, 20, false);
#line 29 "F:\Project\Core Map\Graduation Core\Views\Shared\_SenderDetails.cshtml"
               Write(Model.SAddressDetail);

#line default
#line hidden
            EndContext();
            BeginContext(831, 95, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>City</td>\r\n                <td>");
            EndContext();
#line 33 "F:\Project\Core Map\Graduation Core\Views\Shared\_SenderDetails.cshtml"
                      var sc = new DMSContext().City.FirstOrDefault(c => c.CId == Model.SCId).CName;

#line default
#line hidden
            BeginContext(1007, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1009, 2, false);
#line 33 "F:\Project\Core Map\Graduation Core\Views\Shared\_SenderDetails.cshtml"
                                                                                                 Write(sc);

#line default
#line hidden
            EndContext();
            BeginContext(1011, 236, true);
            WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n\r\n<div class=\"modal-footer\">\r\n    <a class=\"btn btn-secondary text-white\" data-dismiss=\"modal\" aria-label=\"Close\"><i class=\"fas fa-chevron-circle-left \"></i> Cancel</a>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Graduation_Core.Models.SenderInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591