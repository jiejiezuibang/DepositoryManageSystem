using IDepositoryDal;
using Sister;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 耗材信息dal
    /// </summary>
    public class ConsumableInfoDal:DelBaseDal<ConsumableInfo>, IConsumableInfoDal
    {
        // 注入数据库上下文对象
        private readonly DepositoryContext _depositoryContext;
        public ConsumableInfoDal(DepositoryContext depositoryContext) : base(depositoryContext)
        {
            this._depositoryContext = depositoryContext;
        }
    }
}
