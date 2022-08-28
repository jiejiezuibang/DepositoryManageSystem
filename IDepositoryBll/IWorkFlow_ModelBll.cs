using Common.ResultEnums;
using Sister;
using Sister.Dtos.UserInfo;
using Sister.Dtos.WorkFlow_Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDepositoryBll
{
    public interface IWorkFlow_ModelBll
    {
        Task<WorkFlow_ModelEnums> AddWorkFlow_ModelBll(string Title, string Description);
        Task<WorkFlow_ModelEnums> DelWorkFlow_ModelBll(string[] IdList);
        Task<WorkFlow_ModelEnums> EditWorkFlow_ModelBll(string Id, string Title, string Description);
        List<WorkFlow_ModelDto> GetShowWorkFlow_ModelBll(FindWorkFlow_ModelDto findWorkFlow_ModelDto, out int Count);
        Task<WorkFlow_Model> FindWorkFlow_ModelBll (string Id);
        List<SelectOptionsDto> GetSelectOptions();
    }
}
