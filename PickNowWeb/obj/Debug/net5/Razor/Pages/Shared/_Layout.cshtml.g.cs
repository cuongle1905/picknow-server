#pragma checksum "C:\OCS\git\picknow-server\PickNowWeb\Pages\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a33d07a07d50753e1f6842b9c964ae73c3aa7ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PickNowWeb.Pages.Shared.Pages_Shared__Layout), @"mvc.1.0.view", @"/Pages/Shared/_Layout.cshtml")]
namespace PickNowWeb.Pages.Shared
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
#line 1 "C:\OCS\git\picknow-server\PickNowWeb\Pages\_ViewImports.cshtml"
using PickNowWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\OCS\git\picknow-server\PickNowWeb\Pages\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a33d07a07d50753e1f6842b9c964ae73c3aa7ef", @"/Pages/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f3d1a55d17ebf119cca42bac90ff140a93c45c8", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/favicon.ico"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("shortcut icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("image/x-icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/css/vendor.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/vendor.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dx-viewport"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a33d07a07d50753e1f6842b9c964ae73c3aa7ef6368", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <meta charset=\"utf-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 224, "\"", 234, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n    <meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 261, "\"", 271, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n    <title>PickNowWeb</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0a33d07a07d50753e1f6842b9c964ae73c3aa7ef7221", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0a33d07a07d50753e1f6842b9c964ae73c3aa7ef8529", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 17 "C:\OCS\git\picknow-server\PickNowWeb\Pages\Shared\_Layout.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0a33d07a07d50753e1f6842b9c964ae73c3aa7ef10540", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a33d07a07d50753e1f6842b9c964ae73c3aa7ef11719", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
#nullable restore
#line 19 "C:\OCS\git\picknow-server\PickNowWeb\Pages\Shared\_Layout.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a33d07a07d50753e1f6842b9c964ae73c3aa7ef14371", async() => {
                WriteLiteral("\r\n    <div id=\"app-side-nav-outer-toolbar\">\r\n        <div class=\"layout-header\">\r\n            ");
#nullable restore
#line 25 "C:\OCS\git\picknow-server\PickNowWeb\Pages\Shared\_Layout.cshtml"
        Write(Html.DevExtreme().Toolbar()
                .Items(items => {
                    items.Add()
                        .Widget(w => w
                            .Button()
                            .Icon("menu")
                            .OnClick("PickNowWeb.onMenuButtonClick")
                        )
                        .Location(ToolbarItemLocation.Before)
                        .CssClass("menu-button");
                    items.Add()
                        .Html("<div>PickNowWeb</div>")
                        .Location(ToolbarItemLocation.Before)
                        .CssClass("header-title");
                })
            );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"layout-body layout-body-hidden\">\r\n            ");
#nullable restore
#line 43 "C:\OCS\git\picknow-server\PickNowWeb\Pages\Shared\_Layout.cshtml"
        Write(Html.DevExtreme().Drawer()
                .ID("layout-drawer")
                .Position(DrawerPosition.Left)
                .Opened(new JS("PickNowWeb.restoreDrawerOpened()"))
                .Content(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                    <div id=\"layout-drawer-scrollview\" class=\"with-footer\">\r\n                        <div class=\"content\">\r\n                            ");
#nullable restore
#line 50 "C:\OCS\git\picknow-server\PickNowWeb\Pages\Shared\_Layout.cshtml"
                       Write(RenderBody());

#line default
#line hidden
#nullable disable
    WriteLiteral(@"
                        </div>
                        <div class=""content-block"">
                            <div class=""content-footer"">
                                <div id=""footer"">
                                    Copyright (c) 2000-2020 Developer Express Inc.
                                    <br />
                                    All trademarks or registered trademarks are property of their respective owners.
                                </div>
                            </div>
                        </div>
                    </div>
                ");
    PopWriter();
}
))
                .Template(new TemplateName("navigation-menu"))
            );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n");
#nullable restore
#line 68 "C:\OCS\git\picknow-server\PickNowWeb\Pages\Shared\_Layout.cshtml"
     using(Html.DevExtreme().NamedTemplate("navigation-menu")) {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"menu-container dx-swatch-additional\">\r\n\r\n");
                WriteLiteral("\r\n            ");
