#pragma checksum "C:\Users\Evan Stoddard\Creative Cloud Files\repos\ByteClubSite\Pages\Minecraft.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d139af05787ca71f90fa0994c35fe148e45bfe3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ByteClubSite.Pages.Pages_Minecraft), @"mvc.1.0.razor-page", @"/Pages/Minecraft.cshtml")]
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
#line 1 "C:\Users\Evan Stoddard\Creative Cloud Files\repos\ByteClubSite\Pages\_ViewImports.cshtml"
using ByteClubSite;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d139af05787ca71f90fa0994c35fe148e45bfe3", @"/Pages/Minecraft.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22be0c9e8ef9debe928a80bc4244f3d6f2e1a734", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Minecraft : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div id=""info"" class=""text-light"">
    <h2>Current Version: Minecraft Java Edition 1.16.4</h2> 
    <p>
        The Byte Club Java Minecraft Server
        is free to all members of Byte Club, however,
        non-members can join by paying a one time fee
        of three dollars. If you are intrested in joining
        the server please fill out the form located on the
        forms page. Once the form is completed you can
        whitelist yourself in the Byte Club Discord Server
        or by messaging a Byte Club officer.
        <a href=""http://byteclub.tech/bytecraft/dynmap/"">You can also view a Live Dynamic Map of the Minecraft Server</a>
    </p>
</div>
<div>
    <img class =""mcimg"" src=""/img/Minecraft/giant.png"" />
    <br /><br /><br /><br /><br />
    <img class =""mcimg"" src=""/img/Minecraft/vorvon_base.png"" />
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ByteClubSite.Pages.MinecraftModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ByteClubSite.Pages.MinecraftModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ByteClubSite.Pages.MinecraftModel>)PageContext?.ViewData;
        public ByteClubSite.Pages.MinecraftModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
