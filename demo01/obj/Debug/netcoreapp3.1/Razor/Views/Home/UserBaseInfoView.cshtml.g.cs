#pragma checksum "G:\20级水电.NET开发一班覃坤\实训项目\demo\demo01\demo01\Views\Home\UserBaseInfoView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7253d64fcfa9be91ceef8027215ecaff4d6eb2cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_UserBaseInfoView), @"mvc.1.0.view", @"/Views/Home/UserBaseInfoView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7253d64fcfa9be91ceef8027215ecaff4d6eb2cf", @"/Views/Home/UserBaseInfoView.cshtml")]
    public class Views_Home_UserBaseInfoView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7253d64fcfa9be91ceef8027215ecaff4d6eb2cf2745", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>基本资料</title>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7253d64fcfa9be91ceef8027215ecaff4d6eb2cf4319", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container"">
        <div class=""layuimini-main"">

            <div class=""layui-form layuimini-form"" lay-filter=""BaseInfoForm"">
                <div class=""layui-form-item"">
                    <label class=""layui-form-label"">手机</label>
                    <div class=""layui-input-block"">
                        <input type=""number"" name=""PhoneNum"" lay-verify=""required"" lay-reqtext=""手机不能为空"" placeholder=""请输入手机""");
                BeginWriteAttribute("value", " value=\"", 1069, "\"", 1077, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label"">邮箱</label>
                    <div class=""layui-input-block"">
                        <input type=""email"" name=""Email"" placeholder=""请输入邮箱""");
                BeginWriteAttribute("value", " value=\"", 1387, "\"", 1395, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label"">更换头像</label>
                    <div class=""layui-input-block"">
                        <button type=""button"" class=""layui-btn"" id=""avater"">
                            <i class=""layui-icon"">&#xe67c;</i>上传图片
                        </button>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <div class=""layui-input-block"">
                        <button id=""Save"" class=""layui-btn layui-btn-normal"" lay-submit lay-filter=""saveBtn"">确认保存</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src=""/layuimini/lib/layui-v2.6.3/layui.js"" charset=""utf-8""></script>
    <script src=""/layuimini/js/lay-config.js?v=1.0.4"" charset=""utf-8""></script>
    <script>layui.use(['form','miniTab','upload','jquery'], function () {
        va");
                WriteLiteral(@"r form = layui.form,
            layer = layui.layer,
        miniTab = layui.miniTab;
    var upload = layui.upload;
    var $ = layui.jquery;

    // 渲染表单信息
    $.ajax({
        url: '/UserInfo/FindIdUserInfo',
        type: 'get',
        data: {
            Id: sessionStorage.getItem('id')
        },
        success: function (res) {
            //给表单赋值
            form.val(""BaseInfoForm"", { //formTest 即 class=""layui-form"" 所在元素属性 lay-filter="""" 对应的值
                ""PhoneNum"": res.data.phoneNum // ""name"": ""value""
                , ""Email"": res.data.email
            });
        }
    })

        //监听提交
        form.on('submit(saveBtn)', function (data) {
            $.ajax({
                url: '/UserInfo/EditUserBaseInfo',
                type: 'put',
                data: data.field,
                success: function (res) {
                    if (res.code == 200) {
                        layer.msg(res.msg)
                    } else {
                        layer.msg(res.msg)
   ");
                WriteLiteral(@"                 }
                }
            })
            return false;
        });

    //执行实例
        //var uploadInst = upload.render({
        //    elem: '#avater' //绑定元素
        //    , url: '/upload/' //上传接口
        //    , auto: false  // 选择文件后不自动上传
        //    , bindAction: '#Save' // 指定一个按钮触发上传
        //    , done: function (res) {
        //        //上传完毕回调
        //    }
        //    , error: function () {
        //        //请求异常回调
        //    }
        //});

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
