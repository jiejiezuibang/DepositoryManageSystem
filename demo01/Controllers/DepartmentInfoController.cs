using BLL;
using IDepositoryBll;
using Microsoft.AspNetCore.Mvc;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoryServer.Controllers
{
    public class DepartmentInfoController : Controller
    {
        // 注入部门管理bll层业务对象
        private readonly IDepartmentInfoBll _departmentInfoBll;
        public DepartmentInfoController(IDepartmentInfoBll departmentInfoBll)
        {
            this._departmentInfoBll = departmentInfoBll;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public IActionResult GetDepartmentInfo()
        {
            return Json(new AjaxResult()
            {
                code = 0,
                msg = "请求部门信息成功",
                data = _departmentInfoBll.GetDepartmentInfoBll()
            });
        }
    }
}
