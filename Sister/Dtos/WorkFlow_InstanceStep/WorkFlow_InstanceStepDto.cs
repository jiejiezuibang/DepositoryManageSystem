using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.WorkFlow_InstanceStep
{
    public class WorkFlow_InstanceStepDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ConsumableName { get; set; }
        public int OutNum { get; set; }
        public string CreatorName { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewStatus { get; set; }
        public string Reason { get; set; }
        public string ReviewReason { get; set; }
        public string ReviewTime { get; set; }
        public string CreateTime { get; set; }
    }
}
