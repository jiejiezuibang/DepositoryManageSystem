using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.WorkFlow_InstanceStep
{
    public class FindWorkFlow_InstanceStepDto:Pagination
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
    }
}
