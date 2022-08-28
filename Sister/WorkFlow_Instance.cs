using Sister.Dtos.WorkFlow_Instance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sister
{
    /// <summary>
    /// 工作流实例数据集
    /// </summary>
    public class WorkFlow_Instance : BaseSister
    {
        /// <summary>
        /// 工作流模板Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ModelId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public WorkFlow_InstanceStatusEnum Status { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "nvarchar(64)")]
        public string Description { get; set; }

        /// <summary>
        /// 申请理由
        /// </summary>
        [Column(TypeName = "nvarchar(64)")]
        public string Reason { get; set; }
        
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 添加人Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Creator { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public int OutNum { get; set; }

        /// <summary>
        /// 出库物资
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string OutGoodsId { get; set; }

    }
}
