#pragma checksum "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98c194b8b68e80b33ca2118781a34b07a7fbbe19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Leaders_Delete), @"mvc.1.0.view", @"/Views/Leaders/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Leaders/Delete.cshtml", typeof(AspNetCore.Views_Leaders_Delete))]
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
#line 1 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\_ViewImports.cshtml"
using BnGClub;

#line default
#line hidden
#line 2 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\_ViewImports.cshtml"
using BnGClub.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98c194b8b68e80b33ca2118781a34b07a7fbbe19", @"/Views/Leaders/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b14c4cb9a01fd61e7b28dc9a060749f5c9ad1a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Leaders_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BnGClub.Models.Leader>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(29, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(69, 158, true);
            WriteLiteral("\n<h2>Delete</h2>\n\n<h3>Are you sure you want to delete this?</h3>\n<div>\n    <h4>Leader</h4>\n    <hr />\n    <dl class=\"dl-horizontal\">\n        <dt>\n            ");
            EndContext();
            BeginContext(228, 47, false);
#line 15 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.leaderFName));

#line default
#line hidden
            EndContext();
            BeginContext(275, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(316, 43, false);
#line 18 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml"
       Write(Html.DisplayFor(model => model.leaderFName));

#line default
#line hidden
            EndContext();
            BeginContext(359, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(400, 47, false);
#line 21 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.leaderMName));

#line default
#line hidden
            EndContext();
            BeginContext(447, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(488, 43, false);
#line 24 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml"
       Write(Html.DisplayFor(model => model.leaderMName));

#line default
#line hidden
            EndContext();
            BeginContext(531, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(572, 47, false);
#line 27 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.leaderLName));

#line default
#line hidden
            EndContext();
            BeginContext(619, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(660, 43, false);
#line 30 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml"
       Write(Html.DisplayFor(model => model.leaderLName));

#line default
#line hidden
            EndContext();
            BeginContext(703, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(744, 47, false);
#line 33 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.leaderEmail));

#line default
#line hidden
            EndContext();
            BeginContext(791, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(832, 43, false);
#line 36 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml"
       Write(Html.DisplayFor(model => model.leaderEmail));

#line default
#line hidden
            EndContext();
            BeginContext(875, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(916, 47, false);
#line 39 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.leaderPhone));

#line default
#line hidden
            EndContext();
            BeginContext(963, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1004, 43, false);
#line 42 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml"
       Write(Html.DisplayFor(model => model.leaderPhone));

#line default
#line hidden
            EndContext();
            BeginContext(1047, 34, true);
            WriteLiteral("\n        </dd>\n    </dl>\n    \n    ");
            EndContext();
            BeginContext(1081, 203, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e69971ce57f48b0b0d348c8b7e521a3", async() => {
                BeginContext(1107, 9, true);
                WriteLiteral("\n        ");
                EndContext();
                BeginContext(1116, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "75efcd7ba3ec4f4a9c6acf99d889de5a", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 47 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1152, 82, true);
                WriteLiteral("\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\n        ");
                EndContext();
                BeginContext(1234, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "639f1eb36b7b41b7ac0651db3c1abc3a", async() => {
                    BeginContext(1256, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1272, 5, true);
                WriteLiteral("\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1284, 8, true);
            WriteLiteral("\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BnGClub.Models.Leader> Html { get; private set; }
    }
}
#pragma warning restore 1591
