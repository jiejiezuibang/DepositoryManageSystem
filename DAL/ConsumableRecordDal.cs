using IDepositoryDal;
using Sister;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ConsumableRecordDal:BaseDal<ConsumableRecord>, IConsumableRecordDal
    {
        // 注入数据库上下文对象
        private readonly DepositoryContext _depositoryContext;
        public ConsumableRecordDal(DepositoryContext depositoryContext) : base(depositoryContext)
        {
            this._depositoryContext = depositoryContext;
        }
    }
}
