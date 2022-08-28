using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.WorkFlow_InstanceStep
{
    public class EidtWorkFlow_InstanceStepDto
    {
        public string Id { get; set; }
        public WorkFlow_InstanceStepStatusEnums ReviewStatus { get; set; }
        public string ReviewReason { get; set; }
        public int OutNum { get; set; }
    }
}
