#pragma checksum "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55e75a3008238e176f16ce27b2e73a1b69d01f73"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subscriptions_Details), @"mvc.1.0.view", @"/Views/Subscriptions/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Subscriptions/Details.cshtml", typeof(AspNetCore.Views_Subscriptions_Details))]
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
#line 1 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\_ViewImports.cshtml"
using BnGClub;

#line default
#line hidden
#line 2 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\_ViewImports.cshtml"
using BnGClub.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55e75a3008238e176f16ce27b2e73a1b69d01f73", @"/Views/Subscriptions/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b14c4cb9a01fd61e7b28dc9a060749f5c9ad1a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Subscriptions_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BnGClub.Models.Subscriptions>
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
            BeginContext(36, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(77, 119, true);
            WriteLiteral("\n<h2>Details</h2>\n\n<div>\n    <h4>Subscriptions</h4>\n    <hr />\n    <dl class=\"dl-horizontal\">\n        <dt>\n            ");
            EndContext();
            BeginContext(197, 40, false);
#line 14 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(237, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(278, 36, false);
#line 17 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(314, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(355, 48, false);
#line 20 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PushEndpoint));

#line default
#line hidden
            EndContext();
            BeginContext(403, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(444, 44, false);
#line 23 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
       Write(Html.DisplayFor(model => model.PushEndpoint));

#line default
#line hidden
            EndContext();
            BeginContext(488, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(529, 46, false);
#line 26 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PushP256DH));

#line default
#line hidden
            EndContext();
            BeginContext(575, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(616, 42, false);
#line 29 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
       Write(Html.DisplayFor(model => model.PushP256DH));

#line default
#line hidden
            EndContext();
            BeginContext(658, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(699, 44, false);
#line 32 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PushAuth));

#line default
#line hidden
            EndContext();
            BeginContext(743, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(784, 40, false);
#line 35 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
       Write(Html.DisplayFor(model => model.PushAuth));

#line default
#line hidden
            EndContext();
            BeginContext(824, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(865, 44, false);
#line 38 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LeaderID));

#line default
#line hidden
            EndContext();
            BeginContext(909, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(950, 47, false);
#line 41 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Leader.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(997, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1038, 42, false);
#line 44 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UserID));

#line default
#line hidden
            EndContext();
            BeginContext(1080, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1121, 45, false);
#line 47 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(1166, 42, true);
            WriteLiteral("\n        </dd>\n    </dl>\n</div>\n<div>\n    ");
            EndContext();
            BeginContext(1208, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "abd01682455b4a71a41bbb894972fea9", async() => {
                BeginContext(1254, 4, true);
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
#line 52 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Subscriptions\Details.cshtml"
                           WriteLiteral(Model.ID);

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
            BeginContext(1262, 7, true);
            WriteLiteral(" |\n    ");
            EndContext();
            BeginContext(1269, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afd253b23953428f90c6421a57eb6a7b", async() => {
                BeginContext(1291, 12, true);
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
            BeginContext(1307, 8, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BnGClub.Models.Subscriptions> Html { get; private set; }
    }
}
#pragma warning restore 1591
