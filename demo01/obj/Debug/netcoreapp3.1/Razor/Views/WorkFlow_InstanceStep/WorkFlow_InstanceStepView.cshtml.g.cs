#pragma checksum "G:\20级水电.NET开发一班覃坤\实训项目\demo\demo01\demo01\Views\WorkFlow_InstanceStep\WorkFlow_InstanceStepView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d50d4c7bcdce8016cf0799ed71be44a7071610ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WorkFlow_InstanceStep_WorkFlow_InstanceStepView), @"mvc.1.0.view", @"/Views/WorkFlow_InstanceStep/WorkFlow_InstanceStepView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d50d4c7bcdce8016cf0799ed71be44a7071610ad", @"/Views/WorkFlow_InstanceStep/WorkFlow_InstanceStepView.cshtml")]
    public class Views_WorkFlow_InstanceStep_WorkFlow_InstanceStepView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d50d4c7bcdce8016cf0799ed71be44a7071610ad3402", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>layui</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    <link rel=""stylesheet"" href=""../layuimini/lib/layui-v2.6.3/css/layui.css"" media=""all"">
    <link rel=""stylesheet"" href=""../layuimini/css/public.css"" media=""all"">
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d50d4c7bcdce8016cf0799ed71be44a7071610ad4115", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d50d4c7bcdce8016cf0799ed71be44a7071610ad5918", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container"">
        <div class=""layuimini-main"">

            <fieldset class=""table-search-fieldset"">
                <legend>搜索信息</legend>
                <div style=""margin: 10px 10px 10px 10px"">
                    <form class=""layui-form layui-form-pane""");
                BeginWriteAttribute("action", " action=\"", 824, "\"", 833, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        <div class=""layui-form-item"">
                            <div class=""layui-inline"">
                                <label class=""layui-form-label"">模板标题</label>
                                <div class=""layui-input-inline"">
                                    <input type=""text"" name=""Title"" autocomplete=""off"" class=""layui-input"">
                                </div>
                            </div>
                            <div class=""layui-inline"">
                                <button type=""submit"" class=""layui-btn layui-btn-primary"" lay-submit lay-filter=""data-search-btn""><i class=""layui-icon""></i> 搜 索</button>
                            </div>
                        </div>
                    </form>
                </div>
            </fieldset>


            <table class=""layui-hide"" id=""currentTableId"" lay-filter=""currentTableFilter""></table>

            <script type=""text/html"" id=""currentTableBar"">
                {{# if(d.reviewStatus == ");
                WriteLiteral(@"""审核中""){ }}
                <a class=""layui-btn layui-btn-normal layui-btn-xs data-count-edit"" lay-event=""edit"">审核</a>
                {{# } else { }}
                <span class=""layui-badge"">审核</span>
                {{# } }}
            </script>

        </div>
    </div>

    <script type=""text/html"" id=""Test"">
        {{#  if(d.reviewStatus === ""审核中""){ }}
        <span style=""color:#1E9FFF;"">{{ d.reviewStatus }}</span>
        {{#  } else if(d.reviewStatus === ""驳回"") { }}
        <span style=""color:red;"">{{ d.reviewStatus }}</span>
        {{#  } else if(d.reviewStatus === ""同意"") { }}
        <span style=""color: #009688;"">{{ d.reviewStatus }}</span>
        {{#  } }}
    </script>

    <script src=""/layuimini/lib/layui-v2.6.3/layui.js"" charset=""utf-8""></script>
    <script>
        layui.use(['form', 'table', 'transfer'], function () {
            var $ = layui.jquery,
                form = layui.form,
                table = layui.table;
            var transfer = layui.transfer");
                WriteLiteral(@";

            table.render({
                elem: '#currentTableId',
                url: '/WorkFlow_InstanceStep/GetShowWorkFlow_InstanceStep',
                toolbar: '#toolbarDemo',
                defaultToolbar: ['filter', 'exports', 'print', {
                    title: '提示',
                    layEvent: 'LAYTABLE_TIPS',
                    icon: 'layui-icon-tips'
                }],
                cols: [[
                    { field: 'id', title: 'ID', sort: true, hide: true },
                    { field: 'title', title: '模板名称' },
                    { field: 'consumableName', title: '耗材名称' },
                    { field: 'creatorName', title: '申请人' },
                    { field: 'reason', title: '申请理由' },
                    { field: 'outNum', title: '申请数量' },
                    { field: 'reviewerName', title: '审核人' },
                    { field: 'reviewStatus', title: '审核状态', templet: ""#Test"" },
                    { field: 'reviewTime', title: '审核时间' },
               ");
                WriteLiteral(@"     { field: 'createTime', title: '创建时间' },
                    { title: '操作', minWidth: 150, toolbar: '#currentTableBar', align: ""center"" }
                ]],
                limits: [10, 15, 20, 25, 50, 100],
                page: true,
                skin: 'line',
                id: 'currentTableId'
            });



            // 监听搜索操作
            form.on('submit(data-search-btn)', function (data) {
                //执行搜索重载
                table.reload('currentTableId', {
                    page: {
                        curr: 1
                    }
                    , where: {
                        Title: data.field.Title,
                    }
                });

                return false;
            });



            //监听表格复选框选择
            table.on('checkbox(currentTableFilter)', function (obj) {
            });

            table.on('tool(currentTableFilter)', function (obj) {
                var data = obj.data;
                if (obj.event === ");
                WriteLiteral(@"'edit') {
                    // UserId赋值用户id，给修改页面调用
                    WorkFlow_InstanceStepId = data.id;
                    var index = layer.open({
                        title: '审核',
                        type: 2,
                        shade: 0.2,
                        maxmin: true,
                        shadeClose: true,
                        area: ['100%', '100%'],
                        content: '/WorkFlow_InstanceStep/EditWorkFlow_InstanceStepView',
                        end: function () { // 回调函数，弹出层销毁后触发
                            //执行搜索重载
                            table.reload('currentTableId', {
                                page: {
                                    curr: 1
                                }
                                , where: {
                                }
                            });
                        }
                    });
                    $(window).on(""resize"", function () {
                        layer.fu");
                WriteLiteral("ll(index);\r\n                    });\r\n                    return false;\r\n                }\r\n            });\r\n\r\n        });</script>\r\n\r\n");
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
            WriteLiteral("\r\n</html>");
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