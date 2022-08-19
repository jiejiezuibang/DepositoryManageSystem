using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.ConsumabelInfo
{
    /// <summary>
    /// 添加耗材信息dto
    /// </summary>
    public class AddConsumabelInfoDto
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 耗材类型Id
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// 耗材名称
        /// </summary>
        public string ConsumableName { get; set; }

        /// <summary>
        /// 耗材规格
        /// </summary>
        public string Specification { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
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
