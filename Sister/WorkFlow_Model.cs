using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sister
{
    /// <summary>
    /// 工作流模板数据集
    /// </summary>
    public class WorkFlow_Model : DelSister
    {
        /// <summary>
        /// 模板标题
        /// </summary>
        [Column(TypeName ="nvarchar(32)")]
        public string Title { get; set; }

        /// <summary>
        ///  添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "nvarchar(64)")]
        public string Description { get; set; }

    }
}
