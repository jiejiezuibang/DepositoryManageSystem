using BLL;
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
        private readonly AccountBll _accountBll;
        public AccountController(AccountBll accountBll)
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
        /// 登录操作
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IActionResult AccountLogin(string account,string password)
        {
            AjaxResult ajaxResult = new AjaxResult();
            
            if (_accountBll.DoLogin(account, password, out string msg, out string UserName,out string Account))
            {
                // 登录成功添加sesison
                HttpContext.Session.SetString("account", Account);
                ajaxResult.code = 200;
                ajaxResult.msg = msg;
                ajaxResult.data = UserName;
                return Json(ajaxResult);
            }
            ajaxResult.code = 404;
            ajaxResult.msg = msg;
            return Json(ajaxResult);
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public IActionResult OutAccountLogin()
        {
            HttpContext.Session.Remove("account");
            return Json(new AjaxResult
            {
                code = 200,
                msg = "退出登录成功"
            });
        }
    }
}
