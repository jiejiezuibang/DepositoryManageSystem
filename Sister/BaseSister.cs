using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sister
{
    public class BaseSister
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }
        
    }
}
