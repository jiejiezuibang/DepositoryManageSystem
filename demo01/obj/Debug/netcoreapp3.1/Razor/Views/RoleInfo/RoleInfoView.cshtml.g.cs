#pragma checksum "G:\20级水电.NET开发一班覃坤\实训项目\demo\demo01\demo01\Views\RoleInfo\RoleInfoView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f447b626f8bc5c0764a1847a07f638ca3baa4c28"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RoleInfo_RoleInfoView), @"mvc.1.0.view", @"/Views/RoleInfo/RoleInfoView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f447b626f8bc5c0764a1847a07f638ca3baa4c28", @"/Views/RoleInfo/RoleInfoView.cshtml")]
    public class Views_RoleInfo_RoleInfoView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f447b626f8bc5c0764a1847a07f638ca3baa4c282745", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>layui</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    <link rel=""stylesheet"" href=""/layuimini/lib/layui-v2.6.3/css/layui.css"" media=""all"">
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f447b626f8bc5c0764a1847a07f638ca3baa4c284148", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container"">
        <div class=""layuimini-main"">

            <fieldset class=""table-search-fieldset"">
                <legend>搜索信息</legend>
                <div style=""margin: 10px 10px 10px 10px"">
                    <form class=""layui-form layui-form-pane""");
                BeginWriteAttribute("action", " action=\"", 745, "\"", 754, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        <div class=""layui-form-item"">
                            <div class=""layui-inline"">
                                <label class=""layui-form-label"">角色名称</label>
                                <div class=""layui-input-inline"">
                                    <input type=""text"" name=""RoleName"" autocomplete=""off"" class=""layui-input"">
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
                    <button class=""layui-btn layui-btn-normal layui-btn-sm data-add-btn"" lay-event=""add""> 添加 </bu");
                WriteLiteral(@"tton>
                    <button class=""layui-btn layui-btn-sm layui-btn-danger data-delete-btn"" lay-event=""delete""> 删除 </button>
                </div>
            </script>

            <table class=""layui-hide"" id=""currentTableId"" lay-filter=""currentTableFilter""></table>

            <script type=""text/html"" id=""currentTableBar"">
                <a class=""layui-btn layui-btn-normal layui-btn-xs data-count-edit"" lay-event=""edit"">编辑</a>
                <a class=""layui-btn layui-btn-xs layui-btn-danger data-count-delete"" lay-event=""delete"">删除</a>
                <a class=""layui-btn layui-btn-xs layui-btn-warm"" lay-event=""AssigningRoles"">
                    <i class=""layui-icon"">&#xe654;</i>
                    分配角色
                </a>
                <a class=""layui-btn layui-btn-xs"" lay-event=""BindMenu"">
                    <i class=""layui-icon"">&#xe654;</i>
                    绑定菜单
                </a>
            </script>

        </div>
    </div>


    <script src=""/layuimini/lib/layui-v2.6.3/layui.j");
                WriteLiteral(@"s"" charset=""utf-8""></script>
    <script>
        layui.use(['form', 'table','transfer'], function () {
            var $ = layui.jquery,
                form = layui.form,
                table = layui.table;
            var transfer = layui.transfer;

        table.render({
            elem: '#currentTableId',
            url: '/RoleInfo/GetRoleInfoShow',
            toolbar: '#toolbarDemo',
            defaultToolbar: ['filter', 'exports', 'print', {
                title: '提示',
                layEvent: 'LAYTABLE_TIPS',
                icon: 'layui-icon-tips'
            }],
            cols: [[
                { type: ""checkbox"", width: 50 },
                { field: 'id', title: 'ID', hide: true },
                { field: 'roleName', title: '角色名称' },
                { field: 'description', title: '角色描述', },
                { field: 'createTime', title: '创建时间' },
                { title: '操作', minWidth: 150, toolbar: '#currentTableBar', align: ""center"" }
            ]],
            limits: [10, 15, 20, ");
                WriteLiteral(@"25, 50, 100],
            limit: 10,
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
                    RoleName: data.field.RoleName,
                }
            }, 'data');

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
                        content: '/RoleInfo/AddRoleIn");
                WriteLiteral(@"foView',
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
                } else if (obj.event === 'delete') {  // 监听删除操作
                    var checkStatus = table.checkStatus('currentTableId')
                        , data = checkStatus.data;
                    layer.confirm('真的删除行么', function (index) {
                        // 获取选中行的Id
                        var IdList = []
                        for (var i = 0; i < checkStatus.data.length; i++) {
                            //console.log(checkStatu");
                WriteLiteral(@"s.data[i].id)
                            IdList.push(checkStatus.data[i].id)
                        }
                        $.ajax({
                            url: '/RoleInfo/DelRoleInfo',
                            type: 'delete',
                            data: { IdList: IdList },
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
");
                WriteLiteral(@"                            }
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
                    // RoleInfoIdd赋值用户id，给修改页面调用
                    RoleInfoId = data.id;
                    var index = layer.open({
                        title: '编辑用户',
                        type: 2,
                        shade: 0.2,
                        maxmin: true,
                        shadeClose: true,
                        area: ['100%', '100%'],
                        content: '/RoleInfo/EditRoleInfoView',
                        end: function () { // 回调函数，弹出层销毁后触发
                            //执行搜索重载
                            table.reload('currentTableId', {
                                page: {
                ");
                WriteLiteral(@"                    curr: 1
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
                        $.ajax({
                            url: '/RoleInfo/DelRoleInfo',
                            type: 'delete',
                            data: { IdList: IdList },
                            success: function (res) {
                                if (res.code == 200) {
                                    // 销毁弹出层
                                    layer.close(index);
                                    //执行搜索重载
");
                WriteLiteral(@"                                    table.reload('currentTableId', {
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
                } else if (obj.event === 'AssigningRoles') {
                    RoleInfoId = data.id;
                    layer.open({
                        title:'分配角色',
                        type: 2,
                        shade: 0.2,
                        maxmin: true,
                        area: ['510px','510px'],
                        content: '/R_UserInfo_RoleInfo/BindUserView',
                    });
                }
                els");
                WriteLiteral(@"e if (obj.event === 'BindMenu') {
                    RoleInfoId = data.id;
                    layer.open({
                        title: '绑定菜单',
                        type: 2,
                        shade: 0.2,
                        maxmin: true,
                        area: ['510px', '510px'],
                        content: '/R_RoleInfo_MenuInfo/BindMenuView',
                    });
                }
            });
            
        });
    </script>
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
            WriteLiteral("\n</html>\n");
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
