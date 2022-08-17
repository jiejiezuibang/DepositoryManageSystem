using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultEnums
{
    /// <summary>
    /// 角色管理板块枚举
    /// </summary>
    public enum RoleInfoEnums
    {
        /// <summary>
        /// 添加角色成功
        /// </summary>
        AddRoleInfoSuccess, 
        /// <summary>
        /// 添加角色失败
        /// </summary>
        AddRoleInfoError,
        /// <summary>
        /// 删除角色成功
        /// </summary>
        DelRoleInfoSuccess,
        /// <summary>
        /// 删除角色失败
        /// </summary>
        DelRoleInfoError,
        /// <summary>
        /// 修改角色成功
        /// </summary>
        EditRoleInfoSuccess,
        /// <summary>
        /// 修改角色失败
        /// </summary>
        EditRoleInfoError,
        /// <summary>
        /// 角色名为空
        /// </summary>
        RoleInfoRoleNameNulll,
        /// <summary>
        /// 角色名已存在
        /// </summary>
        RoleNameExist,
        /// <summary>
        /// 角色不存在
        /// </summary>
        RoleNotExist,
        /// <summary>
        /// 数据校验通过
        /// </summary>
        CheckSuccess,
        /// <summary>
        /// 操作角色失败
        /// </summary>
        RoleInfoError,
        /// <summary>
        /// 角色Id为空
        /// </summary>
        RoleIdIsNull,
        /// <summary>
        /// 绑定菜单成功
        /// </summary>
        BindMenuSuccess,
        /// <summary>
        /// 绑定菜单失败
        /// </summary>
        BindMenuError,
    }
}
