#pragma checksum "C:\Users\Md.Rizwanul\Downloads\Agile\PMP-Agile\PMPReportingTool\Areas\Identity\Pages\_UserLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5634be1d01590d402514498aab4dbc2ba90df231"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages__UserLayout), @"mvc.1.0.view", @"/Areas/Identity/Pages/_UserLayout.cshtml")]
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
#line 1 "C:\Users\Md.Rizwanul\Downloads\Agile\PMP-Agile\PMPReportingTool\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Md.Rizwanul\Downloads\Agile\PMP-Agile\PMPReportingTool\Areas\Identity\Pages\_ViewImports.cshtml"
using PMPReportingTool.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Md.Rizwanul\Downloads\Agile\PMP-Agile\PMPReportingTool\Areas\Identity\Pages\_ViewImports.cshtml"
using PMPReportingTool.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Md.Rizwanul\Downloads\Agile\PMP-Agile\PMPReportingTool\Areas\Identity\Pages\_ViewImports.cshtml"
using PMPReportingTool.Areas.Identity.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5634be1d01590d402514498aab4dbc2ba90df231", @"/Areas/Identity/Pages/_UserLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de7bfdea8706e3d2726c7897a2cb51b3ed1825df", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Identity_Pages__UserLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Md.Rizwanul\Downloads\Agile\PMP-Agile\PMPReportingTool\Areas\Identity\Pages\_UserLayout.cshtml"
  
    Layout = "/Pages/shared/_layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-6 offset-md-3"">
        <div class=""card login-logout-tab"">
            <div class=""card-header"">
                <ul class=""nav nav-tabs card-header-tabs"">
                    <li class=""nav-item"">
                        <a class=""nav-link"" href='/Identity/Account/Login'>Sign In</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" href='/Identity/Account/Register'>Sign Up</a>
                    </li>
                </ul>
            </div>
            <div class=""card-content"">
                <div class=""col-md-12"">
                    ");
#nullable restore
#line 20 "C:\Users\Md.Rizwanul\Downloads\Agile\PMP-Agile\PMPReportingTool\Areas\Identity\Pages\_UserLayout.cshtml"
               Write(RenderBody());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 28 "C:\Users\Md.Rizwanul\Downloads\Agile\PMP-Agile\PMPReportingTool\Areas\Identity\Pages\_UserLayout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <script>
        $(function () {
            var current = location.pathname;
            $('.nav-tabs li a').each(function () {
                var $this = $(this);
                if (current.indexOf($this.attr('href')) !== -1) {
                    $this.addClass('active');
                }
            })
        })
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
