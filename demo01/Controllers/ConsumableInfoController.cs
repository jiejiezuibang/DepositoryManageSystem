using Common.ResultEnums;
using IDepositoryBll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sister.Dtos.ConsumabelInfo;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoryServer.Controllers
{
    public class ConsumableInfoController : Controller
    {
        // 构建耗材信息bll对象
        private readonly IConsumableInfoBll _consumableInfoBll;
        // 构建耗材类别bll对象
        private readonly ICategoryBll _categoryBll;
        public ConsumableInfoController(IConsumableInfoBll consumableInfoBll, ICategoryBll categoryBll)
        {
            this._consumableInfoBll = consumableInfoBll;
            this._categoryBll = categoryBll;
        }
        /// <summary>
        /// 展示耗材信息主页面
        /// </summary>
        /// <returns></returns>
        public IActionResult ConsumableInfoView()
        {
            return View();
        }
        /// <summary>
        /// 展示耗材信息添加页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddConsumableInfoView()
        {
            return View();
        }
        /// <summary>
        /// 展示耗材信息修改页面
        /// </summary>
        /// <returns></returns>
        public IActionResult EditAConsumableInfoView()
        {
            return View();
        }
        /// <summary>
        /// 添加耗材信息接口
        /// </summary>
        /// <param name="addConsumabelInfoDto">添加耗材dto</param>
        /// <returns></returns>
        public async Task<IActionResult> AddConsumableInfo(AddConsumabelInfoDto addConsumabelInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch (await _consumableInfoBll.AddConsumabelInfoBll(addConsumabelInfoDto))
            {
                case ConsumableInfoEnums.AddConumableInfoSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "添加耗材信息成功";
                    break;
                case ConsumableInfoEnums.AddConumableInfoError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "添加耗材信息失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 删除耗材信息接口
        /// </summary>
        /// <param name="IdList">要删除的耗材信息Id</param>
        /// <returns></returns>
        public async Task<IActionResult> DelConsumableInfo(string[] IdList)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch(await _consumableInfoBll.DelConsumabelInfoBll(IdList))
            {
                case ConsumableInfoEnums.DelConumableInfoSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "删除耗材信息成功";
                    break;
                case ConsumableInfoEnums.DelConumableInfoError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "删除耗材信息失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 修改耗材信息接口
        /// </summary>
        /// <param name="editConsumabelInfoDto">修改耗材信息dto</param>
        /// <returns></returns>
        public async Task<IActionResult> EditConsumableInfo(EditConsumabelInfoDto editConsumabelInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch (await _consumableInfoBll.EditConsumabelInfoBll(editConsumabelInfoDto))
            {
                case ConsumableInfoEnums.EditCoumableInfoSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "修改耗材信息成功";
                    break;
                case ConsumableInfoEnums.EditCoumableInfoError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "修改耗材信息失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 获取要展示的耗材信息接口
        /// </summary>
        /// <param name="findConsumabelInfoDto">查询分页接口</param>
        /// <returns></returns>
        public IActionResult GetShowConsumabelInfo(FindConsumabelInfoDto findConsumabelInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            if(_consumableInfoBll.GetConsumabelInfoShow(findConsumabelInfoDto) != null)
            {
                ajaxResult.code = 0;
                ajaxResult.msg = "获取耗材信息成功";
                ajaxResult.data = _consumableInfoBll.GetConsumabelInfoShow(findConsumabelInfoDto);
                return Json(ajaxResult);
            }
            ajaxResult.code = 500;
            ajaxResult.msg = "获取耗材信息失败";
            return Json(ajaxResult);
        }
        /// <summary>
        /// 获取耗材信息数据接口
        /// </summary>
        /// <returns></returns>
        public IActionResult GetSelectOptions()
        {
            AjaxResult ajaxResult = new AjaxResult();
            if (_categoryBll.GetSelectOptions()!=null)
            {
                ajaxResult.code = 200;
                ajaxResult.msg = "获取耗材信息数据成功";
                return Json(ajaxResult);
            }
            ajaxResult.code = 500;
            ajaxResult.msg = "获取耗材信息数据失败";
            return Json(ajaxResult);
        }
        /// <summary>
        /// 获取要修改的耗材信息
        /// </summary>
        /// <param name="Id">耗材信息Id</param>
        /// <returns></returns>
        public async Task<IActionResult> GetEditConsumabelInfo(string Id)
        {
            return Json(new AjaxResult()
            {
                code = 200,
                msg = "获取当前耗材信息成功",
                data = await _consumableInfoBll.FindConsumabelInfoBll(Id)
            });
        }
        /// <summary>
        /// 耗材入库接口
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public async Task<IActionResult> Warehousing(IFormFile formFile)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 获取到当前登录用户Id
            string userId = HttpContext.Session.GetString("userId");
            switch(await _consumableInfoBll.WarehousingBll(formFile, userId))
            {
                case ConsumableInfoEnums.WarehousingSuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "入库成功";
                    break;
                case ConsumableInfoEnums.WarehousingError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "入库失败";
                    break;
                case ConsumableInfoEnums.FileTypeErro:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "文件格式错误，请上传excel文件";
                    break;
            }
            return Json(ajaxResult);
        }
    }
}
