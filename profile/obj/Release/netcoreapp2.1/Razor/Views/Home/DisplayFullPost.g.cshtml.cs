#pragma checksum "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbf235c167b255080ab39656d7f0b780acef6000"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbf235c167b255080ab39656d7f0b780acef6000", @"/Views/Home/DisplayFullPost.cshtml")]
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
            BeginContext(265, 150, true);
            WriteLiteral("\r\n\r\n\r\n\r\n<div class=\"container\">\r\n    <div class=\"jumbotron\">\r\n        <span class=\"glyphicon glyphicon-book\">\r\n            <span>\r\n                <b>");
            EndContext();
            BeginContext(416, 20, false);
#line 18 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
              Write(Model.BlogPost.title);

#line default
#line hidden
            EndContext();
            BeginContext(436, 33, true);
            WriteLiteral("</b>\r\n                Written By:");
            EndContext();
            BeginContext(470, 20, false);
#line 19 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                      Write(Model.User.firstname);

#line default
#line hidden
            EndContext();
            BeginContext(490, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(492, 19, false);
#line 19 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                                            Write(Model.User.lastname);

#line default
#line hidden
            EndContext();
            BeginContext(511, 35, true);
            WriteLiteral("<br />\r\n                Posted On: ");
            EndContext();
            BeginContext(547, 21, false);
#line 20 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                      Write(Model.BlogPost.posted);

#line default
#line hidden
            EndContext();
            BeginContext(568, 26, true);
            WriteLiteral("\r\n                UserId: ");
            EndContext();
            BeginContext(595, 21, false);
#line 21 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                   Write(Model.BlogPost.userid);

#line default
#line hidden
            EndContext();
            BeginContext(616, 32, true);
            WriteLiteral("\r\n                Poster Email: ");
            EndContext();
            BeginContext(649, 23, false);
#line 22 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                         Write(Model.User.emailaddress);

#line default
#line hidden
            EndContext();
            BeginContext(672, 59, true);
            WriteLiteral("<br />\r\n\r\n            </span>\r\n        </span>\r\n        <p>");
            EndContext();
            BeginContext(732, 22, false);
#line 26 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
      Write(Model.BlogPost.content);

#line default
#line hidden
            EndContext();
            BeginContext(754, 203, true);
            WriteLiteral("</p>\r\n\r\n    </div>\r\n    <div style=\"width: auto; display: block; border: 1px solid DarkGrey; background-color: LightGrey; margin: 10px 0px 10px 0px; padding: 0px 20px 5px 20px; border-radius: 10px;\">\r\n\r\n");
            EndContext();
#line 31 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
         if (Model.Comments == null)
        {

            

#line default
#line hidden
#line 34 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
             if (Context.Session.GetString("UserId") != null)
            {

#line default
#line hidden
            BeginContext(1086, 59, true);
            WriteLiteral("                <p>No comments, Add a comment here...</p>\r\n");
            EndContext();
#line 37 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"

            }
            else
            {

#line default
#line hidden
            BeginContext(1195, 36, true);
            WriteLiteral("                <p>No comments</p>\r\n");
            EndContext();
#line 42 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"

            }

#line default
#line hidden
#line 43 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
             
        }

        else
        {


#line default
#line hidden
            BeginContext(1288, 31, true);
            WriteLiteral("            <h3>Comments</h3>\r\n");
            EndContext();
#line 50 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
             foreach (var c in Model.Comments)
            {

#line default
#line hidden
            BeginContext(1382, 286, true);
            WriteLiteral(@"                <div style=""width: auto; display: block; border: 1px solid DarkGrey; background-color: LightGrey; margin: 10px 0px 10px 0px; padding: 0px 20px 5px 20px; border-radius: 10px;"">
                    <span class=""glyphicon glyphicon-pencil""></span>
                    <p>");
            EndContext();
            BeginContext(1669, 17, false);
#line 54 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                  Write(c.Comment.content);

#line default
#line hidden
            EndContext();
            BeginContext(1686, 64, true);
            WriteLiteral("</p>\r\n\r\n                    <span>\r\n                        By: ");
            EndContext();
            BeginContext(1751, 8, false);
#line 57 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
                       Write(c.Author);

#line default
#line hidden
            EndContext();
            BeginContext(1759, 55, true);
            WriteLiteral("\r\n                    </span>\r\n                </div>\r\n");
            EndContext();
#line 60 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
            }

#line default
#line hidden
#line 60 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
             
        }

#line default
#line hidden
            BeginContext(1840, 18, true);
            WriteLiteral("\r\n        <hr />\r\n");
            EndContext();
#line 64 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
         if (Context.Session.GetString("UserId") != null)
        {

#line default
#line hidden
            BeginContext(1928, 94, true);
            WriteLiteral("            <div class=\"form-group\">\r\n                <h5>Add a comment</h5>\r\n                ");
            EndContext();
            BeginContext(2022, 389, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c949261011884443b4f36d5a1578e4b7", async() => {
                BeginContext(2079, 60, true);
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"BlogPostId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2139, "\"", 2173, 1);
#line 69 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"
WriteAttributeValue("", 2147, Model.BlogPost.blogpostid, 2147, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2174, 230, true);
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
            BeginContext(2411, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 74 "/Users/TheKing/Projects/profile/profile/Views/Home/DisplayFullPost.cshtml"

        }

#line default
#line hidden
            BeginContext(2446, 24, true);
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