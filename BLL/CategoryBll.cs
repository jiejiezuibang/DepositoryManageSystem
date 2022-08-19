using Common.ResultEnums;
using IDepositoryBll;
using IDepositoryDal;
using Sister;
using Sister.Dtos.Category;
using Sister.Dtos.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBll: ICategoryBll
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryBll(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }
        /// <summary>
        /// 添加耗材类别业务
        /// </summary>
        /// <param name="CategoryName">耗材类别名称</param>
        /// <param name="Description">描述</param>
        /// <returns></returns>
        public async Task<CategoryEnums> AddCategoryBll(string CategoryName,string Description)
        {
            // 创建耗材类别对象并赋值
            Category category = new Category()
            {
                Id = Guid.NewGuid().ToString(),
                CategoryName = CategoryName,
                Description = Description,
            };
            if(await _categoryDal.AddAsync(category))
            {
                return CategoryEnums.AddCategorySuccess;
            }
            return CategoryEnums.AddCategoryError;
        }
        /// <summary>
        /// 删除耗材类别业务
        /// </summary>
        /// <param name="IdList">要删除的耗材类别id</param>
        /// <returns></returns>
        public async Task<CategoryEnums> DelCategoryBll(string[] IdList)
        {
            if(IdList != null)
            {
                foreach(string Id in IdList)
                {
                    await _categoryDal.DelRemoveAsync(Id);
                }
                return CategoryEnums.DelCategorySuccess;
            }
            return CategoryEnums.DelCategoryError;
        }
        /// <summary>
        /// 修改耗材类别业务
        /// </summary>
        /// <param name="Id">耗材类别Id</param>
        /// <param name="CategoryName">耗材类别名称</param>
        /// <param name="Description">耗材描述</param>
        /// <returns></returns>
        public async Task<CategoryEnums> EditCategoryBll(string Id,string CategoryName, string Description)
        {
            Category category = await _categoryDal.GetAll().FindAsync(Id);
            if (category != null)
            {
                category.CategoryName = CategoryName;
                category.Description = Description;
                if (await _categoryDal.EditAsync(category))
                {
                    return CategoryEnums.EditCategorySuccess;
                }
            }
            return CategoryEnums.EditCategoryError;
        }
        /// <summary>
        /// 获取要展示耗材类别数据业务
        /// </summary>
        /// <param name="findCategoryDto">分页查询dto</param>
        /// <returns></returns>
        public List<Category> GetShowCategoryInfo(FindCategoryDto findCategoryDto)
        {
            IQueryable<Category> categories = _categoryDal.GetAll();
                
            if (findCategoryDto.CategoryName != null)
            {
                categories = categories.Where(c => c.CategoryName.Contains(findCategoryDto.CategoryName));
            }

            return categories.Skip(findCategoryDto.limit * (findCategoryDto.page - 1)).Take(findCategoryDto.limit).ToList();
        }
        /// <summary>
        /// 获取耗材类别作为下拉框数据
        /// </summary>
        public List<SelectOptionsDto> GetSelectOptions()
        {
            return _categoryDal.GetAll()
                .Select(c => new SelectOptionsDto
                {
                    Title = c.CategoryName,
                    Value = c.Id
                }).ToList();
        }
        /// <summary>
        /// 通过Id获取到耗材类别
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Category> FindCategoryBll(string Id)
        {
            return await _categoryDal.GetAll().FindAsync(Id);   
        }
    }
}
