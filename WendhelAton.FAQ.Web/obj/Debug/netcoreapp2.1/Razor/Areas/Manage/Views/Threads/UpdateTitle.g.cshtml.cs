#pragma checksum "C:\Users\Shayne Maravillo\source\repos\WendhelAton.FAQ\WendhelAton.FAQ.Web\Areas\Manage\Views\Threads\UpdateTitle.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5aeb7c6313651d3d756447bb3402c314c42a5511"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Threads_UpdateTitle), @"mvc.1.0.view", @"/Areas/Manage/Views/Threads/UpdateTitle.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Manage/Views/Threads/UpdateTitle.cshtml", typeof(AspNetCore.Areas_Manage_Views_Threads_UpdateTitle))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5aeb7c6313651d3d756447bb3402c314c42a5511", @"/Areas/Manage/Views/Threads/UpdateTitle.cshtml")]
    public class Areas_Manage_Views_Threads_UpdateTitle : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WendhelAton.FAQ.Web.Areas.Manage.ViewModels.Threads.UpdateTitleViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/manage/threads/update-title"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Shayne Maravillo\source\repos\WendhelAton.FAQ\WendhelAton.FAQ.Web\Areas\Manage\Views\Threads\UpdateTitle.cshtml"
  
    ViewData["Title"] = "UpdateTitle";
    Layout = "~/Views/Shared/_PublicLayout.cshtml";

#line default
#line hidden
            BeginContext(181, 82, true);
            WriteLiteral("\r\n<h2>Update Title</h2>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        ");
            EndContext();
            BeginContext(263, 1527, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba7095e711dc466bb1044ef9c04ab22f", async() => {
                BeginContext(322, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(337, 24, false);
#line 12 "C:\Users\Shayne Maravillo\source\repos\WendhelAton.FAQ\WendhelAton.FAQ.Web\Areas\Manage\Views\Threads\UpdateTitle.cshtml"
       Write(Html.ValidationSummary());

#line default
#line hidden
                EndContext();
                BeginContext(361, 86, true);
                WriteLiteral("\r\n            <div class=\"form-group\">\r\n                <input type=\"hidden\" name=\"Id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 447, "\"", 464, 1);
#line 14 "C:\Users\Shayne Maravillo\source\repos\WendhelAton.FAQ\WendhelAton.FAQ.Web\Areas\Manage\Views\Threads\UpdateTitle.cshtml"
WriteAttributeValue("", 455, Model.Id, 455, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(465, 124, true);
                WriteLiteral(" />\r\n                <label for=\"Title\">Title:</label>\r\n                <input type=\"text\" class=\"form-control\" name=\"Title\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 589, "\"", 609, 1);
#line 16 "C:\Users\Shayne Maravillo\source\repos\WendhelAton.FAQ\WendhelAton.FAQ.Web\Areas\Manage\Views\Threads\UpdateTitle.cshtml"
WriteAttributeValue("", 597, Model.Title, 597, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(610, 222, true);
                WriteLiteral(" />\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label for=\"Description\">Description</label>\r\n                <textarea class=\"form-control\" rows=\"4\" name=\"Description\">\r\n                    ");
                EndContext();
                BeginContext(833, 17, false);
#line 21 "C:\Users\Shayne Maravillo\source\repos\WendhelAton.FAQ\WendhelAton.FAQ.Web\Areas\Manage\Views\Threads\UpdateTitle.cshtml"
               Write(Model.Description);

#line default
#line hidden
                EndContext();
                BeginContext(850, 236, true);
                WriteLiteral("\r\n                </textarea>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label for=\"UpdateAt\">Post Expiry:</label>\r\n                <input type=\"text\" class=\"form-control\" name=\"UpdatedAt\" id=\"UpdatedAt\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1086, "\"", 1110, 1);
#line 26 "C:\Users\Shayne Maravillo\source\repos\WendhelAton.FAQ\WendhelAton.FAQ.Web\Areas\Manage\Views\Threads\UpdateTitle.cshtml"
WriteAttributeValue("", 1094, Model.UpdatedAt, 1094, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1111, 231, true);
                WriteLiteral(" />\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label for=\"Template\">Template:</label>\r\n                <select name=\"TemplateName\">\r\n                    \r\n                    <option value=\"post 1\" ");
                EndContext();
                BeginContext(1344, 48, false);
#line 32 "C:\Users\Shayne Maravillo\source\repos\WendhelAton.FAQ\WendhelAton.FAQ.Web\Areas\Manage\Views\Threads\UpdateTitle.cshtml"
                                       Write(Model.TemplateName == "post 1" ? "selected" : "");

#line default
#line hidden
                EndContext();
                BeginContext(1393, 61, true);
                WriteLiteral(">post 1</option>\r\n                    <option value=\"post 2\" ");
                EndContext();
                BeginContext(1456, 48, false);
#line 33 "C:\Users\Shayne Maravillo\source\repos\WendhelAton.FAQ\WendhelAton.FAQ.Web\Areas\Manage\Views\Threads\UpdateTitle.cshtml"
                                       Write(Model.TemplateName == "post 2" ? "selected" : "");

#line default
#line hidden
                EndContext();
                BeginContext(1505, 61, true);
                WriteLiteral(">post 2</option>\r\n                    <option value=\"post 3\" ");
                EndContext();
                BeginContext(1568, 48, false);
#line 34 "C:\Users\Shayne Maravillo\source\repos\WendhelAton.FAQ\WendhelAton.FAQ.Web\Areas\Manage\Views\Threads\UpdateTitle.cshtml"
                                       Write(Model.TemplateName == "post 3" ? "selected" : "");

#line default
#line hidden
                EndContext();
                BeginContext(1617, 166, true);
                WriteLiteral(">post 3</option>\r\n                </select>\r\n\r\n\r\n            </div>\r\n            \r\n            <button type=\"submit\" class=\"btn btn-default\">Submit</button>\r\n        ");
                EndContext();
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
            EndContext();
            BeginContext(1790, 24, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("pageScripts", async() => {
                BeginContext(1835, 126, true);
                WriteLiteral("\r\n    <script>\r\n    $(function () {\r\n        $(\"#UpdatedAt\").datepicker({ dateFormat: \'dd/mm/yy\' });\r\n    });\r\n    </script>\r\n");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WendhelAton.FAQ.Web.Areas.Manage.ViewModels.Threads.UpdateTitleViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
