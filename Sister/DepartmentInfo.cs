using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sister
{
    public class DepartmentInfo:DelSister
    {
        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "nvarchar(32)")]
        public string Description { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Column(TypeName = "nvarchar(16)")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 主管id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string LeaderId { get; set; }

        /// <summary>
        /// 父部门id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ParentId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
