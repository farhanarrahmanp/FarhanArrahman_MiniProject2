#pragma checksum "/Users/farhan/VSProjects/FarhanArrahman_MiniProject2/DTSMCC_WebApp/Views/Account/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ca8a51ea392799d29d395ab0b2476a45faef896"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Index), @"mvc.1.0.view", @"/Views/Account/Index.cshtml")]
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
#line 1 "/Users/farhan/VSProjects/FarhanArrahman_MiniProject2/DTSMCC_WebApp/Views/_ViewImports.cshtml"
using DTSMCC_WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/farhan/VSProjects/FarhanArrahman_MiniProject2/DTSMCC_WebApp/Views/_ViewImports.cshtml"
using DTSMCC_WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ca8a51ea392799d29d395ab0b2476a45faef896", @"/Views/Account/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4d2e3b1d2e78ee2c66913c990fba6bad93a0cf2", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/farhan/VSProjects/FarhanArrahman_MiniProject2/DTSMCC_WebApp/Views/Account/Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Index</h1>\n\n");
#nullable restore
#line 7 "/Users/farhan/VSProjects/FarhanArrahman_MiniProject2/DTSMCC_WebApp/Views/Account/Index.cshtml"
 using (Html.BeginForm(FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/farhan/VSProjects/FarhanArrahman_MiniProject2/DTSMCC_WebApp/Views/Account/Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table"">
        <tr>
            <th>
                <a href=""/Account/Login"">Login</a>
            </th>
            <th>
                <a href=""/Account/Register"">Register</a>
            </th>
            <th>
                <a href=""/Account/ChangePassword"">Change Password</a>
            </th>
            <th>
                <a href=""/Account/ForgotPassword"">Forgot Password</a>
            </th>
        </tr>
    </table>
");
#nullable restore
#line 26 "/Users/farhan/VSProjects/FarhanArrahman_MiniProject2/DTSMCC_WebApp/Views/Account/Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
