using IDepositoryDal;
using Sister;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class WorkFlow_InstanceDal:BaseDal<WorkFlow_Instance>, IWorkFlow_InstanceDal
    {
        // 注入数据库上下文对象
        private readonly DepositoryContext _depositoryContext;
        public WorkFlow_InstanceDal(DepositoryContext depositoryContext) : base(depositoryContext)
        {
            this._depositoryContext = depositoryContext;
        }
    }
}
