using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sister.Dtos.UserInfo
{
    public class DelUserInfoDto
    {
        public string Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
