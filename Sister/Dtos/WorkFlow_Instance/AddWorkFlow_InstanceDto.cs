using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.WorkFlow_Instance
{
    public class AddWorkFlow_InstanceDto
    {
        public string ModelId { get; set; }
        public string Description { get; set; }
        public string Reason { get; set; }
        public string Creator { get; set; }
        public int OutNum { get; set; }
        public string OutGoodsId { get; set; }
    }
}
