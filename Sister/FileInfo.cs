using Sister.Dtos.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sister
{
    /// <summary>
    /// 文件信息数据集
    /// </summary>
    public class FileInfo:BaseSister
    {

        /// <summary>
        /// 关系Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string RelationId { get; set; }

        /// <summary>
        /// 原文件名
        /// </summary>
        [Column(TypeName = "nvarchar(32)")]
        public string OldFileName { get; set; }

        /// <summary>
        /// 新文件名
        /// </summary>
        [Column(TypeName = "nvarchar(32)")]
        public string NewFileName { get; set; }

        /// <summary>
        /// 拓展名
        /// </summary>
        [Column(TypeName = "varchar(12)")]
        public string Extension { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public long Length { get; set; }

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
        /// 类别
        /// </summary>
        public FileInfoCategoryEnums Category { get; set; }
    }
}
