using BLL;
using Common.Filter;
using Common.ResultEnums;
using IDepositoryBll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoryServer.Controllers
{
    public class AccountController : Controller
    {
        // 注入登录bll服务
        private readonly IAccountBll _accountBll;
        public AccountController(IAccountBll accountBll)
        {
            this._accountBll = accountBll;
        }
        /// <summary>
        /// 展示登录页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult LoginView()
        {
            return View();
        }
        /// <summary>
        /// 展示重置密码页面
        /// </summary>
        /// <returns></returns>
        public IActionResult ResetPwdView()
        {
            return View();
        }
        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AccountLogin(string account,string password)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 判断是否登录成功
            switch(_accountBll.DoLogin(account, password,out string UserName, out string Account,out string Id))
            {
                case AccoutnLoginEnums.accountIsNull:
                    ajaxResult.msg = "账号不能为空";
                    break;
                case AccoutnLoginEnums.PwdIsNull:
                    ajaxResult.msg = "密码不能为空";
                    break;
                case AccoutnLoginEnums.accountNotExist:
                    ajaxResult.msg = "该账号不存在";
                    break;
                case AccoutnLoginEnums.PwdError:
                    ajaxResult.msg = "密码错误";
                    break;
                case AccoutnLoginEnums.loginSuccess:
                    // 设置session
                    HttpContext.Session.SetString("account", Account);
                    HttpContext.Session.SetString("userId", Id);
                    ajaxResult.code = 200;
                    ajaxResult.msg = "登录成功";
                    ajaxResult.data = new { UserName,Id};
                    break;
                    
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 用户重置密码
        /// </summary>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <param name="verifyPwd">确认密码</param>
        /// <returns></returns>
        public IActionResult ResetPwd(string oldPwd,string newPwd,string verifyPwd)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 判断是否重置成功
            switch (_accountBll.ResetPwdBll(oldPwd, newPwd, verifyPwd, HttpContext.Session.GetString("account")))
            {
                case AccoutnLoginEnums.PwdError:
                    ajaxResult.msg = "旧密码错误";
                    break;
                case AccoutnLoginEnums.TwoPwdError:
                    ajaxResult.msg = "两次密码不同，请重新输入";
                    break; ;
                case AccoutnLoginEnums.ResetPwdSuccess:
                    OutAccountLogin(); // 清除session
                    ajaxResult.code = 200;
                    ajaxResult.msg = "重置密码成功，请重新登录";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public IActionResult OutAccountLogin()
        {
            // 清除指定的session
            HttpContext.Session.Remove("account");
            return Json(new AjaxResult
            {
                code = 200,
                msg = "退出登录成功"
            });
        }
    }
}
