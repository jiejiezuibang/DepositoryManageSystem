#pragma checksum "G:\20级水电.NET开发一班覃坤\实训项目\demo\demo01\demo01\Views\WorkFlow_Model\WorkFlow_ModelView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1425f5b85d0d72bcebad9a2ae5d7e3d97cad9992"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WorkFlow_Model_WorkFlow_ModelView), @"mvc.1.0.view", @"/Views/WorkFlow_Model/WorkFlow_ModelView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1425f5b85d0d72bcebad9a2ae5d7e3d97cad9992", @"/Views/WorkFlow_Model/WorkFlow_ModelView.cshtml")]
    public class Views_WorkFlow_Model_WorkFlow_ModelView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1425f5b85d0d72bcebad9a2ae5d7e3d97cad99923332", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>layui</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    <link rel=""stylesheet"" href=""../layuimini/lib/layui-v2.6.3/css/layui.css"" media=""all"">
    <link rel=""stylesheet"" href=""../layuimini/css/public.css"" media=""all"">
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1425f5b85d0d72bcebad9a2ae5d7e3d97cad99924045", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1425f5b85d0d72bcebad9a2ae5d7e3d97cad99925848", async() => {
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

            <script type=""text/html"" id=""toolbarDemo"">
                <div class=""layui-btn-container"">
                    <button class=""layui-btn layui-btn-normal layui-btn-sm data-add-btn"" lay-event");
                WriteLiteral(@"=""add""> 添加 </button>
                    <button class=""layui-btn layui-btn-sm layui-btn-danger data-delete-btn"" lay-event=""delete""> 删除 </button>
                </div>
            </script>

            <table class=""layui-hide"" id=""currentTableId"" lay-filter=""currentTableFilter""></table>

            <script type=""text/html"" id=""currentTableBar"">
                <a class=""layui-btn layui-btn-normal layui-btn-xs data-count-edit"" lay-event=""edit"">编辑</a>
                <a class=""layui-btn layui-btn-xs layui-btn-danger data-count-delete"" lay-event=""delete"">删除</a>
            </script>

        </div>
    </div>


    <script src=""/layuimini/lib/layui-v2.6.3/layui.js"" charset=""utf-8""></script>
    <script>
layui.use(['form', 'table', 'transfer'], function () {
        var $ = layui.jquery,
            form = layui.form,
        table = layui.table;
        var transfer = layui.transfer;

        table.render({
            elem: '#currentTableId',
            url: '/WorkFlow_Model/GetSh");
                WriteLiteral(@"owWorkFlow_Model',
            toolbar: '#toolbarDemo',
            defaultToolbar: ['filter', 'exports', 'print', {
                title: '提示',
                layEvent: 'LAYTABLE_TIPS',
                icon: 'layui-icon-tips'
            }],
            cols: [[
                {type: ""checkbox"", width: 50},
                { field: 'id', title: 'ID', sort: true,hide: true},
                { field: 'title', title: '标题'},
                { field: 'description', title: '描述'},
                { field: 'createTime',  title: '添加时间'},
                {title: '操作', minWidth: 150, toolbar: '#currentTableBar', align: ""center""}
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
           ");
                WriteLiteral(@"     }
                , where: {
                    Title: data.field.Title,
                }
            });

            return false;
        });

        /**
         * toolbar监听事件
         */
        table.on('toolbar(currentTableFilter)', function (obj) {
            if (obj.event === 'add') {  // 监听添加操作
                var index = layer.open({
                    title: '添加用户',
                    type: 2,
                    shade: 0.2,
                    maxmin: true,
                    shadeClose: true,
                    area: ['100%', '100%'],
                    content: '/WorkFlow_Model/AddWorkFlow_ModelView',
                    end: function () { // 回调函数，弹出层销毁后触发
                        //执行搜索重载
                        table.reload('currentTableId', {
                            page: {
                                curr: 1
                            }
                            , where: {
                            }
                        });
      ");
                WriteLiteral(@"              }
                });
                $(window).on(""resize"", function () {
                    layer.full(index);
                });
            } else if (obj.event === 'delete') {  // 监听删除操作
                var checkStatus = table.checkStatus('currentTableId')
                    , data = checkStatus.data;
                layer.confirm('真的删除行么', function (index) {
                    // 获取选中行的Id
                    var IdList = []
                    for (var i = 0; i < checkStatus.data.length; i++) {
                        //console.log(checkStatus.data[i].id)
                        IdList.push(checkStatus.data[i].id)
                    }
                    $.ajax({
                        url: '/WorkFlow_Model/DelWorkFlow_Model',
                        type: 'delete',
                        data: { IdList: IdList },
                        success: function (res) {
                            if (res.code == 200) {
                                // 销毁弹出层
       ");
                WriteLiteral(@"                         layer.close(index);
                                //执行搜索重载
                                table.reload('currentTableId', {
                                    page: {
                                        curr: 1
                                    }
                                    , where: {
                                    }
                                });
                            } else {
                                layui.alert(res.msg)
                            }
                        }
                    })
                });

            }
        });

        //监听表格复选框选择
        table.on('checkbox(currentTableFilter)', function (obj) {
        });

        table.on('tool(currentTableFilter)', function (obj) {
            var data = obj.data;
            if (obj.event === 'edit') {
                // UserId赋值用户id，给修改页面调用
                WorkFlow_ModelId = data.id;
                var index = layer.open({
                 ");
                WriteLiteral(@"   title: '编辑用户',
                    type: 2,
                    shade: 0.2,
                    maxmin: true,
                    shadeClose: true,
                    area: ['100%', '100%'],
                    content: '/WorkFlow_Model/EditWorkFlow_ModelView',
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
                    layer.full(index);
                });
                return false;
            } else if (obj.event === 'delete') {
                layer.confirm('真的删除行么', function (index) {
                    var IdList = []
                    IdList.push(data.id)
              ");
                WriteLiteral(@"      $.ajax({
                        url: '/WorkFlow_Model/DelWorkFlow_Model',
                        type: 'delete',
                        data: { IdList:IdList },
                        success: function (res) {
                            if (res.code == 200) {
                                // 销毁弹出层
                                layer.close(index);
                                //执行搜索重载
                                table.reload('currentTableId', {
                                    page: {
                                        curr: 1
                                    }
                                    , where: {
                                    }
                                });
                            } else {
                                layui.alert(res.msg)
                            }
                        }
                    })
                });
            }
        });

    });</script>

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
