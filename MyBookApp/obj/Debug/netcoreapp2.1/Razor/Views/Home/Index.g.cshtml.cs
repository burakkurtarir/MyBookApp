#pragma checksum "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6ae5cd7ada412b94f92cf2f47d10d6d28782202"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\_ViewImports.cshtml"
using MyBookApp;

#line default
#line hidden
#line 2 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\_ViewImports.cshtml"
using MyBookApp.Models;

#line default
#line hidden
#line 3 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\_ViewImports.cshtml"
using MyBookApp.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6ae5cd7ada412b94f92cf2f47d10d6d28782202", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"242c8b94fa620dcbf1aebed4318a79255001ce86", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Book>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(71, 90, true);
            WriteLiteral("\r\n<h2>Home Page</h2>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <td>");
            EndContext();
            BeginContext(162, 40, false);
#line 11 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(202, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(226, 47, false);
#line 12 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(273, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(297, 42, false);
#line 13 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Author));

#line default
#line hidden
            EndContext();
            BeginContext(339, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(363, 53, false);
#line 14 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.bookCategory.Name));

#line default
#line hidden
            EndContext();
            BeginContext(416, 49, true);
            WriteLiteral("</td>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 18 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(514, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(545, 35, false);
#line 21 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(model => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(580, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(604, 42, false);
#line 22 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(model => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(646, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(670, 37, false);
#line 23 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(model => item.Author));

#line default
#line hidden
            EndContext();
            BeginContext(707, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(731, 48, false);
#line 24 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(model => item.bookCategory.Name));

#line default
#line hidden
            EndContext();
            BeginContext(779, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 26 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(812, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
#line 30 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
 if (Model.Count<Book>() == 0)
{

#line default
#line hidden
            BeginContext(873, 56, true);
            WriteLiteral("    <div class=\"alert alert-danger\">Zero Book</div>\t\t \r\n");
            EndContext();
#line 33 "C:\Users\Berk\source\repos\MyBookApp\MyBookApp\Views\Home\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Book>> Html { get; private set; }
    }
}
#pragma warning restore 1591