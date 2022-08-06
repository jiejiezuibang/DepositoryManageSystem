using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.RoleInfo
{
    public class EditRoleInfoDto
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public string Id { get; set; }
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
