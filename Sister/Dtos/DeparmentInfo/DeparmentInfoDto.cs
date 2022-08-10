using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.DeparmentInfo
{
    /// <summary>
    /// 返回部门信息dto
    /// </summary>
    public class DeparmentInfoDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 主管id
        /// </summary>
        public string LeaderName { get; set; }

        /// <summary>
        /// 父部门id
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
    }
}
