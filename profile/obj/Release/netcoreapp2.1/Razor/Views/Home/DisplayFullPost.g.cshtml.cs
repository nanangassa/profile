#pragma checksum "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34cdffe7fc92f1874f8dd72d8e0f07d533a113c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DisplayFullPost), @"mvc.1.0.view", @"/Views/Home/DisplayFullPost.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/DisplayFullPost.cshtml", typeof(AspNetCore.Views_Home_DisplayFullPost))]
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
#line 1 "/Users/TheKing/Projects/profile/profile/Views/_ViewImports.cshtml"
using profile;

#line default
#line hidden
#line 2 "/Users/TheKing/Projects/profile/profile/Views/_ViewImports.cshtml"
using profile.Models;

#line default
#line hidden
#line 8 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34cdffe7fc92f1874f8dd72d8e0f07d533a113c2", @"/Views/Home/DisplayFullPost.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ba689b376f5b5779dab1de8dc4c46a70a364036", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DisplayFullPost : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<profile.ViewModels.BlogPostViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DisplayFullPost", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(121, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(130, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(265, 168, true);
            WriteLiteral("\r\n\r\n<hr />\r\n<br />\r\n\r\n<div class=\"container\">\r\n    <div class=\"jumbotron\">\r\n        <span class=\"glyphicon glyphicon-book\">\r\n            <span>\r\n\r\n\r\n                <b>");
            EndContext();
            BeginContext(434, 20, false);
#line 21 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
              Write(Model.BlogPost.title);

#line default
#line hidden
            EndContext();
            BeginContext(454, 39, true);
            WriteLiteral("</b><br />\r\n                Written By:");
            EndContext();
            BeginContext(494, 20, false);
#line 22 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                      Write(Model.User.firstname);

#line default
#line hidden
            EndContext();
            BeginContext(514, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(516, 19, false);
#line 22 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                                            Write(Model.User.lastname);

#line default
#line hidden
            EndContext();
            BeginContext(535, 35, true);
            WriteLiteral("<br />\r\n                Posted On: ");
            EndContext();
            BeginContext(571, 21, false);
#line 23 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                      Write(Model.BlogPost.posted);

#line default
#line hidden
            EndContext();
            BeginContext(592, 38, true);
            WriteLiteral("<br />\r\n                Poster Email: ");
            EndContext();
            BeginContext(631, 23, false);
#line 24 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                         Write(Model.User.emailaddress);

#line default
#line hidden
            EndContext();
            BeginContext(654, 59, true);
            WriteLiteral("<br />\r\n\r\n            </span>\r\n        </span>\r\n        <p>");
            EndContext();
            BeginContext(714, 22, false);
#line 28 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
      Write(Model.BlogPost.content);

#line default
#line hidden
            EndContext();
            BeginContext(736, 203, true);
            WriteLiteral("</p>\r\n\r\n    </div>\r\n    <div style=\"width: auto; display: block; border: 1px solid DarkGrey; background-color: LightGrey; margin: 10px 0px 10px 0px; padding: 0px 20px 5px 20px; border-radius: 10px;\">\r\n\r\n");
            EndContext();
#line 33 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
         if (Model.Comments == null)
        {

            

#line default
#line hidden
#line 36 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
             if (Context.Session.GetString("UserId") != null)
            {

#line default
#line hidden
            BeginContext(1068, 59, true);
            WriteLiteral("                <p>No comments, Add a comment here...</p>\r\n");
            EndContext();
#line 39 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"

            }
            else
            {

#line default
#line hidden
            BeginContext(1177, 36, true);
            WriteLiteral("                <p>No comments</p>\r\n");
            EndContext();
#line 44 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"

            }

#line default
#line hidden
#line 45 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
             
        }

        else
        {


#line default
#line hidden
            BeginContext(1270, 31, true);
            WriteLiteral("            <h3>Comments</h3>\r\n");
            EndContext();
#line 52 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
             foreach (var c in Model.Comments)
            {

#line default
#line hidden
            BeginContext(1364, 286, true);
            WriteLiteral(@"                <div style=""width: auto; display: block; border: 1px solid DarkGrey; background-color: LightGrey; margin: 10px 0px 10px 0px; padding: 0px 20px 5px 20px; border-radius: 10px;"">
                    <span class=""glyphicon glyphicon-pencil""></span>
                    <p>");
            EndContext();
            BeginContext(1651, 17, false);
#line 56 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                  Write(c.Comment.content);

#line default
#line hidden
            EndContext();
            BeginContext(1668, 64, true);
            WriteLiteral("</p>\r\n\r\n                    <span>\r\n                        By: ");
            EndContext();
            BeginContext(1733, 8, false);
#line 59 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                       Write(c.Author);

#line default
#line hidden
            EndContext();
            BeginContext(1741, 55, true);
            WriteLiteral("\r\n                    </span>\r\n                </div>\r\n");
            EndContext();
#line 62 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
            }

#line default
#line hidden
#line 62 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
             
        }

#line default
#line hidden
            BeginContext(1822, 18, true);
            WriteLiteral("\r\n        <hr />\r\n");
            EndContext();
#line 66 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
         if (Context.Session.GetString("UserId") != null)
        {

#line default
#line hidden
            BeginContext(1910, 94, true);
            WriteLiteral("            <div class=\"form-group\">\r\n                <h5>Add a comment</h5>\r\n                ");
            EndContext();
            BeginContext(2004, 389, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a473d3ac9a84846b8c3fffcd59ebcdc", async() => {
                BeginContext(2061, 60, true);
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"BlogPostId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2121, "\"", 2155, 1);
#line 71 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
WriteAttributeValue("", 2129, Model.BlogPost.blogpostid, 2129, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2156, 230, true);
                WriteLiteral(" />\r\n                    <textarea type=\"text\" name=\"Content\" data-length=\"5000\" class=\"form-control\"></textarea><br />\r\n                    <button class=\"btn btn-large btn-success\" type=\"submit\">Submit</button>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2393, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 76 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"

        }

#line default
#line hidden
            BeginContext(2428, 24, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<profile.ViewModels.BlogPostViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
