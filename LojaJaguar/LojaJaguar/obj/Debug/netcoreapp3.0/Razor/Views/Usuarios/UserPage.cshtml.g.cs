#pragma checksum "C:\Users\pioca_000\Videos\Loja\LojaJaguar\LojaJaguar\Views\Usuarios\UserPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "545d05396800fcca943ddbcc23a3b04cefa577ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuarios_UserPage), @"mvc.1.0.view", @"/Views/Usuarios/UserPage.cshtml")]
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
#line 1 "C:\Users\pioca_000\Videos\Loja\LojaJaguar\LojaJaguar\Views\_ViewImports.cshtml"
using LojaJaguar;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pioca_000\Videos\Loja\LojaJaguar\LojaJaguar\Views\_ViewImports.cshtml"
using LojaJaguar.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"545d05396800fcca943ddbcc23a3b04cefa577ac", @"/Views/Usuarios/UserPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47d083ae0155d0fa2437bcbe94184264e934582f", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuarios_UserPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\pioca_000\Videos\Loja\LojaJaguar\LojaJaguar\Views\Usuarios\UserPage.cshtml"
  
    ViewData["Title"] = "UserPage";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<center>\r\n    <h2>Seja bem-vindo Sr(a). ");
#nullable restore
#line 6 "C:\Users\pioca_000\Videos\Loja\LojaJaguar\LojaJaguar\Views\Usuarios\UserPage.cshtml"
                         Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <br><br>\r\n</center>");
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
