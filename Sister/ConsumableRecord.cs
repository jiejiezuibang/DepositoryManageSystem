using Sister.Dtos.ConsumableRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sister
{
    /// <summary>
    /// 耗材记录数据集
    /// </summary>
    public class ConsumableRecord:BaseSister
    {

        /// <summary>
        /// 耗材Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ConsumableId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public ConsumableRecordTypeEnums Type { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 添加人Id
        /// </summary>
        [Column(TypeName ="varchar(36)")]
        public string Creator { get; set; }

    }
}
