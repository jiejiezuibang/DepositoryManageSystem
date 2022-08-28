using Common.ResultEnums;
using IDepositoryBll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sister.Dtos.WorkFlow_InstanceStep;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoryServer.Controllers
{
    public class WorkFlow_InstanceStepController : Controller
    {
        // 构建工作流步骤bll
        private readonly IWorkFlow_InstanceStepBll _workFlow_InstanceStepBll;
        public WorkFlow_InstanceStepController(IWorkFlow_InstanceStepBll workFlow_InstanceStepBll)
        {
            this._workFlow_InstanceStepBll = workFlow_InstanceStepBll;
        }
        /// <summary>
        /// 展示工作流步骤主页面
        /// </summary>
        /// <returns></returns>
        public IActionResult WorkFlow_InstanceStepView()
        {
            return View();
        }
        /// <summary>
        /// 审核工作流步骤页面
        /// </summary>
        /// <returns></returns>
        public IActionResult EditWorkFlow_InstanceStepView()
        {
            return View();
        }
        /// <summary>
        /// 获取工作流步骤信息接口
        /// </summary>
        /// <param name="findWorkFlow_InstanceStepDto"></param>
        /// <returns></returns>
        public IActionResult GetShowWorkFlow_InstanceStep(FindWorkFlow_InstanceStepDto findWorkFlow_InstanceStepDto)
        {
           findWorkFlow_InstanceStepDto.UserId = HttpContext.Session.GetString("userId");
            AjaxResult ajaxResult = new AjaxResult();
            var datas = _workFlow_InstanceStepBll.GetShowWorkFlow_InstanceStepBll(findWorkFlow_InstanceStepDto, out int Count);
            if (datas != null)
            {
                ajaxResult.code = 0;
                ajaxResult.msg = "获取工作流步骤信息成功";
                ajaxResult.data = datas;
                ajaxResult.count = Count;
                return Json(ajaxResult);
            }
            ajaxResult.code = 500;
            ajaxResult.msg = "没有更多工作流步骤信息获取了";
            return Json(ajaxResult);
        }
        /// <summary>
        /// 通过Id获取对应工作流信息接口
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult FindWorkFlow_InstanceStep(string Id)
        {
            if (_workFlow_InstanceStepBll.FindWorkFlow_InstanceStepBll(Id) != null)
            {
                return Json(new AjaxResult()
                {
                    code = 200,
                    msg = "获取对应工作流步骤信息成功",
                    data = _workFlow_InstanceStepBll.FindWorkFlow_InstanceStepBll(Id)
                });
                
            }
            return Json(new AjaxResult()
            {
                code = 500,
                msg = "获取对应工作流步骤信息失败",
            });
        }
        /// <summary>
        /// 审核工作流步骤接口
        /// </summary>
        /// <param name="eidtWorkFlow_InstanceStepDto"></param>
        /// <returns></returns>
        public IActionResult EditWorkFlow_InstanceStep(EidtWorkFlow_InstanceStepDto eidtWorkFlow_InstanceStepDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch(_workFlow_InstanceStepBll.EidtWorkFlow_InstanceStepBll(eidtWorkFlow_InstanceStepDto, out string msg))
            {
                case WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepSuccess:
                    ajaxResult.code = 200;
                    break;
                case WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError:
                    ajaxResult.code = 500;
                    break;
                case WorkFlow_InstanceStepEnums.AddWorkFlow_InstanceStepError:
                    ajaxResult.code = 500;
                    break;
            }
            ajaxResult.msg = msg;
            return Json(ajaxResult);
        }
    }
}
