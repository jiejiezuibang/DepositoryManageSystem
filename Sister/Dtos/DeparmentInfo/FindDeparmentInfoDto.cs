using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.DeparmentInfo
{
    /// <summary>
    /// 查询部门信息dto
    /// </summary>
    public class FindDeparmentInfoDto: Pagination
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
