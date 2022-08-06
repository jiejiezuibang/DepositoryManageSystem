using BLL;
using Common.ResultEnums;
using IDepositoryBll;
using Microsoft.AspNetCore.Mvc;
using Sister.Dtos.DeparmentInfo;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoryServer.Controllers
{
    public class DepartmentController : Controller
    {
        // 注入部门管理bll层业务对象
        private readonly IDepartmentInfoBll _departmentInfoBll;
        public DepartmentController(IDepartmentInfoBll departmentInfoBll)
        {
            this._departmentInfoBll = departmentInfoBll;
        }
        /// <summary>
        /// 展示部门管理主页面接口
        /// </summary>
        /// <returns></returns>
        public IActionResult DepartmentIndex()
        {
            return View();
        }
        /// <summary>
        /// 展示部门添加页面接口
        /// </summary>
        /// <returns></returns>
        public IActionResult AddDeparmentInfoView()
        {
            return View();
        }
        /// <summary>
        /// 展示部门修改页面接口
        /// </summary>
        /// <returns></returns>
        public IActionResult EditDeprtmentInfoView()
        {
            return View();
        }
        /// <summary>
        /// 获取部门信息接口
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
        /// <summary>
        /// 根据部门Id获取指定的部门信息
        /// </summary>
        /// <param name="Id">部门Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FindIdDepartmentInfo(string Id)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 判断是否获取到指定部门
            if(await _departmentInfoBll.FindDepartmentInfoBll(Id) != null)
            {
                ajaxResult.code = 200;
                ajaxResult.msg = "获取指定部门成功";
                ajaxResult.data = await _departmentInfoBll.FindDepartmentInfoBll(Id);
                return Json(ajaxResult);
            }
            ajaxResult.code = 500;
            ajaxResult.msg = "获取指定部门失败";
            return Json(ajaxResult);
        }
        /// <summary>
        /// 获取数据并且分页与查询接口
        /// </summary>
        /// <param name="findDeparmentInfoDto">部门查询分页dto</param>
        /// <returns></returns>
        public IActionResult GetDepartmentInfoShow(FindDeparmentInfoDto findDeparmentInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            List<DeparmentInfoDto> deparmentInfoDto = _departmentInfoBll.GetDeparmentInfoDtosShowBll(findDeparmentInfoDto, out int DeparmentCount);
            if (deparmentInfoDto.Count > 0)
            {
                ajaxResult.code = 0;
                ajaxResult.msg = "获取部门数据成功";
                ajaxResult.data = deparmentInfoDto;
                ajaxResult.count = DeparmentCount;
                return Json(ajaxResult);
            }
            else
            {
                ajaxResult.code = 0;
                ajaxResult.msg = "没有更多数据了";
                return Json(ajaxResult);
            }
        }
        /// <summary>
        /// 添加部门信息接口
        /// </summary>
        /// <param name="addDeparmentInfoDto"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddDeparmentInfo(AddDeparmentInfoDto addDeparmentInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 校验数据是否符合
            if(_departmentInfoBll.AddDeparmentDataCheck(addDeparmentInfoDto).code != 200)
            {
                return Json(_departmentInfoBll.AddDeparmentDataCheck(addDeparmentInfoDto));
            }
            switch (await _departmentInfoBll.AddDeparmentInfoBll(addDeparmentInfoDto))
            {
                case DeparmentEnums.AddDeparmentSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "添加部门成功";
                    break;
                case DeparmentEnums.AddDeparmentError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "添加部门失败";
                    break;
                case DeparmentEnums.AddDeparmentNameExist:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "添加失败，部门以存在";
                    break;
                case DeparmentEnums.DeparmentError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "添加部门失败，服务器发生错误";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 修改部门信息接口
        /// </summary>
        /// <param name="editDeparmentInfoDto">修改部门信息dto</param>
        /// <returns></returns>
        public async Task<IActionResult> EditDepartementInfo(EditDeparmentInfoDto editDeparmentInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 校验前端传递的修改数据是否合格
            if(_departmentInfoBll.EditDeparmentDataCheck(editDeparmentInfoDto).code != 200)
            {
                return Json(ajaxResult);
            }
            // 判断是否修改成功
            switch (await _departmentInfoBll.EditDeparmentInfoBll(editDeparmentInfoDto))
            {
                case DeparmentEnums.EditDeparmentSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "修改部门信息成功";
                    break;
                case DeparmentEnums.EditDeparmentError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "修改部门信息失败";
                    break;
                case DeparmentEnums.DeparmentError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "添加部门失败，服务器发生错误";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 删除多个部门或单个部门接口
        /// </summary>
        /// <param name="IdList">部门id集合</param>
        /// <returns></returns>
        public async Task<IActionResult> DelDepartmentInfo(string[] IdList)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 判断是否删除成功
            switch(await _departmentInfoBll.DelDeparmentInfoBll(IdList))
            {
                case DeparmentEnums.DelDeparmentSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "删除部门信息成功";
                    break;
                case DeparmentEnums.DelDeparmentError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "删除部门信息失败";
                    break;
                case DeparmentEnums.DeparmentError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "删除部门信息失败，服务器发生异常";
                    break;
            }
            return Json(ajaxResult);
        }
    }
}
