using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Common.Filter
{
    public class LoginFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 不需要校验的接口
            ArrayList list = new ArrayList() { "/", "/Account/LoginView", "/Account/AccountLogin" };
            if (!list.Contains(filterContext.HttpContext.Request.Path.ToString()))
            {
                // 校验是否存在session
                if (filterContext.HttpContext.Session.GetString("account") == null)
                {
                    // 重定向到登录界面
                    filterContext.HttpContext.Response.Redirect("/Account/LoginView");
                }
            }
        }
    }
}
