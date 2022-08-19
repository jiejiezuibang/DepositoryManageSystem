using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.ConsumabelInfo
{
    public class EditConsumabelInfoDto:AddConsumabelInfoDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
    }
}
