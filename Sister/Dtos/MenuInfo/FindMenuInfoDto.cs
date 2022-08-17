using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.MenuInfo
{
    public class FindMenuInfoDto:Pagination
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
    }
}
