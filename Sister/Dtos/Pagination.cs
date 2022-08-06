using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos
{
    public class Pagination
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 每页数据量
        /// </summary>
        public int limit { get; set; }
    }
}
