using Common.ResultEnums;
using IDepositoryBll;
using Microsoft.AspNetCore.Mvc;
using Sister.Dtos.Category;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoryServer.Controllers
{
    public class CategoryController : Controller
    {
        // 注入耗材类别bll对象
        private readonly ICategoryBll _categoryBll;
        public CategoryController(ICategoryBll categoryBll)
        {
            this._categoryBll = categoryBll;
        }
        /// <summary>
        /// 展示耗材类别主页面
        /// </summary>
        /// <returns></returns>
        public IActionResult CategoryView()
        {
            return View();
        }
        /// <summary>
        /// 展示耗材类别添加页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddCategoryView()
        {
            return View();
        }
        /// <summary>
        /// 展示耗材类别修改页面
        /// </summary>
        /// <returns></returns>
        public IActionResult EditCategoryView()
        {
            return View();
        }
        /// <summary>
        /// 添加耗材类别接口
        /// </summary>
        /// <param name="CategoryName">类别名称</param>
        /// <param name="Description">描述</param>
        /// <returns></returns>
        public async Task<IActionResult> AddCategory(string CategoryName,string Description)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch (await _categoryBll.AddCategoryBll(CategoryName, Description))
            {
                case CategoryEnums.AddCategorySuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "添加耗材类别成功";
                    break;
                case CategoryEnums.AddCategoryError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "添加耗材类别失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 删除耗材接接口
        /// </summary>
        /// <param name="IdList">要删除的耗材信息Id</param>
        /// <returns></returns>
        public async Task<IActionResult> DelCategory(string[] IdList)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch(await _categoryBll.DelCategoryBll(IdList))
            {
                case CategoryEnums.DelCategorySuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "删除耗材类别成功";
                    break;
                case CategoryEnums.DelCategoryError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "删除耗材类别失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 修改耗材类别成功
        /// </summary>
        /// <param name="Id">耗材类别id</param>
        /// <param name="CategoryName">耗材类别名称</param>
        /// <param name="Description">描述</param>
        /// <returns></returns>
        public async Task<IActionResult> EditCategory(string Id, string CategoryName, string Description)
        {
            AjaxResult ajaxResult = new AjaxResult();
            switch (await _categoryBll.EditCategoryBll(Id, CategoryName, Description))
            {
                case CategoryEnums.EditCategorySuccess:
                    ajaxResult.code = 200;
                    ajaxResult.msg = "修改耗材类别成功";
                    break;
                case CategoryEnums.EditCategoryError:
                    ajaxResult.code = 500;
                    ajaxResult.msg = "修改耗材类别失败";
                    break;
            }
            return Json(ajaxResult);
        }
        /// <summary>
        /// 获取到要展示的耗材类别
        /// </summary>
        /// <param name="findCategoryDto"></param>
        /// <returns></returns>
        public IActionResult GetShowCategory(FindCategoryDto findCategoryDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            if(_categoryBll.GetShowCategoryInfo(findCategoryDto) != null)
            {
                ajaxResult.code = 0;
                ajaxResult.msg = "获取耗材类别信息成功";
                ajaxResult.data = _categoryBll.GetShowCategoryInfo(findCategoryDto);
                return Json(ajaxResult);
            }
            ajaxResult.code = 500;
            ajaxResult.msg = "获取耗材类别信息失败";
            return Json(ajaxResult);
        }
        /// <summary>
        /// 获取当前要修改耗材类别信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> FindCategory(string Id)
        {
            AjaxResult ajaxResult = new AjaxResult();
            if (await _categoryBll.FindCategoryBll(Id)!=null)
            {
                ajaxResult.code = 200;
                ajaxResult.msg = "获取耗材类别信息成功";
                ajaxResult.data = await _categoryBll.FindCategoryBll(Id);
                return Json(ajaxResult);
            }
            ajaxResult.code = 500;
            ajaxResult.msg = "获取耗材类别信息失败";
            return Json(ajaxResult);
        }
    }
}
