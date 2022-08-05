using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Common.Filter
{
    /// <summary>
    /// 方法过滤器
    /// </summary>
    public class LoginFilter:IActionFilter
    {
        /// <summary>
        /// 过滤器结束后调用
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
        /// <summary>
        /// 执行方法前调用
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // 不需要校验的接口
            ArrayList list = new ArrayList() { "/", "/Account/LoginView", "/Account/AccountLogin" };
            if (!list.Contains(context.HttpContext.Request.Path.ToString()))
            {
                // 校验是否存在session
                if (context.HttpContext.Session.GetString("account") == null)
                {
                    // 重定向到登录界面
                    context.Result = new RedirectResult("/Account/LoginView");
                }
            }

        }
    }
}
