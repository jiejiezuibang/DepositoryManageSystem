using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.WorkFlow_InstanceStep
{
    public class GetEditWorkFlow_InstanceStepDto
    {
        public string Id { get; set; }
        public string CreatorName { get; set; }
        public string ConsumableName { get; set; }
        public int OutNum { get; set; }
        public string Reason { get; set; }
        public string RoleName { get; set; }
    }
}
