using IDepositoryDal;
using Sister;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 工作流模板dal
    /// </summary>
    public class WorkFlow_ModelDal:DelBaseDal<WorkFlow_Model>, IWorkFlow_ModelDal
    {
        // 注入数据库上下文对象
        private readonly DepositoryContext _depositoryContext;
        public WorkFlow_ModelDal(DepositoryContext depositoryContext) : base(depositoryContext)
        {
            this._depositoryContext = depositoryContext;
        }
    }
}
