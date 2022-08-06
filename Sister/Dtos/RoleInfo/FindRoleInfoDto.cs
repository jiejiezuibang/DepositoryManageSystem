using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.RoleInfo
{
    public class FindRoleInfoDto: Pagination
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
    }
}
