#pragma checksum "C:\Users\edsto\Creative Cloud Files\repos\ByteClubSite\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20921eddae51556e78f80ed538512bea3adde068"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ByteClubSite.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace ByteClubSite.Pages
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
#line 1 "C:\Users\edsto\Creative Cloud Files\repos\ByteClubSite\Pages\_ViewImports.cshtml"
using ByteClubSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\edsto\Creative Cloud Files\repos\ByteClubSite\Pages\Index.cshtml"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\edsto\Creative Cloud Files\repos\ByteClubSite\Pages\Index.cshtml"
using ByteClubSite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\edsto\Creative Cloud Files\repos\ByteClubSite\Pages\Index.cshtml"
using System.IO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20921eddae51556e78f80ed538512bea3adde068", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b60e6e9de91f1fb9599a81595a1dfeef4c6d5f1c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\edsto\Creative Cloud Files\repos\ByteClubSite\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container text-light\">\r\n    <h1>Recent</h1>\r\n    <br />\r\n    <p>This site is under construction.</p>\r\n    <br /><br />\r\n    <div class=\"container blog\">\r\n");
#nullable restore
#line 16 "C:\Users\edsto\Creative Cloud Files\repos\ByteClubSite\Pages\Index.cshtml"
          
            foreach (var data in Model.BlogPosts)
            {
                //Display Post (VS keeps unindenting this. idk why)
                //.Raw makes it so the < and > characters are actually read as tag syntax

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"blog-item\">\r\n                    <h2>");
#nullable restore
#line 22 "C:\Users\edsto\Creative Cloud Files\repos\ByteClubSite\Pages\Index.cshtml"
                   Write(data.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <p>Posted by: ");
#nullable restore
#line 23 "C:\Users\edsto\Creative Cloud Files\repos\ByteClubSite\Pages\Index.cshtml"
                             Write(data.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <div>\r\n                        ");
#nullable restore
#line 25 "C:\Users\edsto\Creative Cloud Files\repos\ByteClubSite\Pages\Index.cshtml"
                   Write(Html.Raw(data.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 28 "C:\Users\edsto\Creative Cloud Files\repos\ByteClubSite\Pages\Index.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
