#pragma checksum "C:\Users\ronny\source\repos\XTEC_Digital_SQL\XTEC_Digital_SQL\Views\Archivoes\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25ae110c3f8747f3adf9f979471dd248509cd9c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Archivoes_Create), @"mvc.1.0.view", @"/Views/Archivoes/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25ae110c3f8747f3adf9f979471dd248509cd9c7", @"/Views/Archivoes/Create.cshtml")]
    public class Views_Archivoes_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<XTEC_Digital_SQL.Models.Archivo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ronny\source\repos\XTEC_Digital_SQL\XTEC_Digital_SQL\Views\Archivoes\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create</h1>

<h4>Archivo</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""ArchivoId"" class=""control-label""></label>
                <input asp-for=""ArchivoId"" class=""form-control"" />
                <span asp-validation-for=""ArchivoId"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Nombre"" class=""control-label""></label>
                <input asp-for=""Nombre"" class=""form-control"" />
                <span asp-validation-for=""Nombre"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""ArchivoPdf"" class=""control-label""></label>
                <input asp-for=""ArchivoPdf"" class=""form-control"" />
                <span asp-validation-for=""ArchivoPdf"" class=""text-danger"">");
            WriteLiteral(@"</span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Tamanio"" class=""control-label""></label>
                <input asp-for=""Tamanio"" class=""form-control"" />
                <span asp-validation-for=""Tamanio"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Fecha"" class=""control-label""></label>
                <input asp-for=""Fecha"" class=""form-control"" />
                <span asp-validation-for=""Fecha"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""CarpetaId"" class=""control-label""></label>
                <select asp-for=""CarpetaId"" class =""form-control"" asp-items=""ViewBag.CarpetaId""></select>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Inde");
            WriteLiteral("x\">Back to List</a>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 56 "C:\Users\ronny\source\repos\XTEC_Digital_SQL\XTEC_Digital_SQL\Views\Archivoes\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<XTEC_Digital_SQL.Models.Archivo> Html { get; private set; }
    }
}
#pragma warning restore 1591