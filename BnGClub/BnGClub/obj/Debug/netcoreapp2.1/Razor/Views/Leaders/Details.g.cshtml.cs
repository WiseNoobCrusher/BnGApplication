#pragma checksum "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3fb7563540aa40c8252dfc4b60879a761f00a2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Leaders_Details), @"mvc.1.0.view", @"/Views/Leaders/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Leaders/Details.cshtml", typeof(AspNetCore.Views_Leaders_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3fb7563540aa40c8252dfc4b60879a761f00a2d", @"/Views/Leaders/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36fad26965d5381e658c5f304c4bce8e2464a12f", @"/Views/_ViewImports.cshtml")]
    public class Views_Leaders_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BnGClub.Models.Leader>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(75, 120, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>Leader</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(196, 47, false);
#line 14 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.leaderFName));

#line default
#line hidden
            EndContext();
            BeginContext(243, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(287, 43, false);
#line 17 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml"
       Write(Html.DisplayFor(model => model.leaderFName));

#line default
#line hidden
            EndContext();
            BeginContext(330, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(374, 47, false);
#line 20 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.leaderMName));

#line default
#line hidden
            EndContext();
            BeginContext(421, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(465, 43, false);
#line 23 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml"
       Write(Html.DisplayFor(model => model.leaderMName));

#line default
#line hidden
            EndContext();
            BeginContext(508, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(552, 47, false);
#line 26 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.leaderLName));

#line default
#line hidden
            EndContext();
            BeginContext(599, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(643, 43, false);
#line 29 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml"
       Write(Html.DisplayFor(model => model.leaderLName));

#line default
#line hidden
            EndContext();
            BeginContext(686, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(730, 47, false);
#line 32 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.leaderEmail));

#line default
#line hidden
            EndContext();
            BeginContext(777, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(821, 43, false);
#line 35 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml"
       Write(Html.DisplayFor(model => model.leaderEmail));

#line default
#line hidden
            EndContext();
            BeginContext(864, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(908, 47, false);
#line 38 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.leaderPhone));

#line default
#line hidden
            EndContext();
            BeginContext(955, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(999, 43, false);
#line 41 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml"
       Write(Html.DisplayFor(model => model.leaderPhone));

#line default
#line hidden
            EndContext();
            BeginContext(1042, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1089, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "63cafe2767bf448bbc185084b647457a", async() => {
                BeginContext(1135, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 46 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Leaders\Details.cshtml"
                           WriteLiteral(Model.id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1143, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1151, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e345b7f59fc34b06812f8f32e59455dc", async() => {
                BeginContext(1173, 12, true);
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
            BeginContext(1189, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
