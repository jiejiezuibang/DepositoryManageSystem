using Common.ResultEnums;
using IDepositoryBll;
using IDepositoryDal;
using Microsoft.EntityFrameworkCore;
using Sister;
using Sister.Dtos.RoleInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 角色管理逻辑层
    /// </summary>
    public class RoleInfoBll : IRoleInfoBll
    {
        /// <summary>
        /// 注入角色数据交互对象
        /// </summary>
        private readonly IRoleInfoDal _roleInfoDal;
        /// <summary>
        /// 注入菜单数据交互对象
        /// </summary>
        private readonly IR_RoleInfo_MenuInfoDal _r_RoleInfo_MenuInfoDal;
        public RoleInfoBll(IRoleInfoDal roleInfoDal, IR_RoleInfo_MenuInfoDal r_RoleInfo_MenuInfoDal)
        {
            this._roleInfoDal = roleInfoDal;
            this._r_RoleInfo_MenuInfoDal = r_RoleInfo_MenuInfoDal;
        }
        /// <summary>
        /// 删除角色信息业务
        /// </summary>
        /// <param name="IdList">要删除的角色Id</param>
        /// <returns></returns>
        public async Task<RoleInfoEnums> DelBllAsync(string[] IdList)
        {
            // 判断是否删除成功
            if(await _roleInfoDal.DelAsync(IdList))
            {
                return RoleInfoEnums.DelRoleInfoSuccess;
            }
            return RoleInfoEnums.DelRoleInfoError;
        }

        /// <summary>
        /// 获取需要展示的角色信息(分页与查询)业务
        /// </summary>
        /// <param name="findRoleInfoDto">查询与分页角色dto</param>
        /// <param name="RoleInfoCount">多余返回的角色信息总条数</param>
        /// <returns></returns>
        public List<RoleInfoDto> GetShowBll(FindRoleInfoDto findRoleInfoDto, out int RoleInfoCount)
        {
            IQueryable <RoleInfoDto> roleInfoDtos = from a in _roleInfoDal.GetAll()
               .Where(r => !r.IsDelete)     // 过滤掉删除的角色
               .OrderByDescending(r => r.CreateTime)    // 降序排序
                                         select new RoleInfoDto
                                         {
                                             Id = a.Id,
                                             RoleName = a.RoleName,
                                             Description = a.Description,
                                             CreateTime = a.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                                         };
            // 获取角色总条数
            RoleInfoCount = roleInfoDtos.Count();
            // 查询搜索
            if (findRoleInfoDto.RoleName != null)
            {
                roleInfoDtos = roleInfoDtos.Where(r => r.RoleName.Contains(findRoleInfoDto.RoleName));
            }
            // 分页并且返回数据
            return roleInfoDtos.Skip(findRoleInfoDto.limit * (findRoleInfoDto.page - 1)).Take(findRoleInfoDto.limit).ToList();
        }
        /// <summary>
        /// 校验添加角色dto
        /// </summary>
        /// <param name="addRoleInfoDto">添加角色dto</param>
        /// <returns></returns>
        public RoleInfoEnums AddRoleInfoCheck(AddRoleInfoDto addRoleInfoDto)
        {
            // 判断角色名称是否为空
            if (string.IsNullOrEmpty(addRoleInfoDto.RoleName))
            {
                return RoleInfoEnums.RoleInfoRoleNameNulll;
            }
            return RoleInfoEnums.CheckSuccess;
        }
        /// <summary>
        /// 添加角色信息业务
        /// </summary>
        /// <param name="addRoleInfoDto"></param>
        /// <returns></returns>
        public async Task<RoleInfoEnums> AddBllAsync(AddRoleInfoDto addRoleInfoDto)
        {
            // 校验数据
            if(AddRoleInfoCheck(addRoleInfoDto) != RoleInfoEnums.CheckSuccess)
            {
                return AddRoleInfoCheck(addRoleInfoDto);
            }
            // 判断角色名是否存在
            if(await _roleInfoDal.GetAll().FirstOrDefaultAsync(r => r.RoleName == addRoleInfoDto.RoleName) != null)
            {
                return RoleInfoEnums.RoleNameExist;
            }
            // 创建角色对象并赋值
            RoleInfo roleInfo = new RoleInfo()
            {
                Id = Guid.NewGuid().ToString(),
                RoleName = addRoleInfoDto.RoleName,
                Description = addRoleInfoDto.Description,
                CreateTime = DateTime.Now,
            };
            // 判断是否添加成功
            if(await _roleInfoDal.AddAsync(roleInfo))
            {
                return RoleInfoEnums.AddRoleInfoSuccess;
            }
            return RoleInfoEnums.AddRoleInfoError;
        }
        /// <summary>
        /// 校验修改角色dto
        /// </summary>
        /// <param name="editRoleInfoDto">修改角色dto</param>
        /// <returns></returns>
        public RoleInfoEnums EditRoleInfoCheck(EditRoleInfoDto editRoleInfoDto)
        {
            // 判断角色名称是否为空
            if (string.IsNullOrEmpty(editRoleInfoDto.RoleName))
            {
                return RoleInfoEnums.RoleInfoRoleNameNulll;
            }
            return RoleInfoEnums.CheckSuccess;
        }
        /// <summary>
        /// 修改角色信息业务
        /// </summary>
        /// <param name="editRoleInfoDto">修改角色dto</param>
        /// <returns></returns>
        public async Task<RoleInfoEnums> EditBllAsync(EditRoleInfoDto editRoleInfoDto)
        {
            // 判断角色是否存在
            RoleInfo roleInfo = await _roleInfoDal.GetAll().FirstOrDefaultAsync(r => r.Id == editRoleInfoDto.Id);
            if (roleInfo != null)
            {
                // 校验修改角色dto
                if (EditRoleInfoCheck(editRoleInfoDto) != RoleInfoEnums.CheckSuccess)
                    return EditRoleInfoCheck(editRoleInfoDto);
                // 给角色信息重新赋值
                roleInfo.RoleName = editRoleInfoDto.RoleName;
                roleInfo.Description = editRoleInfoDto.Description;
                // 判断是否修改成功
                if(await _roleInfoDal.EditAsync(roleInfo))
                {
                    return RoleInfoEnums.EditRoleInfoSuccess;
                }
                return RoleInfoEnums.EditRoleInfoError;
            }
            return RoleInfoEnums.RoleNotExist;
        }
        /// <summary>
        /// 根据角色Id获取指定角色信息
        /// </summary>
        /// <param name="Id">角色Id</param>
        /// <returns></returns>
        public async Task<RoleInfo> FindRoleInfo(string Id)
        {
            return await _roleInfoDal.GetAll().FindAsync(Id);
        }
        /// <summary>
        /// 查询当前用户绑定的菜单Id
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public List<string> FindRoleBindMenuInfo(string RoleId)
        {
            return _r_RoleInfo_MenuInfoDal.GetAll().Where(r =>  r.RoleId == RoleId).Select(r => r.MenuId).ToList();
        }
        /// <summary>
        /// 绑定菜单业务
        /// </summary>
        /// <param name="RoleId">角色Id</param>
        /// <param name="MenuIds">菜单Id</param>
        public async Task<RoleInfoEnums> BindMenuInfo(string RoleId, string[] MenuIds)
        {
            // 判断角色Id是否为空
            if(RoleId == null)
            {
                return RoleInfoEnums.RoleIdIsNull;
            }

            // 解绑
            //await _r_RoleInfo_MenuInfoDal.GetAll()
            //    .Where(r => r.RoleId.Equals(RoleId))
            //    .ForEachAsync(async rList =>
            //    {
            //        if(MenuIds != null)
            //        {
            //            if (!MenuIds.Any(m => m.Equals(rList.MenuId)))
            //            {
            //                await _r_RoleInfo_MenuInfoDal.DelRemoveAsync(rList.Id);
            //            }
            //        }
            //        else
            //        {
            //            await _r_RoleInfo_MenuInfoDal.DelRemoveAsync(rList.Id);
            //        }
            //    });

            // 循环遍历角色菜单信息
            foreach(var MenuInfo in _r_RoleInfo_MenuInfoDal.GetAll().Where(r => r.RoleId.Equals(RoleId)).ToList())
            {
                // 判断是否要绑定菜单
                if(MenuIds != null)
                {
                    // 判断菜单Id是否需要绑定
                    if(!MenuIds.Any(m => m.Equals(MenuInfo.MenuId)))
                    {
                        await _r_RoleInfo_MenuInfoDal.DelRemoveAsync(MenuInfo.Id);
                    }
                }
                else
                {
                    await _r_RoleInfo_MenuInfoDal.DelRemoveAsync(MenuInfo.Id);
                }
            }




            // 绑定
            if (MenuIds.Length > 0)
            {
                // 循环要添加菜单Id
                foreach (string MenuId in MenuIds)
                {
                    // 判断该菜单Id当前角色是否拥有
                    if (!_r_RoleInfo_MenuInfoDal.GetAll()
                        .Where(r => r.RoleId.Equals(RoleId))
                        .Any(r => r.MenuId.Equals(MenuId)))
                    {
                        // 创建要添加的对象并赋值
                        R_RoleInfo_MenuInfo r_RoleInfo_MenuInfo = new R_RoleInfo_MenuInfo
                        {
                            Id = Guid.NewGuid().ToString(),
                            RoleId = RoleId,
                            MenuId = MenuId,
                            CreateTime = DateTime.Now
                        };
                        // 绑定菜单
                        await _r_RoleInfo_MenuInfoDal.AddAsync(r_RoleInfo_MenuInfo);
                    }
                }
            }


            return RoleInfoEnums.BindMenuSuccess;
        }
    }
}
