#pragma checksum "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ac8bdda7610eb5be9003efe1f8dfd86dbd3f14e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UsersProfile_Details), @"mvc.1.0.view", @"/Views/UsersProfile/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/UsersProfile/Details.cshtml", typeof(AspNetCore.Views_UsersProfile_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ac8bdda7610eb5be9003efe1f8dfd86dbd3f14e", @"/Views/UsersProfile/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36fad26965d5381e658c5f304c4bce8e2464a12f", @"/Views/_ViewImports.cshtml")]
    public class Views_UsersProfile_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BnGClub.Models.User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(28, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
  
    ViewData["Title"] = "Profile";

#line default
#line hidden
            BeginContext(73, 19, true);
            WriteLiteral("\r\n<h2>Profile for: ");
            EndContext();
            BeginContext(93, 14, false);
#line 7 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
            Write(Model.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(107, 86, true);
            WriteLiteral("</h2>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(194, 45, false);
#line 13 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.userFName));

#line default
#line hidden
            EndContext();
            BeginContext(239, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(283, 41, false);
#line 16 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.userFName));

#line default
#line hidden
            EndContext();
            BeginContext(324, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(368, 45, false);
#line 19 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.userMName));

#line default
#line hidden
            EndContext();
            BeginContext(413, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(457, 41, false);
#line 22 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.userMName));

#line default
#line hidden
            EndContext();
            BeginContext(498, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(542, 45, false);
#line 25 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.userLName));

#line default
#line hidden
            EndContext();
            BeginContext(587, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(631, 41, false);
#line 28 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.userLName));

#line default
#line hidden
            EndContext();
            BeginContext(672, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(716, 45, false);
#line 31 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.userPhone));

#line default
#line hidden
            EndContext();
            BeginContext(761, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(805, 41, false);
#line 34 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.userPhone));

#line default
#line hidden
            EndContext();
            BeginContext(846, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(890, 45, false);
#line 37 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.userEmail));

#line default
#line hidden
            EndContext();
            BeginContext(935, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(979, 41, false);
#line 40 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.userEmail));

#line default
#line hidden
            EndContext();
            BeginContext(1020, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1067, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0314664578340b79840206573553c99", async() => {
                BeginContext(1113, 12, true);
                WriteLiteral("Edit Profile");
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
#line 45 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
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
            BeginContext(1129, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BnGClub.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591