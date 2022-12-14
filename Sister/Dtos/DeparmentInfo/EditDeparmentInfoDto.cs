using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.DeparmentInfo
{
    public class EditDeparmentInfoDto
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        public string Id { get; set;}
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
        public string LeaderId { get; set; }

        /// <summary>
        /// 父部门id
        /// </summary>
        public string ParentId { get; set; }
    }
}
