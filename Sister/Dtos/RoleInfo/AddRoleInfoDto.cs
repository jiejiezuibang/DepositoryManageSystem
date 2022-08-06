using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.RoleInfo
{
    /// <summary>
    /// 添加角色dto
    /// </summary>
    public class AddRoleInfoDto
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; set; }
    }
}
