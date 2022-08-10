using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.UserInfo
{
    /// <summary>
    /// 用户信息作为下拉框数据
    /// </summary>
    public class SelectOptionsDto
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 实际拿到的值
        /// </summary>
        public string Value { get; set; }
    }
}
