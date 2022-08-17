using Common.ResultEnums;
using IDepositoryBll;
using Microsoft.AspNetCore.Mvc;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoryServer.Controllers
{
    public class R_RoleInfo_MenuInfoController : Controller
    {
        private readonly IRoleInfoBll _roleInfoBll;
        public R_RoleInfo_MenuInfoController(IRoleInfoBll roleInfoBll)
        {
            this._roleInfoBll = roleInfoBll;
        }
        /// <summary>
        /// 展示绑定菜单页面
        /// </summary>
        /// <returns></returns>
        public IActionResult BindMenuView()
        {
            return View();
        }
        /// <summary>
        /// 绑定角色菜单接口
        /// </summary>
        /// <param name="RoleId">角色Id</param>
        /// <param name="MenuIds">菜单Id</param>
        /// <returns></returns>
        public async Task<IActionResult> BindMenu(string RoleId,string[] MenuIds)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 判断绑定菜单是否成功
            switch (await _roleInfoBll.BindMenuInfo(RoleId, MenuIds))
            {
                case RoleInfoEnums.BindMenuSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "绑定菜单成功";
                    break;
                case RoleInfoEnums.RoleIdIsNull:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "角色Id不能为空";
                    break;
            }
            return Json(ajaxResult);
        }
    }
}
