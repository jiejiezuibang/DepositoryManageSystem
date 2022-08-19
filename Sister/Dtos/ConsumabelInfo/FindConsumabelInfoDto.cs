using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.ConsumabelInfo
{
    /// <summary>
    /// 查询，分页耗材信息dto
    /// </summary>
    public class FindConsumabelInfoDto:Pagination
    {
        public string ConsumableName { get; set; }
    }
}
