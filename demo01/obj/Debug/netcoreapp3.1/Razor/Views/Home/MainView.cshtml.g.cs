#pragma checksum "G:\20级水电.NET开发一班覃坤\实训项目\demo\demo01\demo01\Views\Home\MainView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9546e4138092eac4028a1678855615ce16489801"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_MainView), @"mvc.1.0.view", @"/Views/Home/MainView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9546e4138092eac4028a1678855615ce16489801", @"/Views/Home/MainView.cshtml")]
    public class Views_Home_MainView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("layui-layout-body layuimini-all"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9546e4138092eac4028a1678855615ce164898013080", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>layuimini-iframe版 v2 - 基于Layui的后台管理系统前端模板</title>
    <meta name=""keywords"" content=""layuimini,layui,layui模板,layui后台,后台模板,admin,admin模板,layui mini"">
    <meta name=""description"" content=""layuimini基于layui的轻量级前端后台管理框架，最简洁、易用的后台框架模板，面向所有层次的前后端程序,只需提供一个接口就直接初始化整个框架，无需复杂操作。"">
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta http-equiv=""Access-Control-Allow-Origin"" content=""*"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    <meta name=""apple-mobile-web-app-status-bar-style"" content=""black"">
    <meta name=""apple-mobile-web-app-capable"" content=""yes"">
    <meta name=""format-detection"" content=""telephone=no"">
    <link rel=""icon"" href=""/layuimini/images/favicon.ico"">
    <link rel=""stylesheet"" href=""/layuimini/lib/layui-v2.6.3/css/layui.css"" media=""all"">
    <link rel=""stylesheet"" href=""/layuimini/css/layuimini.css?v=2.0.4.2"" media=""all"">
    <lin");
                WriteLiteral(@"k rel=""stylesheet"" href=""/layuimini/css/themes/default.css"" media=""all"">
    <link rel=""stylesheet"" href=""/layuimini/lib/font-awesome-4.7.0/css/font-awesome.min.css"" media=""all"">
    <!--[if lt IE 9]>
    <script src=""https://cdn.staticfile.org/html5shiv/r29/html5.min.js""></script>
    <script src=""https://cdn.staticfile.org/respond.js/1.4.2/respond.min.js""></script>
    <![endif]-->
    <style id=""layuimini-bg-color"">
    </style>
");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9546e4138092eac4028a1678855615ce164898015619", async() => {
                WriteLiteral(@"
    <div class=""layui-layout layui-layout-admin"">

        <div class=""layui-header header"">
            <div class=""layui-logo layuimini-logo""></div>

            <div class=""layuimini-header-content"">
                <a>
                    <div class=""layuimini-tool""><i title=""展开"" class=""fa fa-outdent"" data-side-fold=""1""></i></div>
                </a>

                <!--电脑端头部菜单-->
                <ul class=""layui-nav layui-layout-left layuimini-header-menu layuimini-menu-header-pc layuimini-pc-show"">
                </ul>

                <!--手机端头部菜单-->
                <ul class=""layui-nav layui-layout-left layuimini-header-menu layuimini-mobile-show"">
                    <li class=""layui-nav-item"">
                        <a href=""javascript:;""><i class=""fa fa-list-ul""></i> 选择模块</a>
                        <dl class=""layui-nav-child layuimini-menu-header-mobile"">
                        </dl>
                    </li>
                </ul>

                <ul class=""layui-nav ");
                WriteLiteral(@"layui-layout-right"">

                    <li class=""layui-nav-item"" lay-unselect>
                        <a href=""javascript:;"" data-refresh=""刷新""><i class=""fa fa-refresh""></i></a>
                    </li>
                    <li class=""layui-nav-item"" lay-unselect>
                        <a href=""javascript:;"" data-clear=""清理"" class=""layuimini-clear""><i class=""fa fa-trash-o""></i></a>
                    </li>
                    <li class=""layui-nav-item mobile layui-hide-xs"" lay-unselect>
                        <a href=""javascript:;"" data-check-screen=""full""><i class=""fa fa-arrows-alt""></i></a>
                    </li>
                    <li class=""layui-nav-item layuimini-setting"">
                        <a href=""javascript:;"" id=""userName"">admin</a>
                        <dl class=""layui-nav-child"">
                            <dd>
                                <a href=""javascript:;"" layuimini-content-href=""page/user-setting.html"" data-title=""基本资料"" data-icon=""fa fa-gears"">基本资料<spa");
                WriteLiteral(@"n class=""layui-badge-dot""></span></a>
                            </dd>
                            <dd>
                                <a href=""javascript:;"" layuimini-content-href=""/Account/ResetPwdView"" data-title=""修改密码"" data-icon=""fa fa-gears"">修改密码</a>
                            </dd>
                            <dd>
                                <hr>
                            </dd>
                            <dd>
                                <a href=""javascript:;"" class=""login-out"">退出登录</a>
                            </dd>
                        </dl>
                    </li>
                    <li class=""layui-nav-item layuimini-select-bgcolor"" lay-unselect>
                        <a href=""javascript:;"" data-bgcolor=""配色方案""><i class=""fa fa-ellipsis-v""></i></a>
                    </li>
                </ul>
            </div>
        </div>

        <!--无限极左侧菜单-->
        <div class=""layui-side layui-bg-black layuimini-menu-left"">
        </div>

        <!--初始化加载层-");
                WriteLiteral(@"->
        <div class=""layuimini-loader"">
            <div class=""layuimini-loader-inner""></div>
        </div>

        <!--手机端遮罩层-->
        <div class=""layuimini-make""></div>

        <!-- 移动导航 -->
        <div class=""layuimini-site-mobile""><i class=""layui-icon""></i></div>

        <div class=""layui-body"">

            <div class=""layuimini-tab layui-tab-rollTool layui-tab"" lay-filter=""layuiminiTab"" lay-allowclose=""true"">
                <ul class=""layui-tab-title"">
                    <li class=""layui-this"" id=""layuiminiHomeTabId""");
                BeginWriteAttribute("lay-id", " lay-id=\"", 5182, "\"", 5191, 0);
                EndWriteAttribute();
                WriteLiteral(@"></li>
                </ul>
                <div class=""layui-tab-control"">
                    <li class=""layuimini-tab-roll-left layui-icon layui-icon-left""></li>
                    <li class=""layuimini-tab-roll-right layui-icon layui-icon-right""></li>
                    <li class=""layui-tab-tool layui-icon layui-icon-down"">
                        <ul class=""layui-nav close-box"">
                            <li class=""layui-nav-item"">
                                <a href=""javascript:;""><span class=""layui-nav-more""></span></a>
                                <dl class=""layui-nav-child"">
                                    <dd><a href=""javascript:;"" layuimini-tab-close=""current"">关 闭 当 前</a></dd>
                                    <dd><a href=""javascript:;"" layuimini-tab-close=""other"">关 闭 其 他</a></dd>
                                    <dd><a href=""javascript:;"" layuimini-tab-close=""all"">关 闭 全 部</a></dd>
                                </dl>
                            </li>
           ");
                WriteLiteral(@"             </ul>
                    </li>
                </div>
                <div class=""layui-tab-content"">
                    <div id=""layuiminiHomeTabIframe"" class=""layui-tab-item layui-show""></div>
                </div>
            </div>

        </div>
    </div>
    <script src=""/layuimini/lib/layui-v2.6.3/layui.js"" charset=""utf-8""></script>
    <script src=""/layuimini/js/lay-config.js"" charset=""utf-8""></script>
    <script>layui.use(['jquery', 'layer', 'miniAdmin','miniTongji'], function () {
        var $ = layui.jquery,
            layer = layui.layer,
            miniAdmin = layui.miniAdmin,
            miniTongji = layui.miniTongji;

    $(""#userName"").text(sessionStorage.getItem(""userName""));

        var options = {
            iniUrl: ""/layuimini/api/init.json"",    // 初始化接口
          // clearUrl: ""/layuimini/api/clear.json"", // 缓存清理接口
            urlHashLocation: true,      // 是否打开hash定位
            bgColorDefault: false,      // 主题默认配置
            multiModule:");
                WriteLiteral(@" true,          // 是否开启多模块
            menuChildOpen: false,       // 是否默认展开菜单
            loadingTime: 0,             // 初始化加载时间
            pageAnim: true,             // iframe窗口动画
            maxTabNum: 20,              // 最大的tab打开数量
        };
        miniAdmin.render(options);

        // 百度统计代码，只统计指定域名
        miniTongji.render({
            specific: true,
            domains: [
                '99php.cn',
                'layuimini.99php.cn',
                'layuimini-onepage.99php.cn',
            ],
        });

        $('.login-out').on(""click"", function () {
            layer.msg('退出登录成功', function () {
                $.ajax({
                    url: '/account/OutAccountLogin',
                    type: 'get',
                    success: function (res) {
                        if (res.code == 200) {
                            window.location = '/Account/LoginView';
                        }
                    }
                })
            });
        });
");
                WriteLiteral("    });</script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
