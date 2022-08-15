using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.R_UserInfo_RoleInfo
{
    /// <summary>
    /// 绑定用户角色dto
    /// </summary>
    public class BindUserDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string[] UserId { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        public string RoleId { get; set; }

    }
}
