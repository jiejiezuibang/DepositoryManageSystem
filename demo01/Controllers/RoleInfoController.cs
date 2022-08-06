using Common.ResultEnums;
using IDepositoryBll;
using Microsoft.AspNetCore.Mvc;
using Sister.Dtos.RoleInfo;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoryServer.Controllers
{
    public class RoleInfoController : Controller
    {
        /// <summary>
        /// 注入角色管理逻辑层对象
        /// </summary>
        private readonly IRoleInfoBll _roleInfoBll;
        public RoleInfoController(IRoleInfoBll roleInfoBll)
        {
            this._roleInfoBll = roleInfoBll;
        }
        /// <summary>
        ///展示角色信息主页面接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RoleInfoView()
        {
            return View();
        }
        /// <summary>
        /// 展示添加角色页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddRoleInfoView()
        {
            return View();
        }
        /// <summary>
        /// 展示修改角色页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditRoleInfoView()
        {
            return View();
        }
        /// <summary>
        /// 获取展示角色信息接口
        /// </summary>
        /// <param name="findRoleInfoDto">查询角色信息dto</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRoleInfoShow(FindRoleInfoDto findRoleInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 获取角色信息
            List<RoleInfoDto> roleInfoDtos = _roleInfoBll.GetShowBll(findRoleInfoDto, out int RoleInfoCount);
            // 判断角色信息是否为空
            if (roleInfoDtos != null)
            {
                ajaxResult.code = 0;
                ajaxResult.msg = "获取角色信息数据成功";
                ajaxResult.data = roleInfoDtos;
                ajaxResult.count = RoleInfoCount;
                return Json(ajaxResult);
            }
            ajaxResult.code = 500;
            ajaxResult.msg = "没有更多的角色信息了";
            return Json(ajaxResult);
        }
        /// <summary>
        /// 添加角色信息接口
        /// </summary>
        /// <param name="addRoleInfoDto">添加角色信息dto</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddRoleInfo(AddRoleInfoDto addRoleInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 判断是否添加成功
            switch (await _roleInfoBll.AddBllAsync(addRoleInfoDto))
            {
                case RoleInfoEnums.AddRoleInfoSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "添加角色成功";
                    break;
                case RoleInfoEnums.AddRoleInfoError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "添加角色失败";
                    break;
                case RoleInfoEnums.RoleInfoRoleNameNulll:
                    ajaxResult.code = 501;
                    ajaxResult.msg = "角色名不能为空";
                    break;
                case RoleInfoEnums.RoleNameExist:
                    ajaxResult.code = 501;
                    ajaxResult.msg = "角色名以存在";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 修改角色信息接口
        /// </summary>
        /// <param name="editRoleInfoDto">修改角色dto</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditRoleInfo(EditRoleInfoDto editRoleInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 判断是否修改成功
            switch (await _roleInfoBll.EditBllAsync(editRoleInfoDto))
            {
                case RoleInfoEnums.EditRoleInfoSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "修改角色信息成功";
                    break;
                case RoleInfoEnums.AddRoleInfoError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "修改角色信息失败";
                    break;
                case RoleInfoEnums.RoleInfoRoleNameNulll:
                    ajaxResult.code = 501;
                    ajaxResult.msg = "角色名不能为空";
                    break;
                case RoleInfoEnums.RoleNameExist:
                    ajaxResult.code = 501;
                    ajaxResult.msg = "角色名以存在";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 删除角色信息接口
        /// </summary>
        /// <param name="IdList">角色id数组</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DelRoleInfo(string[] IdList)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 判断删除角色信息是否成功
            switch(await _roleInfoBll.DelBllAsync(IdList))
            {
                case RoleInfoEnums.DelRoleInfoSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "删除角色信息成功";
                    break;
                case RoleInfoEnums.DelRoleInfoError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "删除角色信息失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 根据角色Id获取角色信息
        /// </summary>
        /// <param name="Id">角色Id</param>
        /// <returns></returns>
        public async Task<IActionResult> FindRoleInfo(string Id)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 判断是否获取到角色信息
            if (await _roleInfoBll.FindRoleInfo(Id) != null)
            {
                ajaxResult.code = 200;
                ajaxResult.msg = "获取角色信息成功";
                ajaxResult.data = await _roleInfoBll.FindRoleInfo(Id);
                return Json(ajaxResult);
            }
            ajaxResult.code = 404;
            ajaxResult.msg = "获取角色信息失败";
            return Json(ajaxResult);
        }
    }
}
