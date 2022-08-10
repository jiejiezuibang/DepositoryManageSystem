using BLL;
using Common.ResultEnums;
using IDepositoryBll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sister;
using Sister.Dtos.UserInfo;
using Sister.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace demo01.Controllers
{
    public class UserInfoController : Controller
    {
        // 注入用户管理bll业务对象
        public readonly IUserInfoBll _userInfoBll;
        public UserInfoController(IUserInfoBll userInfoBll)
        {
            this._userInfoBll = userInfoBll;
        }
        /// <summary>
        /// 展示用户信息主页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UserInfoView()
        {
            return View();
        }
        /// <summary>
        /// 展示用户信息添加页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddUserInfoView()
        {
            return View();
        }
        /// <summary>
        /// 展示用户信息修改
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditUserInfoView()
        {
            return View();
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserInfoData(FindUserInfoDto findUserInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 返回获取的数据
            try
            {
                int userInfoCount = 0;
                if(_userInfoBll.GetUserInfoBll(findUserInfoDto, out userInfoCount).Count > 0)
                {
                    // 获取到当前登录账号并赋值给dto
                    findUserInfoDto.LoginAccount = HttpContext.Session.GetString("account");
                    ajaxResult.code = 0;
                    ajaxResult.msg = "获取用户信息成功";
                    ajaxResult.data = _userInfoBll.GetUserInfoBll(findUserInfoDto, out userInfoCount);
                    ajaxResult.count = userInfoCount;
                    return Json(ajaxResult);
                }
                else
                {
                    ajaxResult.code = 0;
                    ajaxResult.msg = "没有更多数据";
                    return Json(ajaxResult);
                }
            }
            catch
            {
                ajaxResult.code = 500;
                ajaxResult.msg = "获取用户信息数据失败,服务器发生错误";
                return Json(ajaxResult);
            }
        }
        /// <summary>
        /// 根据用户Id获取对应用户数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> FindIdUserInfo(string Id)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 获取查询的用户Id信息
            if(await _userInfoBll.FindIdUserInfo(Id)!= null)
            {
                ajaxResult.code = 200;
                ajaxResult.msg = "获取用户信息成功";
                ajaxResult.data = await _userInfoBll.FindIdUserInfo(Id);
                return Json(ajaxResult);
            }
            ajaxResult.code = 404;
            ajaxResult.msg = "获取用户信息失败";
            return Json(ajaxResult);
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="addUserInfoDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUserInfo(AddUserInfoDto addUserInfoDto)
        {
            // 校验前端数据获得状态
            AjaxResult ajaxResult = _userInfoBll.UserInfoDtoCheck(addUserInfoDto);
            // 判断前端数据是否有误
            if (ajaxResult.code == 200)
            {
                string msg;
                // 判断是否添加成功
                if (_userInfoBll.AddUserInfo(addUserInfoDto, out msg))
                {
                    ajaxResult.code = 200;
                    ajaxResult.msg = msg;
                    return Json(ajaxResult);
                }
                else
                {
                    ajaxResult.code = 500;
                    ajaxResult.msg = msg;
                    return Json(ajaxResult);
                }
            }
            else
            {
                return Json(ajaxResult);
            }
        }
        /// <summary>
        /// 单个或批量删除用户信息
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<AjaxResult> DelUserInfo(string[] IdList)
        {
            // 判断是否删除成功
            if (await _userInfoBll.DelUserInfoBll(IdList))
            {
                return new AjaxResult { code = 200, msg = "删除成功" };
            }
            return new AjaxResult { code = 500, msg = "删除失败" };
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditUserInfo(EditUserInfoDto editUserInfoDto)
        {
            // 校验前端数据获得状态
            AjaxResult ajaxResult = _userInfoBll.UserInfoDtoCheck(editUserInfoDto);
            // 判断数据校验是否通过
            if(ajaxResult.code == 200)
            {
                // 判断是否添加成功
                if (await _userInfoBll.UdpateUserInfo(editUserInfoDto))
                {
                    ajaxResult.code = 200;
                    ajaxResult.msg = "修改成功";
                    return Json(ajaxResult);
                }
                ajaxResult.code = 500;
                ajaxResult.msg = "修改失败";
                return Json(ajaxResult);
            }
            else
            {
                return Json(ajaxResult);
            }
        }
        /// <summary>
        /// 修改用户基本信息接口
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EditUserBaseInfo(EditUserBaseInfoDto editUserBaseInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 从session中获得到用户账号
            editUserBaseInfoDto.Account = HttpContext.Session.GetString("account");
            // 判断修改状态
            switch (await _userInfoBll.UpdateUserBaseInfo(editUserBaseInfoDto))
            {
                case UserInfoEnums.EditUserInfoSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "修改用户基本信息成功";
                    break;
                case UserInfoEnums.EmailErro:
                    ajaxResult.msg = "修改失败,邮箱格式错误";
                    break;
                case UserInfoEnums.PhoneNumError:
                    ajaxResult.msg = "修改失败，号码格式错误";
                    break;
                case UserInfoEnums.UserInfoNotExist:
                    ajaxResult.msg = "修改失败，用户信息不存在";
                    break;
            }
            return Json(ajaxResult);
        }
    }
}
