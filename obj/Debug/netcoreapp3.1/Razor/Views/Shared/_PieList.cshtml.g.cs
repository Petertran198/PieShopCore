#pragma checksum "C:\Users\peter\source\repos\PieShop\PieShop\Views\Shared\_PieList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9268ef6744efeb590dec8328a824eb81a52ceba5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PieList), @"mvc.1.0.view", @"/Views/Shared/_PieList.cshtml")]
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
#line 3 "C:\Users\peter\source\repos\PieShop\PieShop\Views\_ViewImports.cshtml"
using PieShop.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\peter\source\repos\PieShop\PieShop\Views\_ViewImports.cshtml"
using PieShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9268ef6744efeb590dec8328a824eb81a52ceba5", @"/Views/Shared/_PieList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"616c8e50f16c2122898f87201e7f160ad3050320", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PieList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pie>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- This partial needs to recieve a pie data source -->\r\n\r\n\r\n\r\n<div class=\"col m-2\" style=\"max-width: 400px;\">\r\n    <div class=\"card \">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 162, "\"", 192, 1);
#nullable restore
#line 8 "C:\Users\peter\source\repos\PieShop\PieShop\Views\Shared\_PieList.cshtml"
WriteAttributeValue("", 168, Model.ImageThumbnailUrl, 168, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 193, "\"", 199, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"caption\">\r\n            <h3>");
#nullable restore
#line 10 "C:\Users\peter\source\repos\PieShop\PieShop\Views\Shared\_PieList.cshtml"
           Write(Model.Price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <h5>\r\n                <a>");
#nullable restore
#line 12 "C:\Users\peter\source\repos\PieShop\PieShop\Views\Shared\_PieList.cshtml"
              Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n            </h5>\r\n            <hr />\r\n            <p>");
#nullable restore
#line 15 "C:\Users\peter\source\repos\PieShop\PieShop\Views\Shared\_PieList.cshtml"
          Write(Model.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pie> Html { get; private set; }
    }
}
#pragma warning restore 1591
