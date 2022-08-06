using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.DeparmentInfo
{
    /// <summary>
    /// 查询部门信息dto
    /// </summary>
    public class FindDeparmentInfoDto
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 每页数据量
        /// </summary>
        public int limit { get; set; }
    }
}
