#pragma checksum "F:\Project\Core Map\Graduation Core\Views\Home\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5a5581c5f05087ed6106ab4a51c4e69e7b8228c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Login), @"mvc.1.0.view", @"/Views/Home/Login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Login.cshtml", typeof(AspNetCore.Views_Home_Login))]
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
#line 1 "F:\Project\Core Map\Graduation Core\Views\Home\Login.cshtml"
using Graduation_Core.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5a5581c5f05087ed6106ab4a51c4e69e7b8228c", @"/Views/Home/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8b3662672c334380a63cfa8494ed8337b5d0c11", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\Project\Core Map\Graduation Core\Views\Home\Login.cshtml"
  
    UserViewModel user = new UserViewModel();

#line default
#line hidden
            BeginContext(85, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "F:\Project\Core Map\Graduation Core\Views\Home\Login.cshtml"
     using (Html.BeginForm())
    {
         

#line default
#line hidden
            BeginContext(136, 21, true);
            WriteLiteral("    <div >\r\n         ");
            EndContext();
            BeginContext(158, 28, false);
#line 10 "F:\Project\Core Map\Graduation Core\Views\Home\Login.cshtml"
    Write(Html.HiddenFor(m => user.ID));

#line default
#line hidden
            EndContext();
            BeginContext(186, 74, true);
            WriteLiteral("\r\n        <div class=\"form-group  col-lg-6 col-sm-12\">\r\n            <label");
            EndContext();
            BeginWriteAttribute("for", " for=\"", 260, "\"", 276, 1);
#line 12 "F:\Project\Core Map\Graduation Core\Views\Home\Login.cshtml"
WriteAttributeValue("", 266, user.Name, 266, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(277, 38, true);
            WriteLiteral(">User Name</label>\r\n            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 315, "\"", 330, 1);
#line 13 "F:\Project\Core Map\Graduation Core\Views\Home\Login.cshtml"
WriteAttributeValue("", 320, user.Name, 320, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(331, 158, true);
            WriteLiteral(" class=\"form-control\" placeholder=\"username\" type=\"text\" name=\"name\">\r\n        </div>\r\n        <div class=\"form-group col-lg-6 col-sm-12\">\r\n            <label");
            EndContext();
            BeginWriteAttribute("for", " for=\"", 489, "\"", 509, 1);
#line 16 "F:\Project\Core Map\Graduation Core\Views\Home\Login.cshtml"
WriteAttributeValue("", 495, user.Password, 495, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(510, 37, true);
            WriteLiteral(">Password</label>\r\n            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 547, "\"", 566, 1);
#line 17 "F:\Project\Core Map\Graduation Core\Views\Home\Login.cshtml"
WriteAttributeValue("", 552, user.Password, 552, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(567, 197, true);
            WriteLiteral(" class=\"form-control\" placeholder=\"Password\" type=\"password\" name=\"password\">\r\n        </div>\r\n        <input type=\"submit\" class=\"btn btn-success col-lg-6 col-sm-12\" value=\"Login\" />\r\n    </div>\r\n");
            EndContext();
#line 21 "F:\Project\Core Map\Graduation Core\Views\Home\Login.cshtml"
    }

#line default
#line hidden
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
