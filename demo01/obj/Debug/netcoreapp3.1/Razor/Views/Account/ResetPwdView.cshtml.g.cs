#pragma checksum "G:\20级水电.NET开发一班覃坤\实训项目\demo\demo01\demo01\Views\Account\ResetPwdView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed2632bba9ec12500d6f53f08ad9644d25bdf795"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ResetPwdView), @"mvc.1.0.view", @"/Views/Account/ResetPwdView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed2632bba9ec12500d6f53f08ad9644d25bdf795", @"/Views/Account/ResetPwdView.cshtml")]
    public class Views_Account_ResetPwdView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed2632bba9ec12500d6f53f08ad9644d25bdf7952740", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>修改密码</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    <link rel=""stylesheet"" href=""/layuimini/lib/layui-v2.6.3/css/layui.css"" media=""all"">
    <link rel=""stylesheet"" href=""/layuimini/css/public.css"" media=""all"">
    <style>
        .layui-form-item .layui-input-company {
            width: auto;
            padding-right: 10px;
            line-height: 38px;
        }
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed2632bba9ec12500d6f53f08ad9644d25bdf7954314", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container"">
        <div class=""layuimini-main"">

            <div class=""layui-form layuimini-form"">
                <div class=""layui-form-item"">
                    <label class=""layui-form-label required"">旧的密码</label>
                    <div class=""layui-input-block"">
                        <input type=""password"" name=""oldPwd"" lay-verify=""required"" lay-reqtext=""旧的密码不能为空"" placeholder=""请输入旧的密码""");
                BeginWriteAttribute("value", " value=\"", 1058, "\"", 1066, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                        <tip>填写自己账号的旧的密码。</tip>
                    </div>
                </div>

                <div class=""layui-form-item"">
                    <label class=""layui-form-label required"">新的密码</label>
                    <div class=""layui-input-block"">
                        <input type=""password"" name=""newPwd"" lay-verify=""required"" lay-reqtext=""新的密码不能为空"" placeholder=""请输入新的密码""");
                BeginWriteAttribute("value", " value=\"", 1487, "\"", 1495, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label required"">新的密码</label>
                    <div class=""layui-input-block"">
                        <input type=""password"" name=""verifyPwd"" lay-verify=""required"" lay-reqtext=""新的密码不能为空"" placeholder=""请输入新的密码""");
                BeginWriteAttribute("value", " value=\"", 1870, "\"", 1878, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                    </div>
                </div>

                <div class=""layui-form-item"">
                    <div class=""layui-input-block"">
                        <button class=""layui-btn layui-btn-normal"" lay-submit lay-filter=""saveBtn"">确认保存</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src=""../layuimini/lib/layui-v2.6.3/layui.js"" charset=""utf-8""></script>
    <script src=""/layuimini/js/lay-config.js?v=1.0.4"" charset=""utf-8""></script>
    <script>layui.use(['form','miniTab'], function () {
        var form = layui.form,
            layer = layui.layer,
        miniTab = layui.miniTab;
    var $ = layui.jquery;
        //监听提交
        form.on('submit(saveBtn)', function (data) {
            //var index = layer.alert(JSON.stringify(data.field), {
            //    title: '最终的提交信息'
            //}, function () {
            //    layer.close(index);
            //    miniTab.deleteCurrentByIframe();
            ");
                WriteLiteral(@"//})
            //;
            // 修改用户密码
            $.ajax({
                url: '/Account/ResetPwd',
                type: 'put',
                data: data.field,
                success: function (res) {
                    if (res.code == 200) {
                        layer.alert(res.msg, function () {
                            // 返回登录界面
                            $.ajax({
                                url: '/account/OutAccountLogin',
                                type: 'get',
                                success: function (res) {
                                    if (res.code == 200) {
                                        window.location = '/Account/LoginView';
                                    }
                                }
                            })
                        })
                    } else {
                        layer.alert(res.msg)
                    }
                }
            })
            return false;
        });

    });</s");
                WriteLiteral("cript>\n");
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