#nullable restore
#line 77 "C:\OCS\git\picknow-server\PickNowWeb\Pages\Shared\_Layout.cshtml"
        Write(Html.DevExtreme().TreeView()
                .Items(items => {
                    items.Add()
                        .Text("Home")
                        .Icon("home")
                        .Option("path", GetUrl("Index"))
                        .Selected(IsCurrentUrl("Index"));

                    items.Add()
                        .Text("About")
                        .Icon("info")
                        .Option("path", GetUrl("About"))
                        .Selected(IsCurrentUrl("About"));
                })
                .ExpandEvent(TreeViewExpandEvent.Click)
                .SelectionMode(NavSelectionMode.Single)
                .SelectedExpr("selected")
                .FocusStateEnabled(false)
                .Width(250)
                .OnItemClick("PickNowWeb.onTreeViewItemClick")
            );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 99 "C:\OCS\git\picknow-server\PickNowWeb\Pages\Shared\_Layout.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <script>

        var PickNowWeb = (function() {

            var DRAWER_OPENED_KEY = ""PickNowWeb-drawer-opened"";

            var breakpoints = {
                xSmallMedia: window.matchMedia(""(max-width: 599.99px)""),
                smallMedia: window.matchMedia(""(min-width: 600px) and (max-width: 959.99px)""),
                mediumMedia: window.matchMedia(""(min-width: 960px) and (max-width: 1279.99px)""),
                largeMedia: window.matchMedia(""(min-width: 1280px)"")
            };

            function getDrawer() {
                return $(""#layout-drawer"").dxDrawer(""instance"");
            }

            function restoreDrawerOpened() {
                var isLarge = breakpoints.largeMedia.matches;
                if(!isLarge)
                    return false;

                var state = sessionStorage.getItem(DRAWER_OPENED_KEY);
                if(state === null)
                    return isLarge;

                return state === ""true"";
            }

       ");
                WriteLiteral(@"     function saveDrawerOpened() {
                sessionStorage.setItem(DRAWER_OPENED_KEY, getDrawer().option(""opened""));
            }

            function updateDrawer() {
                var isXSmall = breakpoints.xSmallMedia.matches,
                    isLarge = breakpoints.largeMedia.matches;

                getDrawer().option({
                    openedStateMode: isLarge ? ""shrink"" : ""overlap"",
                    revealMode: isXSmall ? ""slide"" : ""expand"",
                    minSize: isXSmall ? 0 : 60,
                    shading: !isLarge,
                });
            }

            function init() {
                $(""#layout-drawer-scrollview"").dxScrollView({ direction: ""vertical"" });

                $.each(breakpoints, function(_, size) {
                    size.addListener(function(e) {
                        if(e.matches)
                            updateDrawer();
                    });
                });

                updateDrawer();

               ");
                WriteLiteral(@" $('.layout-body').removeClass('layout-body-hidden');
            }

            function navigate(url, delay) {
                if(url)
                    setTimeout(function() { location.href = url }, delay);
            }

            function onMenuButtonClick() {
                getDrawer().toggle();
                saveDrawerOpened();
            }

            function onTreeViewItemClick(e) {
                var drawer = getDrawer();
                var savedOpened = restoreDrawerOpened();
                var actualOpened = drawer.option(""opened"");

                if(!actualOpened) {
                    drawer.show();
                } else {
                    var willHide = !savedOpened || !breakpoints.largeMedia.matches;
                    var willNavigate = !e.itemData.selected;

                    if(willHide)
                        drawer.hide();

                    if(willNavigate)
                        navigate(e.itemData.path, willHide ? 400 : 0);
       ");
                WriteLiteral(@"         }
            }

            return {
                init: init,
                restoreDrawerOpened: restoreDrawerOpened,
                onMenuButtonClick: onMenuButtonClick,
                onTreeViewItemClick: onTreeViewItemClick
            };
        })();

        document.addEventListener(""DOMContentLoaded"", function documentReady() {
            this.removeEventListener(""DOMContentLoaded"", documentReady);
            PickNowWeb.init();
        });
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>\r\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 71 "C:\OCS\git\picknow-server\PickNowWeb\Pages\Shared\_Layout.cshtml"
                       
                string GetUrl(string pageName) => Url.Page(pageName);
                string GetCurrentUrl() => Url.Page(ViewContext.RouteData.Values["page"].ToString());
                bool IsCurrentUrl(string pageName) => GetUrl(pageName) == GetCurrentUrl();
            

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
