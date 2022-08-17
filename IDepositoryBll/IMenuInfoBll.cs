using Common.ResultEnums;
using Sister;
using Sister.Dtos.MenuInfo;
using Sister.Dtos.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDepositoryBll
{
    /// <summary>
    /// 菜单信息bll接口
    /// </summary>
    public interface IMenuInfoBll
    {
        List<MenuInfoDto> GetMenuInfo(FindMenuInfoDto findMenuInfoDto, out int MenuCount);
        Task<MenuInfoEnums> AddMenuInfoBll(AddMenuInfoDto addMenuInfoDto);
        Task<MenuInfoEnums> EditMenuInfoBll(EditMenuInfoDto editMenuInfoDto);
        Task<MenuInfoEnums> DelMenuInfoBll(string[] IdList);
        List<SelectOptionsDto> GetSelectOption();
        Task<MenuInfo> FindMenuInfo(string Id);
        List<SelectOptionsDto> GetSelectOption(string Id);
        List<HomeMenuDto> GetMenuData(string UserId);
    }
}
