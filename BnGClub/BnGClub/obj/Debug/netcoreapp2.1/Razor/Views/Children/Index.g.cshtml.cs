#pragma checksum "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd7d6563902ce89117fe1ad3add7c02ef913d656"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Children_Index), @"mvc.1.0.view", @"/Views/Children/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Children/Index.cshtml", typeof(AspNetCore.Views_Children_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd7d6563902ce89117fe1ad3add7c02ef913d656", @"/Views/Children/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b14c4cb9a01fd61e7b28dc9a060749f5c9ad1a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Children_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BnGClub.Models.Child>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(41, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(80, 25, true);
            WriteLiteral("\n<h2>Index</h2>\n\n<p>\n    ");
            EndContext();
            BeginContext(105, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "57f7463df0ae48b6bd87585978338150", async() => {
                BeginContext(128, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(142, 86, true);
            WriteLiteral("\n</p>\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
            EndContext();
            BeginContext(229, 44, false);
#line 16 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(273, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(326, 44, false);
#line 19 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.childDOB));

#line default
#line hidden
            EndContext();
            BeginContext(370, 19, true);
            WriteLiteral("\n            </th>\n");
            EndContext();
#line 21 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
             if (!User.IsInRole("Parent"))
            {

#line default
#line hidden
            BeginContext(446, 41, true);
            WriteLiteral("                <th>\n                    ");
            EndContext();
            BeginContext(488, 42, false);
#line 24 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.UserID));

#line default
#line hidden
            EndContext();
            BeginContext(530, 23, true);
            WriteLiteral("\n                </th>\n");
            EndContext();
#line 26 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(567, 123, true);
            WriteLiteral("            <th>\n                Activities\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
            EndContext();
#line 34 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(721, 46, true);
            WriteLiteral("        <tr>\n            <td>\n                ");
            EndContext();
            BeginContext(768, 43, false);
#line 37 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(811, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(864, 43, false);
#line 40 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.childDOB));

#line default
#line hidden
            EndContext();
            BeginContext(907, 19, true);
            WriteLiteral("\n            </td>\n");
            EndContext();
#line 42 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
             if (!User.IsInRole("Parent"))
            {

#line default
#line hidden
            BeginContext(983, 41, true);
            WriteLiteral("                <td>\n                    ");
            EndContext();
            BeginContext(1025, 48, false);
#line 45 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(1073, 23, true);
            WriteLiteral("\n                </td>\n");
            EndContext();
#line 47 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1110, 17, true);
            WriteLiteral("            <td>\n");
            EndContext();
#line 49 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
                 foreach (var a in item.ChildEnrolleds)
                {
                    

#line default
#line hidden
            BeginContext(1222, 20, false);
#line 51 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
               Write(a.Activities.actName);

#line default
#line hidden
            EndContext();
            BeginContext(1242, 8, true);
            WriteLiteral(" <br />\n");
            EndContext();
#line 52 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(1268, 51, true);
            WriteLiteral("            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1319, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "87e9cf8a20d44000a337dbe064be61b9", async() => {
                BeginContext(1364, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 55 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
                                       WriteLiteral(item.ID);

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
            BeginContext(1372, 19, true);
            WriteLiteral(" |\n                ");
            EndContext();
            BeginContext(1391, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02ffd2e4d090456a9aaa78f6fde1a7f5", async() => {
                BeginContext(1439, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 56 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
                                          WriteLiteral(item.ID);

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
            BeginContext(1450, 19, true);
            WriteLiteral(" |\n                ");
            EndContext();
            BeginContext(1469, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e022e9f39ec4928b48b69a1ca87b783", async() => {
                BeginContext(1516, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 57 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
                                         WriteLiteral(item.ID);

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
            BeginContext(1526, 33, true);
            WriteLiteral("\n            </td>\n        </tr>\n");
            EndContext();
#line 60 "E:\B&GClub\BGC_App\BnGClub\BnGClub\Views\Children\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1561, 22, true);
            WriteLiteral("    </tbody>\n</table>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BnGClub.Models.Child>> Html { get; private set; }
    }
}
#pragma warning restore 1591
