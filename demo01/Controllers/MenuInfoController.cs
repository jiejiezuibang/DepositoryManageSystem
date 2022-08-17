using Common.ResultEnums;
using IDepositoryBll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sister;
using Sister.Dtos.MenuInfo;
using Sister.Dtos.UserInfo;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoryServer.Controllers
{
    public class MenuInfoController : Controller
    {
        /// <summary>
        /// 注入菜单bll层对象
        /// </summary>
        private readonly IMenuInfoBll _menuInfoBll;
        private readonly IRoleInfoBll _roleInfoBll;
        public MenuInfoController(IMenuInfoBll menuInfoBll,IRoleInfoBll roleInfoBll)
        {
            this._menuInfoBll = menuInfoBll;
            this._roleInfoBll = roleInfoBll;
        }
        /// <summary>
        /// 返回侧边栏需要的json数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMenuInitInfo()
        {
            // 获取登录用户Id
            string UserId = HttpContext.Session.GetString("userId");
            return Json(new MennInfoInitDto(_menuInfoBll.GetMenuData(UserId)));
        }
        /// <summary>
        /// 展示菜单信息主页面
        /// </summary>
        /// <returns></returns>
        public IActionResult MenuInfoView()
        {
            return View();
        }
        /// <summary>
        /// 展示添加菜单信息页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddMenuInfoView()
        {
            return View();
        }
        /// <summary>
        /// 展示修改菜单信息页面
        /// </summary>
        /// <returns></returns>
        public IActionResult EditMenuInfoView()
        {
            return View();
        }
        /// <summary>
        /// 获取菜单信息作为下拉框数据接口
        /// </summary>
        /// <returns></returns>
        public IActionResult GetSelectOpeions()
        {
            if (_menuInfoBll.GetSelectOption().Count > 0)
            {
                return Json(new AjaxResult
                {
                    code = 200,
                    msg = "获取菜单下拉框数据成功",
                    data = _menuInfoBll.GetSelectOption()
                });
            }
            return Json(new AjaxResult
            {
                code = 200,
                msg = "没有更多的下拉框数据了"
            });
        }
        /// <summary>
        /// 获取要展示的菜单信息数据接口
        /// </summary>
        /// <returns></returns>
        public IActionResult GetMenuInfoShow(FindMenuInfoDto findMenuInfoDto)
        {
            // 获取到总条数
            int MenuCount;
            List<MenuInfoDto> menuInfoDtos = _menuInfoBll.GetMenuInfo(findMenuInfoDto, out MenuCount);
            if (menuInfoDtos.Count >0)
            {
                return Json(new AjaxResult
                {
                    code = 0,
                    msg = "获取菜单信息数据成功",
                    data = menuInfoDtos,
                    count = MenuCount
                });
            }
            return Json(new AjaxResult
            {
                count = 500,
                msg = "没有更多的菜单数据可以获取了"
            });
        }
        /// <summary>
        /// 添加菜单信息接口
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AddMenuInfo(AddMenuInfoDto addMenuInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch (await _menuInfoBll.AddMenuInfoBll(addMenuInfoDto))
            {
                case MenuInfoEnums.AddMenuInfoSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "添加菜单信息成功";
                    break;
                case MenuInfoEnums.AddMenuInfoError:
                    ajaxResult.code = 400;
                    ajaxResult.msg = "添加菜单信息失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 修改菜单信息接口
        /// </summary>
        /// <param name="editMenuInfoDto">修改菜单信息dto</param>
        /// <returns></returns>
        public async Task<IActionResult> EditMenuInfo(EditMenuInfoDto editMenuInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch (await _menuInfoBll.EditMenuInfoBll(editMenuInfoDto))
            {
                case MenuInfoEnums.EditMenuInfoSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "修改菜单信息成功";
                    break;
                case MenuInfoEnums.EditMenuInfoError:
                    ajaxResult.code = 400;
                    ajaxResult.msg = "修改菜单信息失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 删除菜单信息接口
        /// </summary>
        /// <param name="IdList">要删除的菜单Id</param>
        /// <returns></returns>
        public async Task<IActionResult> DelMenuInfo(string[] IdList)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch(await _menuInfoBll.DelMenuInfoBll(IdList))
            {
                case MenuInfoEnums.DelmenuInfoSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "删除菜单信息成功";
                    break;
                case MenuInfoEnums.DelMenuInfoError:
                    ajaxResult.code = 400;
                    ajaxResult.msg = "删除菜单信息失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 获取修改页面需要的数据接口
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetEditMenuInfo(string Id)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 下拉框信息
            List<SelectOptionsDto> selectOptionsDtos = _menuInfoBll.GetSelectOption(Id);
            // 菜单信息
            MenuInfo menuInfo = await _menuInfoBll.FindMenuInfo(Id);
            if(menuInfo != null)
            {
                if (selectOptionsDtos.Count > 0)
                {
                    ajaxResult.code = 200;
                    ajaxResult.msg = "获取修改用户信息成功";
                    ajaxResult.data = new
                    {
                        menuInfo,
                        selectOptionsDtos
                    };
                    return Json(ajaxResult);
                }
            }
            ajaxResult.code = 500;
            ajaxResult.msg = "没有查询到对应的菜单信息";
            return Json(ajaxResult);
        }
        /// <summary>
        /// 获取绑定菜单穿梭框数据接口
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public IActionResult GetShuttleBoxMenuInfo(string RoleId)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 获取作为穿梭框的数据
            List<SelectOptionsDto> selectOptionsDtos = _menuInfoBll.GetSelectOption();
            // 获取当前角色已经绑定的菜单
            List<string> MenuIdList = _roleInfoBll.FindRoleBindMenuInfo(RoleId);
            ajaxResult.code = 200;
            ajaxResult.msg = "获取菜单穿梭框数据成功";
            ajaxResult.data = new
            {
                selectOptionsDtos,
                MenuIdList
            };
            return Json(ajaxResult);
        }
    }
}
