using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sister.Tools
{
    public class AjaxResult
    {
        // 请求状态
        public int code { get; set; } = 501;
        // 标题
        public string msg { get; set; }
        // 数据
        public object data { get; set; }
        // 总条数
        public int count { get; set; }
    }
}
