using Common.ResultEnums;
using IDepositoryBll;
using Microsoft.AspNetCore.Mvc;
using Sister.Dtos.R_UserInfo_RoleInfo;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoryServer.Controllers
{
    public class R_UserInfo_RoleInfoController : Controller
    {
        /// <summary>
        /// 注入用户角色bll层对象
        /// </summary>
        private readonly IR_UserInfo_RoleInfoBll _r_UserInfo_RoleInfoBll;
        public R_UserInfo_RoleInfoController(IR_UserInfo_RoleInfoBll r_UserInfo_RoleInfoBll)
        {
            this._r_UserInfo_RoleInfoBll = r_UserInfo_RoleInfoBll;
        }
        /// <summary>
        /// 展示穿梭框界面
        /// </summary>
        /// <returns></returns>
        public IActionResult BindUserView()
        {
            return View();
        }
        /// <summary>
        /// 为用户绑定角色接口
        /// </summary>
        /// <param name="bindUserDto">绑定角色Dto</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> BindUser(BindUserDto bindUserDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch(await _r_UserInfo_RoleInfoBll.BindUserAsync(bindUserDto))
            {
                case R_UserInfo_RoleInfoEnums.BindUserSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "分配角色成功";
                    break;
                case R_UserInfo_RoleInfoEnums.RoleIdIsNull:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "角色Id为空";
                    break;
                case R_UserInfo_RoleInfoEnums.BindUserError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "分配角色失败";
                    break;
            }
            return Json(ajaxResult);
        }
    }
}
