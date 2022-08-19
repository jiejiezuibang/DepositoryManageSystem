using IDepositoryDal;
using Sister;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 耗材类别dal
    /// </summary>
    public class CategoryDal: BaseDal<Category>, ICategoryDal
    {
        // 注入数据库上下文对象
        private readonly DepositoryContext _depositoryContext;
        public CategoryDal(DepositoryContext depositoryContext) : base(depositoryContext)
        {
            this._depositoryContext = depositoryContext;
        }
    }
}
