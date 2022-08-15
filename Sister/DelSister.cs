using System;
using System.Collections.Generic;
using System.Text;

namespace Sister
{
    public class DelSister:BaseSister
    {
        /// <summary>
        /// 是否删除 
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeleteTime { get; set; }
    }
}
