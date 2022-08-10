using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sister
{
    /// <summary>
    /// 用户角色信息数据集
    /// </summary>
    public class R_UserInfo_RoleInfo
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string UserId { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string RoleId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public string CreateTime { get; set; }
    }
}
