#pragma checksum "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbf58eaf327b68832c4c661551fa7c09b9d4372d"
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
#line 1 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\_ViewImports.cshtml"
using BnGClub;

#line default
#line hidden
#line 2 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\_ViewImports.cshtml"
using BnGClub.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbf58eaf327b68832c4c661551fa7c09b9d4372d", @"/Views/UsersProfile/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b14c4cb9a01fd61e7b28dc9a060749f5c9ad1a1", @"/Views/_ViewImports.cshtml")]
    public class Views_UsersProfile_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BnGClub.Models.Users>
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
#line 2 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
  
    ViewData["Title"] = "Profile";

#line default
#line hidden
            BeginContext(72, 19, true);
            WriteLiteral("\r\n<h2>Profile for: ");
            EndContext();
            BeginContext(92, 14, false);
#line 6 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
            Write(Model.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(106, 84, true);
            WriteLiteral("</h2>\r\n<div>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(191, 45, false);
#line 11 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.userFName));

#line default
#line hidden
            EndContext();
            BeginContext(236, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(280, 41, false);
#line 14 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.userFName));

#line default
#line hidden
            EndContext();
            BeginContext(321, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(365, 45, false);
#line 17 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.userMName));

#line default
#line hidden
            EndContext();
            BeginContext(410, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(454, 41, false);
#line 20 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.userMName));

#line default
#line hidden
            EndContext();
            BeginContext(495, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(539, 45, false);
#line 23 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.userLName));

#line default
#line hidden
            EndContext();
            BeginContext(584, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(628, 41, false);
#line 26 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.userLName));

#line default
#line hidden
            EndContext();
            BeginContext(669, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(713, 45, false);
#line 29 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.userPhone));

#line default
#line hidden
            EndContext();
            BeginContext(758, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(802, 41, false);
#line 32 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.userPhone));

#line default
#line hidden
            EndContext();
            BeginContext(843, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(887, 45, false);
#line 35 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.userEmail));

#line default
#line hidden
            EndContext();
            BeginContext(932, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(976, 41, false);
#line 38 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.userEmail));

#line default
#line hidden
            EndContext();
            BeginContext(1017, 219, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Notifications?:\r\n        </dt>\r\n        <dd>\r\n            <input type=\"checkbox\" id=\"notifications\" checked data-toggle=\"toggle\">\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1236, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a7de255c7da411ea414aa99b9faffd0", async() => {
                BeginContext(1282, 12, true);
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
#line 49 "D:\B&GClub\BGC_App\BnGClub\BnGClub\Views\UsersProfile\Details.cshtml"
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
            BeginContext(1298, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BnGClub.Models.Users> Html { get; private set; }
    }
}
#pragma warning restore 1591
