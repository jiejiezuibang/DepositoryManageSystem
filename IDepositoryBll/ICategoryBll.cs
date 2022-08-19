using Common.ResultEnums;
using Sister;
using Sister.Dtos.Category;
using Sister.Dtos.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDepositoryBll
{
    public interface ICategoryBll
    {
        Task<CategoryEnums> AddCategoryBll(string CategoryName, string Description);
        Task<CategoryEnums> DelCategoryBll(string[] IdList);
        Task<CategoryEnums> EditCategoryBll(string Id, string CategoryName, string Description);
        List<Category> GetShowCategoryInfo(FindCategoryDto findCategoryDto);
        List<SelectOptionsDto> GetSelectOptions();
        Task<Category> FindCategoryBll(string Id);
    }
}
