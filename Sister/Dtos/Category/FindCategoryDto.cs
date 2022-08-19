using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.Category
{
    /// <summary>
    /// 耗材类别dto
    /// </summary>
    public class FindCategoryDto:Pagination
    {
        public string CategoryName { get; set; }
    }
}
