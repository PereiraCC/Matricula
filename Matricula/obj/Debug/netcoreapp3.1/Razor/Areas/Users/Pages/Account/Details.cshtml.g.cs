#pragma checksum "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\Account\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7b5f7196f8b8aa1222b0d1339e159dadcdba93c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Matricula.Areas.Users.Pages.Account.Account.Areas_Users_Pages_Account_Details), @"mvc.1.0.razor-page", @"/Areas/Users/Pages/Account/Details.cshtml")]
namespace Matricula.Areas.Users.Pages.Account.Account
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
#line 1 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\_ViewImports.cshtml"
using Matricula.Areas.Users.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7b5f7196f8b8aa1222b0d1339e159dadcdba93c", @"/Areas/Users/Pages/Account/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c035ee612d66e75329fc7ed6bd4915045aaadef", @"/Areas/Users/Pages/_ViewImports.cshtml")]
    public class Areas_Users_Pages_Account_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("imageUserDetails"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/Image/no_avatar.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Users", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\Account\Details.cshtml"
  
    ViewData["Title"] = "Detalle Usuario";
    var name = Model.Input.DataUser.Nombre + " " + Model.Input.DataUser.PrimerApellido;
    var name2 = Model.Input.DataUser.Nombre + " " + Model.Input.DataUser.PrimerApellido + " " + Model.Input.DataUser.SegundoApellido;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <h1>");
#nullable restore
#line 11 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\Account\Details.cshtml"
   Write(name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1><br />\r\n    <div class=\"row\">\r\n        <div class=\"col-sm \">\r\n            <div class=\"card text-center\" style=\"width: 21rem;\">\r\n                <div class=\"card-header \">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e7b5f7196f8b8aa1222b0d1339e159dadcdba93c6570", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <div class=""card-body"">
                    <table class=""tableCursos"">
                        <tbody>
                            <tr>
                                <td>
                                    <p>");
#nullable restore
#line 23 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\Account\Details.cshtml"
                                  Write(name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>\r\n                                    <p>Rol: ");
#nullable restore
#line 28 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\Account\Details.cshtml"
                                       Write(Model.Input.DataUser.Rol);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </p>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class=""col-sm"">
            <div class=""card"">
                <div class=""card-body"">
                    <table class=""tableCursos"">
                        <tbody>
                            <tr>
                                <th>
                                    Informacion
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    Identificacion
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <p>");
#nullable restore
#line 53 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\Account\Details.cshtml"
                                  Write(Model.Input.DataUser.Identificacion);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Nombre Completo
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <p>");
#nullable restore
#line 63 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\Account\Details.cshtml"
                                  Write(name2);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Correo electronico
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <p>");
#nullable restore
#line 73 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\Account\Details.cshtml"
                                  Write(Model.Input.DataUser.CorreoElectronico);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Telefono
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <p>");
#nullable restore
#line 83 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\Account\Details.cshtml"
                                  Write(Model.Input.DataUser.Telefono);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7b5f7196f8b8aa1222b0d1339e159dadcdba93c12318", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 89 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\Account\Details.cshtml"
                                          
                                            var dataUser = JsonConvert.SerializeObject(Model.Input.DataUser);
                                        

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        <input type=\"hidden\" name=\"DataUser\"");
                BeginWriteAttribute("value", " value=\"", 3786, "\"", 3803, 1);
#nullable restore
#line 93 "C:\Users\perei\Documents\Personal\CUC\Administracion de Base Datos\Proyecto\Matricula\Matricula\Areas\Users\Pages\Account\Details.cshtml"
WriteAttributeValue("", 3794, dataUser, 3794, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                        <input type=\"submit\" value=\"Editar\" class=\"btn btn-success \">\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsModel>)PageContext?.ViewData;
        public DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
