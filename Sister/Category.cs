using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sister
{
    /// <summary>
    /// 耗材类别表
    /// </summary>
    public class Category:BaseSister
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        [Column(TypeName = "nvarchar(16)")]
        public string CategoryName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "nvarchar(36)")]
        public string Description { get; set; }
    }
}
