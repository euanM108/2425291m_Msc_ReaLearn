#pragma checksum "E:\Euan\Documents\GitHub\UoG\2425291m_Msc_ReaLearn\ReaLearn_Core\Views\SceneEditor\_AddTextPartialModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c4a5daa47de1183f5992499d25ea07e2e8120e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SceneEditor__AddTextPartialModal), @"mvc.1.0.view", @"/Views/SceneEditor/_AddTextPartialModal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SceneEditor/_AddTextPartialModal.cshtml", typeof(AspNetCore.Views_SceneEditor__AddTextPartialModal))]
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
#line 1 "E:\Euan\Documents\GitHub\UoG\2425291m_Msc_ReaLearn\ReaLearn_Core\Views\_ViewImports.cshtml"
using ReaLearn_Core;

#line default
#line hidden
#line 2 "E:\Euan\Documents\GitHub\UoG\2425291m_Msc_ReaLearn\ReaLearn_Core\Views\_ViewImports.cshtml"
using ReaLearn_Core.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c4a5daa47de1183f5992499d25ea07e2e8120e3", @"/Views/SceneEditor/_AddTextPartialModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"270521d0f1a70cd526f14189f8799a2bc7e799b0", @"/Views/_ViewImports.cshtml")]
    public class Views_SceneEditor__AddTextPartialModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 791, true);
            WriteLiteral(@"<div class=""modal-header"">
    <h4 class=""modal-title""><i class=""fa fa-font""></i> Add Text</h4>
    <button type=""button"" class=""close text-white"" data-dismiss=""modal"" aria-label=""Close"">
        <span aria-hidden=""true"">&times;</span>
    </button>
</div>
<div class=""modal-body"">
    <div class=""container"">

        <h5 for=""AddTextAssetNameAJAX"">Asset Name:</h5>
        <input type=""text"" id=""AddTextAssetNameAJAX"" class=""form-control"" name=""textName"" />

        <br />

        <h5 for=""AddTextObjectAJAX"">Text:</h5>
        <input type=""text"" id=""AddTextObjectAJAX"" class=""form-control"" />
        <button id=""AddTextObjectAJAXbtn"" class=""btn-lg btn-info"" data-loading-text="" öffnen..."" data-dismiss=""modal"" autocomplete=""off"">Save Text</button>

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
