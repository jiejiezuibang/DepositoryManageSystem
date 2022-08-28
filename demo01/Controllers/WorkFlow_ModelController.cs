using Common.ResultEnums;
using IDepositoryBll;
using Microsoft.AspNetCore.Mvc;
using Sister.Dtos.WorkFlow_Model;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoryServer.Controllers
{
    public class WorkFlow_ModelController : Controller
    {
        /// <summary>
        /// 构建工作流模板bll层对象
        /// </summary>
        private readonly IWorkFlow_ModelBll _workFlow_ModelBll;
        public WorkFlow_ModelController(IWorkFlow_ModelBll workFlow_ModelBll)
        {
            this._workFlow_ModelBll = workFlow_ModelBll;
        }
        /// <summary>
        /// 展示工作流模板主页面接口
        /// </summary>
        /// <returns></returns>
        public IActionResult WorkFlow_ModelView()
        {
            return View();
        }
        /// <summary>
        /// 展示添加工作流模板页面接口
        /// </summary>
        /// <returns></returns>
        public IActionResult AddWorkFlow_ModelView()
        {
            return View();
        }
        /// <summary>
        /// 展示修改工作流模板页面接口
        /// </summary>
        /// <returns></returns>
        public IActionResult EditWorkFlow_ModelView()
        {
            return View();
        }
        /// <summary>
        /// 添加工作流模板接口
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddWorkFlow_Model(string Title,string Description)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch (await _workFlow_ModelBll.AddWorkFlow_ModelBll(Title, Description))
            {
                case WorkFlow_ModelEnums.AddWorkFlow_ModelSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "添加工作流模板成功";
                    break;
                case WorkFlow_ModelEnums.AddWorkFlow_ModelError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "添加工作流模板失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 删除工作流模板接口
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        public async Task<IActionResult> DelWorkFlow_Model(string[] IdList)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch (await _workFlow_ModelBll.DelWorkFlow_ModelBll(IdList))
            {
                case WorkFlow_ModelEnums.DelWorkFlow_ModelSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "删除工作流模板成功";
                    break;
                case WorkFlow_ModelEnums.DelWorkFlow_ModelError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "删除工作流模板失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 修改工作流模板接口
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Title"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public async Task<IActionResult> EidtWorkFlow_ModelBll(string Id,string Title, string Description)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch (await _workFlow_ModelBll.EditWorkFlow_ModelBll(Id,Title, Description))
            {
                case WorkFlow_ModelEnums.EditWorkFlow_ModelSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "修改工作流模板成功";
                    break;
                case WorkFlow_ModelEnums.EditWorkFlow_ModelError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "修改工作流模板失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 获取工作流模板信息接口
        /// </summary>
        /// <param name="findWorkFlow_ModelDto"></param>
        /// <returns></returns>
        public IActionResult GetShowWorkFlow_Model(FindWorkFlow_ModelDto findWorkFlow_ModelDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            int Count;
            List< WorkFlow_ModelDto> workFlow_ModelDtos =  _workFlow_ModelBll.GetShowWorkFlow_ModelBll(findWorkFlow_ModelDto, out Count);
            ajaxResult.code = 0;
            ajaxResult.msg = "获取工作流数据成功";
            ajaxResult.data = workFlow_ModelDtos;
            ajaxResult.count = Count;
            return Json(ajaxResult);
        }
        /// <summary>
        /// 获取对应工作流模板接口
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> FindWorkFlow_Model(string Id)
        {
            AjaxResult ajaxResult = new AjaxResult();
            if(await _workFlow_ModelBll.FindWorkFlow_ModelBll(Id) != null)
            {
                ajaxResult.code = 200;
                ajaxResult.msg = "获取指定工作流模板成功";
                ajaxResult.data = await _workFlow_ModelBll.FindWorkFlow_ModelBll(Id);
                return Json(ajaxResult);
            }
            ajaxResult.code = 500;
            ajaxResult.msg = "获取指定工作流模板失败";
            return Json(ajaxResult);
        }
    }
}
