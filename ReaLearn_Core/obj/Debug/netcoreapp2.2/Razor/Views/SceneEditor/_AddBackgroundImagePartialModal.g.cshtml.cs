#pragma checksum "E:\Euan\Documents\GitHub\UoG\2425291m_Msc_ReaLearn\ReaLearn_Core\Views\SceneEditor\_AddBackgroundImagePartialModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38c0404320fc65709bb86d795194ea9b7b8bb211"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SceneEditor__AddBackgroundImagePartialModal), @"mvc.1.0.view", @"/Views/SceneEditor/_AddBackgroundImagePartialModal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SceneEditor/_AddBackgroundImagePartialModal.cshtml", typeof(AspNetCore.Views_SceneEditor__AddBackgroundImagePartialModal))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38c0404320fc65709bb86d795194ea9b7b8bb211", @"/Views/SceneEditor/_AddBackgroundImagePartialModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"270521d0f1a70cd526f14189f8799a2bc7e799b0", @"/Views/_ViewImports.cshtml")]
    public class Views_SceneEditor__AddBackgroundImagePartialModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ReaLearn_Core.Models.ViewModels.SceneEditorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(62, 322, true);
            WriteLiteral(@"<div class=""modal-header"">
<h4 class=""modal-title"">Add Background Image<i class=""fa fa-globe""></i></h4>
<button type=""button"" class=""close text-white"" data-dismiss=""modal"" aria-label=""Close"">
    <span aria-hidden=""true"">&times;</span>
</button>
</div>
<div class=""modal-body"">
    <div class=""container"">
        ");
            EndContext();
            BeginContext(385, 23, false);
#line 10 "E:\Euan\Documents\GitHub\UoG\2425291m_Msc_ReaLearn\ReaLearn_Core\Views\SceneEditor\_AddBackgroundImagePartialModal.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(408, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 12 "E:\Euan\Documents\GitHub\UoG\2425291m_Msc_ReaLearn\ReaLearn_Core\Views\SceneEditor\_AddBackgroundImagePartialModal.cshtml"
         if (Model.Scenes.ElementAt(Model.SelectedScene) != null)
        {
            //<form method="post" enctype="multipart/form-data" asp-action="UploadBackgroundImage" asp-controller="SceneEditor" asp-route-sceneId="@Model.Scenes.ElementAt(Model.SelectedScene).Id">

#line default
#line hidden
            BeginContext(688, 505, true);
            WriteLiteral(@"            <div class=""btn-group"" role=""group"" aria-label=""Basic example"">

                <label for=""backgroundImageFile"" class=""btn-lg btn-warning margin-zero""><span class=""fa fa-upload fa-fw mr-3""></span>Background Image Upload</label>
                <input class=""no-display"" name=""backgroundImageFile"" type=""file"" id=""backgroundImageFile""  onchange=""ShowPreview(this); closeModal()"">
                <button id=""close-modal"" class=""d-none"" data-dismiss=""modal""></button>
            </div>
");
            EndContext();
#line 21 "E:\Euan\Documents\GitHub\UoG\2425291m_Msc_ReaLearn\ReaLearn_Core\Views\SceneEditor\_AddBackgroundImagePartialModal.cshtml"
            //</form>
        }

#line default
#line hidden
            BeginContext(1227, 111, true);
            WriteLiteral("    </div>\r\n</div>\r\n<script>\r\n    function closeModal() {\r\n        $(\'#close-modal\').click();\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ReaLearn_Core.Models.ViewModels.SceneEditorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
