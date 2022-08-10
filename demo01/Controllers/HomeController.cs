using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo01.Controllers
{
    public class HomeController : Controller
    {
        // 展示首页架构
        public IActionResult MainView()
        {
            return View();
        }
        /// <summary>
        /// 展示首页主页面
        /// </summary>
        /// <returns></returns>
        public IActionResult FrontView()
        {
            return View();
        }
        /// <summary>
        /// 展示用户基本信息
        /// </summary>
        /// <returns></returns>
        public IActionResult UserBaseInfoView()
        {
            return View();
        }
    }
}
