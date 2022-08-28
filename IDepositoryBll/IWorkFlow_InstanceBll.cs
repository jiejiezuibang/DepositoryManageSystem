using Common.ResultEnums;
using Sister.Dtos.WorkFlow_Instance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDepositoryBll
{
    public interface IWorkFlow_InstanceBll
    {
        WorkFlow_InstanceEnums AddWorkFlow_InstanceBll(AddWorkFlow_InstanceDto addWorkFlow_InstanceDto, out string msg);
        List<WorkFlow_InstanceDto> GetShowWorkFlow_InstanceBll(FindWorkFlow_InstanceDto findWorkFlow_InstanceDto, out int Count);
    }
}
