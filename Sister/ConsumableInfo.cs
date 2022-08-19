using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sister
{
    /// <summary>
    /// 耗材信息数据集
    /// </summary>
    public class ConsumableInfo : DelSister
    {
        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName ="nvarchar(32)")]
        public string Description { get; set; }
        
        /// <summary>
        /// 耗材类型Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string CategoryId { get; set; }

        /// <summary>
        /// 耗材名称
        /// </summary>
        [Column(TypeName = "nvarchar(16)")]
        public string ConsumableName { get; set; }

        /// <summary>
        /// 耗材规格
        /// </summary>
        [Column(TypeName = "nvarchar(32)")]
        public string Specification { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [Column(TypeName = "nvarchar(8)")]
        public string Unit { get; set; }
        
        /// <summary>
        /// 价格
        /// </summary>
        public double Money { get; set; }

        /// <summary>
        /// 警告库存
        /// </summary>
        public int WarningNum { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
