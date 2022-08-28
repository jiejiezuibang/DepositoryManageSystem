using Sister.Dtos.WorkFlow_InstanceStep;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sister
{
    /// <summary>
    /// 工作流步骤数据集
    /// </summary>
    public class WorkFlow_InstanceStep : BaseSister
    {
        /// <summary>
        /// 工作流实例Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string InstanceId { get; set; }
        
        /// <summary>
        /// 审核人Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ReviewerId { get; set; }

        /// <summary>
        /// 审核理由
        /// </summary>
        [Column(TypeName = "nvarchar(64)")]
        public string ReviewReason { get; set; }
        
        /// <summary>
        /// 审核状态
        /// </summary>
        public WorkFlow_InstanceStepStatusEnums ReviewStatus { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? ReviewTime { get; set; }

        /// <summary>
        /// 上一个步骤Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string BeforeStepId { get; set; }
        
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
