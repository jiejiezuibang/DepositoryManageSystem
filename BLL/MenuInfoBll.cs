using Common.ResultEnums;
using IDepositoryBll;
using IDepositoryDal;
using Microsoft.EntityFrameworkCore;
using Sister;
using Sister.Dtos.MenuInfo;
using Sister.Dtos.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MenuInfoBll: IMenuInfoBll
    {
        // 注入菜单信息dal对象
        private readonly IMenuInfoDal _menuInfoDal;
        // 注入用户信息dal对象
        private readonly IUserInfoDal _userInfoDal;
        // 注入用户角色信息dal对象
        private readonly IR_UserInfo_RoleInfoDal _r_UserInfo_RoleInfoDal;
        // 注入角色权限信息dal对象
        private readonly IR_RoleInfo_MenuInfoDal _r_RoleInfo_MenuInfoDal;
        public MenuInfoBll(IMenuInfoDal menuInfoDal, IUserInfoDal userInfoDal, IR_UserInfo_RoleInfoDal r_UserInfo_RoleInfoDal,IR_RoleInfo_MenuInfoDal r_RoleInfo_MenuInfoDal)
        {
            this._menuInfoDal = menuInfoDal;
            this._userInfoDal = userInfoDal;
            this._r_UserInfo_RoleInfoDal = r_UserInfo_RoleInfoDal;
            this._r_RoleInfo_MenuInfoDal = r_RoleInfo_MenuInfoDal;
        }
        /// <summary>
        /// 查询分页菜单信息
        /// </summary>
        /// <param name="findMenuInfoDto"></param>
        /// <param name="MenuCount"></param>
        /// <returns></returns>
        public List<MenuInfoDto> GetMenuInfo(FindMenuInfoDto findMenuInfoDto,out int MenuCount)
        {
            // 获取没有删除的菜单信息
            IQueryable<MenuInfoDto> menuInfoDtos = (from a in _menuInfoDal.GetAll()
                .Where(m => !m.IsDelete)
                .OrderBy(m => m.Sort)
                                                   join b in _menuInfoDal.GetAll()
                                                   on a.Id equals b.ParentId
                                                   into c from d in c.DefaultIfEmpty()
                                                   select new MenuInfoDto
                                                   {
                                                       Title = a.Title,
                                                       Description = a.Description,
                                                       Level = a.Level,
                                                       Sort = a.Sort,
                                                       Href = a.Href,
                                                       ParentName = d.Title,
                                                       Icon = a.Icon,
                                                       Target = a.Target,
                                                       CreateTime = a.CreateTime.ToString("yyyy-MM-ss HH:mm:ss")
                                                   }
            );
            // 查询
            if(findMenuInfoDto.Title != null)
            {
                menuInfoDtos = menuInfoDtos.Where(m => m.Title.Contains(findMenuInfoDto.Title));
            }
            // 总条数
            MenuCount = menuInfoDtos.Count();
            // 分页
            return menuInfoDtos.Skip(findMenuInfoDto.limit * (findMenuInfoDto.page - 1)).Take(findMenuInfoDto.limit).ToList();
        }
        /// <summary>
        /// 添加菜单信息业务
        /// </summary>
        /// <param name="addMenuInfoDto"></param>
        /// <returns></returns>
        public async Task<MenuInfoEnums> AddMenuInfoBll(AddMenuInfoDto addMenuInfoDto)
        {
            MenuInfo menuInfo = new MenuInfo
            {
                Id = Guid.NewGuid().ToString(),
                Title = addMenuInfoDto.Title,
                Description = addMenuInfoDto.Description,
                Level = addMenuInfoDto.Level,
                Sort = addMenuInfoDto.Sort,
                Href = addMenuInfoDto.Href,
                ParentId = addMenuInfoDto.ParentId,
                Icon = addMenuInfoDto.Icon,
                Target = addMenuInfoDto.Target,
                CreateTime = DateTime.Now
            };
            // 判断是否添加成功
            if(await _menuInfoDal.AddAsync(menuInfo))
            {
                return MenuInfoEnums.AddMenuInfoSuccess;
            }
            return MenuInfoEnums.AddMenuInfoError;
        }
        /// <summary>
        /// 修改菜单信息业务
        /// </summary>
        /// <returns></returns>
        public async Task<MenuInfoEnums> EditMenuInfoBll(EditMenuInfoDto editMenuInfoDto)
        {
            // 查询到要修改的对象
            MenuInfo menuInfo = await _menuInfoDal.GetAll().FindAsync(editMenuInfoDto.Id);
            // 重新赋值
            menuInfo.Title = editMenuInfoDto.Title;
            menuInfo.Description = editMenuInfoDto.Description;
            menuInfo.Level = editMenuInfoDto.Level;
            menuInfo.Sort = editMenuInfoDto.Sort;
            menuInfo.Href = editMenuInfoDto.Href;
            menuInfo.ParentId = editMenuInfoDto.ParentId;
            menuInfo.Icon = editMenuInfoDto.Icon;
            menuInfo.Target = editMenuInfoDto.Target;
            // 判断是否修改成功
            if(await _menuInfoDal.EditAsync(menuInfo))
            {
                return MenuInfoEnums.EditMenuInfoSuccess;
            }
            return MenuInfoEnums.EditMenuInfoError;
        }
        /// <summary>
        /// 删除菜单信息业务
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        public async Task<MenuInfoEnums> DelMenuInfoBll(string[] IdList)
        {
            // 判断是否删除成功
            if(await _menuInfoDal.DelAsync(IdList))
            {
                return MenuInfoEnums.DelmenuInfoSuccess;
            }
            return MenuInfoEnums.DelMenuInfoError;
        }
        /// <summary>
        /// 获取菜单信息作为下拉框数据业务
        /// </summary>
        public List<SelectOptionsDto> GetSelectOption()
        {
            return _menuInfoDal.GetAll().Where(m => !m.IsDelete).Select(m => new SelectOptionsDto { Value=m.Id,Title=m.Title}).ToList();
        }
        /// <summary>
        /// 获取菜单信息作为下拉框数据业务
        /// </summary>
        /// <param name="Id">菜单信息</param>
        /// <returns></returns>
        public List<SelectOptionsDto> GetSelectOption(string Id)
        {
            return _menuInfoDal.GetAll().Where(m => !m.IsDelete&&m.Id !=Id&&m.ParentId!=Id).Select(m => new SelectOptionsDto { Value = m.Id, Title = m.Title }).ToList();
        }
        /// <summary>
        /// 通过菜单Id获取到指定菜单信息
        /// </summary>
        /// <param name="Id">菜单Id</param>
        /// <returns></returns>
        public async Task<MenuInfo> FindMenuInfo(string Id)
        {
            return await _menuInfoDal.GetAll().FindAsync(Id);
        }
        /// <summary>
        /// 获取要侧边栏要展示的数据
        /// </summary>
        /// <returns></returns>
        public List<HomeMenuDto> GetMenuData(string UserId)
        {
            // 获取到用户拥有的角色
            List<string> RoleIds  = _r_UserInfo_RoleInfoDal.GetAll().Where(r => r.UserId.Equals(UserId)).Select(r => r.RoleId).ToList();
            // 查询角色拥有啥菜单
            List<string> MenuIds = _r_RoleInfo_MenuInfoDal.GetAll().Where(r => RoleIds.Contains(r.RoleId)).Select(r => r.MenuId).ToList(); ;

            return _menuInfoDal.GetAll().OrderBy(m => m.Sort).Where(m => !m.IsDelete && MenuIds.Contains(m.Id)).Select(m => new HomeMenuDto
            {
                Title = m.Title,
                Href = m.Href,
                Target = m.Target,
                Icon = m.Icon
            }).ToList();
        }
    }
}
