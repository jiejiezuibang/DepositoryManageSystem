using Common.ResultEnums;
using Sister;
using Sister.Dtos.WorkFlow_InstanceStep;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDepositoryBll
{
    public interface IWorkFlow_InstanceStepBll
    {
        List<WorkFlow_InstanceStepDto> GetShowWorkFlow_InstanceStepBll(FindWorkFlow_InstanceStepDto findWorkFlow_InstanceStepDto, out int Count);
        WorkFlow_InstanceStepEnums EidtWorkFlow_InstanceStepBll(EidtWorkFlow_InstanceStepDto eidtWorkFlow_InstanceStepDto, out string msg);
        GetEditWorkFlow_InstanceStepDto FindWorkFlow_InstanceStepBll(string Id);
    }
}
