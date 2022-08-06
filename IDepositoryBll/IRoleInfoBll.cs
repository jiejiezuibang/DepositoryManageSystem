using Common.ResultEnums;
using Microsoft.EntityFrameworkCore;
using Sister;
using Sister.Dtos.RoleInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDepositoryBll
{
    public interface IRoleInfoBll
    {
        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="roleInfo">要添加的角色信息</param>
        /// <returns></returns>
        Task<RoleInfoEnums> AddBllAsync(AddRoleInfoDto addRoleInfoDto);
        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="IdList">要删除角色的Id</param>
        /// <returns></returns>
        Task<RoleInfoEnums> DelBllAsync(string[] IdList);
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="roleInfo">要修改的角色信息</param>
        /// <returns></returns>
        Task<RoleInfoEnums> EditBllAsync(EditRoleInfoDto editRoleInfoDto);
        /// <summary>
        /// 获取展示的角色信息(包含分页和搜索)
        /// </summary>
        /// <param name="findRoleInfoDto">查询和分页条件</param>
        /// <param name="RoleInfoCount">多余返回的角色总条数</param>
        /// <returns></returns>
        List<RoleInfoDto> GetShowBll(FindRoleInfoDto findRoleInfoDto, out int RoleInfoCount);
        /// <summary>
        /// 根据角色Id获取指定角色信息
        /// </summary>
        /// <param name="Id">角色Id</param>
        /// <returns></returns>
        Task<RoleInfo> FindRoleInfo(string Id);
    }
}
