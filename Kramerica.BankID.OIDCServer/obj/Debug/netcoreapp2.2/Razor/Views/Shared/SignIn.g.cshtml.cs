#pragma checksum "C:\source\Kramerica.BankID\Kramerica.BankID.OIDCServer\Views\Shared\SignIn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa6585851264cb5bd565b358cea49128af455e84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_SignIn), @"mvc.1.0.view", @"/Views/Shared/SignIn.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/SignIn.cshtml", typeof(AspNetCore.Views_Shared_SignIn))]
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
#line 1 "C:\source\Kramerica.BankID\Kramerica.BankID.OIDCServer\Views\Shared\SignIn.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa6585851264cb5bd565b358cea49128af455e84", @"/Views/Shared/SignIn.cshtml")]
    public class Views_Shared_SignIn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 280, true);
            WriteLiteral(@"
<div class=""jumbotron"">
    <h1>Identifiering</h1>
    <p class=""lead text-left"">Identifiera dig med ditt Mobila BankId</p>
    
        <form action=""/signin"" method=""post"">
            <input type=""text"" name=""personalNumber""/>
            <input type=""hidden"" name=""ReturnUrl""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 323, "\"", 349, 1);
#line 9 "C:\source\Kramerica.BankID\Kramerica.BankID.OIDCServer\Views\Shared\SignIn.cshtml"
WriteAttributeValue("", 331, ViewBag.ReturnUrl, 331, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(350, 122, true);
            WriteLiteral(" />\n            \n            <button class=\"btn btn-lg btn-success\" type=\"submit\">Logga in</button>\n        </form>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591