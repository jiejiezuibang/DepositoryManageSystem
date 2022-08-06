using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sister
{
    public class RoleInfo
    {
        /// <summary>
        /// 角色id
        /// </summary>
        [Column(TypeName ="varchar(36)")]
        public string Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [Column(TypeName = "nvarchar(16)")]
        public string RoleName { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        [Column(TypeName = "nvarchar(32)")]
        public string Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeleteTime { get; set; }
    }
}
