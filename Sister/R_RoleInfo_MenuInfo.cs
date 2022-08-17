using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sister
{
    /// <summary>
    /// 角色权限表
    /// </summary>
    public class R_RoleInfo_MenuInfo : BaseSister
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string RoleId { get; set; }
        /// <summary>
        /// 菜单Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string MenuId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
