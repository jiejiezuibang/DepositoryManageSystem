#pragma checksum "G:\20级水电.NET开发一班覃坤\实训项目\demo\demo01\demo01\Views\Home\FrontView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3569151b57a59c39618fa329c3833fad21f3b74e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FrontView), @"mvc.1.0.view", @"/Views/Home/FrontView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3569151b57a59c39618fa329c3833fad21f3b74e", @"/Views/Home/FrontView.cshtml")]
    public class Views_Home_FrontView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
            WriteLiteral("<!DOCTYPE html>\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3569151b57a59c39618fa329c3833fad21f3b74e2710", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>主页一</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    <link rel=""stylesheet"" href=""/layuimini/lib/layui-v2.6.3/css/layui.css"" media=""all"">
    <link rel=""stylesheet"" href=""/layuimini/lib/font-awesome-4.7.0/css/font-awesome.min.css"" media=""all"">
    <link rel=""stylesheet"" href=""/layuimini/css/public.css"" media=""all"">
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
            WriteLiteral(@"
<style>
    .layui-top-box {
        padding: 40px 20px 20px 20px;
        color: #fff
    }

    .panel {
        margin-bottom: 17px;
        background-color: #fff;
        border: 1px solid transparent;
        border-radius: 3px;
        -webkit-box-shadow: 0 1px 1px rgba(0,0,0,.05);
        box-shadow: 0 1px 1px rgba(0,0,0,.05)
    }

    .panel-body {
        padding: 15px
    }

    .panel-title {
        margin-top: 0;
        margin-bottom: 0;
        font-size: 14px;
        color: inherit
    }

    .label {
        display: inline;
        padding: .2em .6em .3em;
        font-size: 75%;
        font-weight: 700;
        line-height: 1;
        color: #fff;
        text-align: center;
        white-space: nowrap;
        vertical-align: baseline;
        border-radius: .25em;
        margin-top: .3em;
    }

    .layui-red {
        color: red
    }

    .main_btn > p {
        height: 40px;
    }
</style>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3569151b57a59c39618fa329c3833fad21f3b74e5156", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container"">
        <div class=""layuimini-main layui-top-box"">
            <div class=""layui-row layui-col-space10"">

                <div class=""layui-col-md3"">
                    <div class=""col-xs-6 col-md-3"">
                        <div class=""panel layui-bg-cyan"">
                            <div class=""panel-body"">
                                <div class=""panel-title"">
                                    <span class=""label pull-right layui-bg-blue"">实时</span>
                                    <h5>用户统计</h5>
                                </div>
                                <div class=""panel-content"">
                                    <h1 class=""no-margins"">1234</h1>
                                    <div class=""stat-percent font-bold text-gray""><i class=""fa fa-commenting""></i> 1234</div>
                                    <small>当前分类总记录数</small>
                                </div>
                            </div>
                        </div>
              ");
                WriteLiteral(@"      </div>
                </div>

                <div class=""layui-col-md3"">
                    <div class=""col-xs-6 col-md-3"">
                        <div class=""panel layui-bg-blue"">
                            <div class=""panel-body"">
                                <div class=""panel-title"">
                                    <span class=""label pull-right layui-bg-cyan"">实时</span>
                                    <h5>商品统计</h5>
                                </div>
                                <div class=""panel-content"">
                                    <h1 class=""no-margins"">1234</h1>
                                    <div class=""stat-percent font-bold text-gray""><i class=""fa fa-commenting""></i> 1234</div>
                                    <small>当前分类总记录数</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class=""layui-col-md3"">
                    <div cl");
                WriteLiteral(@"ass=""col-xs-6 col-md-3"">
                        <div class=""panel layui-bg-green"">
                            <div class=""panel-body"">
                                <div class=""panel-title"">
                                    <span class=""label pull-right layui-bg-orange"">实时</span>
                                    <h5>浏览统计</h5>
                                </div>
                                <div class=""panel-content"">
                                    <h1 class=""no-margins"">1234</h1>
                                    <div class=""stat-percent font-bold text-gray""><i class=""fa fa-commenting""></i> 1234</div>
                                    <small>当前分类总记录数</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""layui-col-md3"">
                    <div class=""col-xs-6 col-md-3"">
                        <div class=""panel layui-bg-orange"">
                     ");
                WriteLiteral(@"       <div class=""panel-body"">
                                <div class=""panel-title"">
                                    <span class=""label pull-right layui-bg-green"">实时</span>
                                    <h5>订单统计</h5>
                                </div>
                                <div class=""panel-content"">
                                    <h1 class=""no-margins"">1234</h1>
                                    <div class=""stat-percent font-bold text-gray""><i class=""fa fa-commenting""></i> 1234</div>
                                    <small>当前分类总记录数</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class=""layui-box"">
            <div class=""layui-row layui-col-space10"">
                <div class=""layui-col-md12"">
                    <blockquote class=""layui-elem-quote main_btn"">
                        <p>本模板基于layui2.5.4以及font-a");
                WriteLiteral(@"wesome-4.7.0进行实现。layui开发文档地址：<a class=""layui-btn layui-btn-xs layui-btn-danger"" target=""_blank"" href=""http://www.layui.com/doc"">layui文档</a></p>
                        <p>技术交流QQ群（561838086）：<a target=""_blank"" href=""https://jq.qq.com/?_wv=1027&k=5JRGVfe""><img border=""0"" src=""//pub.idqqimg.com/wpa/images/group.png"" alt=""layuimini"" title=""layuimini""></a>（加群请备注来源：如gitee、github、官网等）</p>
                        <p>喜欢此后台模板的可以给我的GitHub和Gitee加个Star支持一下</p>
                        <p>
                            GitHub地址：
                            <iframe src=""https://ghbtns.com/github-btn.html?user=zhongshaofa&repo=layuimini&type=star&count=true"" frameborder=""0"" scrolling=""0"" width=""100px"" height=""20px""></iframe>
                            <iframe src=""https://ghbtns.com/github-btn.html?user=zhongshaofa&repo=layuimini&type=fork&count=true"" frameborder=""0"" scrolling=""0"" width=""100px"" height=""20px""></iframe>
                        </p>
                        <p>Gitee地址：<a href=""https://gitee.com/zhongshaofa/layuimi");
                WriteLiteral(@"ni"" target=""_blank""><img src=""https://gitee.com/zhongshaofa/layuimini/badge/star.svg?theme=dark"" alt=""star""></a> <a href=""https://gitee.com/zhongshaofa/layuimini"" target=""_blank""><img src=""https://gitee.com/zhongshaofa/layuimini/badge/fork.svg?theme=dark"" alt=""fork""></a></p>
                    </blockquote>
                </div>
            </div>
        </div>

        <div class=""layui-box"">
            <div class=""layui-row layui-col-space10"">
                <div class=""layui-col-md6"">
                    <table class=""layui-table"">
                        <colgroup>
                            <col width=""150"">
                            <col width=""200"">
                            <col>
                        </colgroup>
                        <thead>
                            <tr>
                                <th>昵称</th>
                                <th>加入时间</th>
                                <th>签名</th>
                            </tr>
                        </thead>
               ");
                WriteLiteral(@"         <tbody>
                            <tr>
                                <td>贤心</td>
                                <td>2016-11-29</td>
                                <td>人生就像是一场修行</td>
                            </tr>
                            <tr>
                                <td>许闲心</td>
                                <td>2016-11-28</td>
                                <td>于千万人之中遇见你所遇见的人，于千万年之中，时间的无涯的荒野里…</td>
                            </tr>
                            <tr>
                                <td>许闲心</td>
                                <td>2016-11-28</td>
                                <td>于千万人之中遇见你所遇见的人，于千万年之中，时间的无涯的荒野里…</td>
                            </tr>
                            <tr>
                                <td>许闲心</td>
                                <td>2016-11-28</td>
                                <td>于千万人之中遇见你所遇见的人，于千万年之中，时间的无涯的荒野里…</td>
                            </tr>
                        </tbody>
                    </table>
                <");
                WriteLiteral(@"/div>
                <div class=""layui-col-md6"">
                    <ul class=""layui-timeline"">
                        <li class=""layui-timeline-item"">
                            <i class=""layui-icon layui-timeline-axis"">&#xe63f;</i>
                            <div class=""layui-timeline-content layui-text"">
                                <h3 class=""layui-timeline-title"">8月18日</h3>
                                <p>
                                    layui 2.0 的一切准备工作似乎都已到位。发布之弦，一触即发。
                                    <br>不枉近百个日日夜夜与之为伴。因小而大，因弱而强。
                                    <br>无论它能走多远，抑或如何支撑？至少我曾倾注全心，无怨无悔 <i class=""layui-icon""></i>
                                </p>
                            </div>
                        </li>
                        <li class=""layui-timeline-item"">
                            <i class=""layui-icon layui-timeline-axis"">&#xe63f;</i>
                            <div class=""layui-timeline-content layui-text"">
                                <h3 class=""layu");
                WriteLiteral(@"i-timeline-title"">8月16日</h3>
                                <p>杜甫的思想核心是儒家的仁政思想，他有“<em>致君尧舜上，再使风俗淳</em>”的宏伟抱负。个人最爱的名篇有：</p>
                                <ul>
                                    <li>《登高》</li>
                                    <li>《茅屋为秋风所破歌》</li>
                                </ul>
                            </div>
                        </li>
                        <li class=""layui-timeline-item"">
                            <i class=""layui-icon layui-timeline-axis"">&#xe63f;</i>
                            <div class=""layui-timeline-content layui-text"">
                                <h3 class=""layui-timeline-title"">8月15日</h3>
                                <p>
                                    中国人民抗日战争胜利72周年
                                    <br>常常在想，尽管对这个国家有这样那样的抱怨，但我们的确生在了最好的时代
                                    <br>铭记、感恩
                                    <br>所有为中华民族浴血奋战的英雄将士
                                    <br>永垂不朽
                                </p>
               ");
                WriteLiteral(@"             </div>
                        </li>
                        <li class=""layui-timeline-item"">
                            <i class=""layui-icon layui-timeline-axis"">&#xe63f;</i>
                            <div class=""layui-timeline-content layui-text"">
                                <div class=""layui-timeline-title"">过去</div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <script src=""/layuimini/lib/layui-v2.6.3/layui.js"" charset=""utf-8""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>");
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
