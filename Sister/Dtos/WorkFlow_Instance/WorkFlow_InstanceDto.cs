using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.WorkFlow_Instance
{
    public class WorkFlow_InstanceDto
    {
        public string Id { get; set; }
        public string ModelName { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Reason { get; set; }
        public string Creator { get; set; }
        public int OutNum { get; set; }
        public string OutGoodsName { get; set; }
        public string CreateTime { get; set; }
    }
}
