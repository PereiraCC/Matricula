#pragma checksum "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96bfd007d57d854e5fcbd8a57f49292d10b00c11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Notas_Views_Notas_InscripcionMaterias), @"mvc.1.0.view", @"/Areas/Notas/Views/Notas/InscripcionMaterias.cshtml")]
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
#line 1 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\_ViewImports.cshtml"
using Matricula;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\_ViewImports.cshtml"
using Matricula.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\_ViewImports.cshtml"
using Matricula.Areas.Mantenimiento.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\_ViewImports.cshtml"
using Matricula.Areas.Notas.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96bfd007d57d854e5fcbd8a57f49292d10b00c11", @"/Areas/Notas/Views/Notas/InscripcionMaterias.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4566bee7cbe4aca590bbb2117c6e8b10c937926b", @"/Areas/Notas/Views/_ViewImports.cshtml")]
    public class Areas_Notas_Views_Notas_InscripcionMaterias : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NotasProfesorM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Matricular", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Matriculacion/PantallaMatricula", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("imageUsers"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/Image/iconsMaterias.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Mantenimiento", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Materias/DetalleMaterias", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Notas", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Notas", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "addMateria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
  
    ViewData["Title"] = "Inscripcion de Materias";
    string nombreCompleto = Model.profesor.PrimerApellido + " " + Model.profesor.SegundoApellido + " " + Model.profesor.Nombre;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>");
#nullable restore
#line 8 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<div class=\"container p-4\">\r\n    <div class=\"form-group\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96bfd007d57d854e5fcbd8a57f49292d10b00c118520", async() => {
                WriteLiteral(@"
            <h5>Datos del Profesor</h5>
            <div class=""row"">
                <div class=""form-group"">
                    <div class=""col-md-12"">
                        <label>Identificacion</label>
                        <input type=""text""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 677, "\"", 721, 1);
#nullable restore
#line 17 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
WriteAttributeValue("", 691, Model.profesor.Identificacion, 691, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" readonly />
                    </div>
                </div>
                <div class=""form-group"">
                    <div class=""col-md-12"">
                        <label>Nombre</label>
                        <input type=""text""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 985, "\"", 1014, 1);
#nullable restore
#line 23 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
WriteAttributeValue("", 999, nombreCompleto, 999, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" readonly />
                    </div>
                </div>
                <div class=""form-group"">
                    <div class=""col-md-12"">
                        <label>Correo Electronico</label>
                        <input type=""text""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1290, "\"", 1337, 1);
#nullable restore
#line 29 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
WriteAttributeValue("", 1304, Model.profesor.CorreoElectronico, 1304, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" readonly />
                    </div>
                </div>
                <div class=""form-group"">
                    <div class=""col-md-12"">
                        <label>Carrera</label>
                        <input type=""text""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1602, "\"", 1639, 1);
#nullable restore
#line 35 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
WriteAttributeValue("", 1616, Model.profesor.Carrera, 1616, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" readonly />\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <div class=\"col-md-4\">\r\n                        <label></label>\r\n");
#nullable restore
#line 41 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
                          
                            var dataUser = JsonConvert.SerializeObject(Model);
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"dataMatricula\"");
                BeginWriteAttribute("value", " value=\"", 2056, "\"", 2073, 1);
#nullable restore
#line 45 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
WriteAttributeValue("", 2064, dataUser, 2064, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"submit\" value=\"Confirmar Inscripcion\" class=\"btn btn-success\">\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("<br />\r\n        <h5>Materias</h5>\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 53 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
             foreach (var item in Model.listaMateriasxCarrera)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-xs-6 col-md-2\">\r\n                    <div class=\"card text-center\">\r\n                        <div class=\"card-header \">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96bfd007d57d854e5fcbd8a57f49292d10b00c1115250", async() => {
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "96bfd007d57d854e5fcbd8a57f49292d10b00c1115538", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
                                 WriteLiteral(item.Codigo_Materia);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                        <div class=""card-body text-center"">
                            <table class=""tableCursos"">
                                <tbody>
                                    <tr>
                                        <td>
                                            <div class=""text-center"">
                                                <p>Codigo: ");
#nullable restore
#line 68 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
                                                      Write(Html.DisplayFor(modelItem => item.Codigo_Materia));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class=""text-center"">
                                                <p>Nombre: ");
#nullable restore
#line 75 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
                                                      Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96bfd007d57d854e5fcbd8a57f49292d10b00c1120703", async() => {
                WriteLiteral("\r\n                                                <input type=\"submit\" value=\"Detalle\" class=\"btn btn-info \">\r\n                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 81 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
                                                 WriteLiteral(item.Codigo_Materia);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td>\r\n");
#nullable restore
#line 88 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
                                             if (Model.lista_MateriasInscriptas == null)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96bfd007d57d854e5fcbd8a57f49292d10b00c1123929", async() => {
                WriteLiteral("\r\n                                                    <input type=\"submit\" value=\"Inscribirse\" class=\"btn btn-success \">\r\n                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 90 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
                                                     WriteLiteral(item.Codigo_Materia);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 93 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
                                            }
                                            else
                                            {
                                                if (Model.lista_MateriasInscriptas.Any(x => x.Codigo_Materia == item.Codigo_Materia))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <a>\r\n                                                        <input type=\"submit\" value=\"Inscrito\" class=\"btn btn-secondary \">\r\n                                                    </a>\r\n");
#nullable restore
#line 101 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96bfd007d57d854e5fcbd8a57f49292d10b00c1128059", async() => {
                WriteLiteral("\r\n                                                        <input type=\"submit\" value=\"Inscribirse\" class=\"btn btn-success \">\r\n                                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 104 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
                                                         WriteLiteral(item.Codigo_Materia);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 107 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
                                                }
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n                                    </tr>\r\n                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 116 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Notas\Views\Notas\InscripcionMaterias.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NotasProfesorM> Html { get; private set; }
    }
}
#pragma warning restore 1591
