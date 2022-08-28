using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.WorkFlow_Instance
{
    public class FindWorkFlow_InstanceDto:Pagination
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string userId { get; set; }
    }
}
