#pragma checksum "E:\Euan\Documents\GitHub\UoG\ReaLearn\ReaLearn_Core\Views\SceneEditor\_AddVideoPartialModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c92ebf86873f0f1fc0cac2e716e6221897419aae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SceneEditor__AddVideoPartialModal), @"mvc.1.0.view", @"/Views/SceneEditor/_AddVideoPartialModal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SceneEditor/_AddVideoPartialModal.cshtml", typeof(AspNetCore.Views_SceneEditor__AddVideoPartialModal))]
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
#line 1 "E:\Euan\Documents\GitHub\UoG\ReaLearn\ReaLearn_Core\Views\_ViewImports.cshtml"
using ReaLearn_Core;

#line default
#line hidden
#line 2 "E:\Euan\Documents\GitHub\UoG\ReaLearn\ReaLearn_Core\Views\_ViewImports.cshtml"
using ReaLearn_Core.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c92ebf86873f0f1fc0cac2e716e6221897419aae", @"/Views/SceneEditor/_AddVideoPartialModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"270521d0f1a70cd526f14189f8799a2bc7e799b0", @"/Views/_ViewImports.cshtml")]
    public class Views_SceneEditor__AddVideoPartialModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 385, true);
            WriteLiteral(@"<div class=""modal-header"">
    <h4 class=""modal-title""><i class=""fa fa-film""></i> Add Video</h4>
    <button type=""button"" class=""close text-white"" data-dismiss=""modal"" aria-label=""Close"">
        <span aria-hidden=""true"">&times;</span>
    </button>
</div>
<div class=""modal-body"">
    <div class=""container"">
        <h5 for=""AddVideoAssetNameAJAX"">Asset Name:</h5>
        ");
            EndContext();
            BeginContext(386, 76, false);
#line 10 "E:\Euan\Documents\GitHub\UoG\ReaLearn\ReaLearn_Core\Views\SceneEditor\_AddVideoPartialModal.cshtml"
   Write(Html.TextBox("AddVideoAssetNameAJAX", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(462, 341, true);
            WriteLiteral(@"
        <br />
        <label for=""VideoObjectFile"" class=""btn-lg btn-warning margin-zero""><span class=""fa fa-upload fa-fw mr-3""></span>Video Object</label>
        <input class=""no-display"" id=""VideoObjectFile"" name=""file"" type=""file"" size=""1"">

        <p class=""InputErrorMessage"">Please enter an asset name.</p>
    </div>
</div>");
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