using Common.ResultEnums;
using IDepositoryBll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sister.Dtos.UserInfo;
using Sister.Dtos.WorkFlow_Instance;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoryServer.Controllers
{
    public class WorkFlow_InstanceController : Controller
    {
        // 构建工作流实例dal对象
        private readonly IWorkFlow_InstanceBll _workFlow_InstanceBll;
        // 构建工作流模板dal对象
        private readonly IWorkFlow_ModelBll _workFlow_ModelBll;
        // 构建耗材信息dal对象
        private readonly IConsumableInfoBll _consumableInfoBll;
        public WorkFlow_InstanceController(IWorkFlow_InstanceBll workFlow_InstanceBll, IWorkFlow_ModelBll workFlow_ModelBll,IConsumableInfoBll consumableInfoBll)
        {
            this._workFlow_InstanceBll = workFlow_InstanceBll;
            this._workFlow_ModelBll = workFlow_ModelBll;
            this._consumableInfoBll = consumableInfoBll;
        }
        /// <summary>
        /// 展示工作流实例主页面
        /// </summary>
        /// <returns></returns>
        public IActionResult WorkFlow_InstanceView()
        {
            return View();
        }
        /// <summary>
        /// 展示添加工作流实例页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddWorkFlow_InstanceView()
        {
            return View();
        }
        /// <summary>
        /// 获取要展示的工作流信息数据接口
        /// </summary>
        /// <param name="findWorkFlow_InstanceDto"></param>
        /// <returns></returns>
        public IActionResult GetShowWorkFlow_Instance(FindWorkFlow_InstanceDto findWorkFlow_InstanceDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 获取当前登录用户Id
            findWorkFlow_InstanceDto.userId = HttpContext.Session.GetString("userId");
            List<WorkFlow_InstanceDto> workFlow_InstanceDtos = _workFlow_InstanceBll.GetShowWorkFlow_InstanceBll(findWorkFlow_InstanceDto, out int Count);
            if (workFlow_InstanceDtos != null)
            {
                ajaxResult.code = 0;
                ajaxResult.msg = "获取工作流实例信息成功";
                ajaxResult.data = workFlow_InstanceDtos;
                return Json(ajaxResult);
            }
            ajaxResult.code = 500;
            ajaxResult.msg = "没有更多的工作流信息";
            return Json(ajaxResult);
        }
        /// <summary>
        ///  添加工作流实例信息接口
        /// </summary>
        /// <returns></returns>
        public IActionResult AddWorkFlow_Instance(AddWorkFlow_InstanceDto addWorkFlow_InstanceDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            addWorkFlow_InstanceDto.Creator =  HttpContext.Session.GetString("userId");
            switch(_workFlow_InstanceBll.AddWorkFlow_InstanceBll(addWorkFlow_InstanceDto,out string msg))
            {
                case WorkFlow_InstanceEnums.AddWorkFlow_InstanceSuccess:
                    ajaxResult.code = 200;
                    break;
                case WorkFlow_InstanceEnums.AddWorkFlow_InstanceError:
                    ajaxResult.code = 500;
                    break;
            }
            ajaxResult.msg = msg;
            return Json(ajaxResult);
        }
        /// <summary>
        /// 获取添加实例需要的下拉框数据接口
        /// </summary>
        /// <returns></returns>
        public IActionResult GetSelectOptionsData()
        {
            // 模板下拉框数据
            List<SelectOptionsDto> WselectOptionsDtos = _workFlow_ModelBll.GetSelectOptions();
            // 耗材下拉框数据
            List<SelectOptionsDto> CselectOptionsDtos = _consumableInfoBll.GetSelectOptions();
            return Json(new AjaxResult()
            {
                code = 200,
                msg = "获取下拉框数据成功",
                data = new
                {
                    WselectOptionsDtos,
                    CselectOptionsDtos
                }
            });
        }
    }
}
