using Common.ResultEnums;
using Microsoft.AspNetCore.Http;
using Sister;
using Sister.Dtos.ConsumabelInfo;
using Sister.Dtos.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDepositoryBll
{
    public interface IConsumableInfoBll
    {
        Task<ConsumableInfoEnums> AddConsumabelInfoBll(AddConsumabelInfoDto addConsumabelInfoDto);
        Task<ConsumableInfoEnums> DelConsumabelInfoBll(string[] IdList);
        Task<ConsumableInfoEnums> EditConsumabelInfoBll(EditConsumabelInfoDto editConsumabelInfoDto);
        List<ConsumabelInfoDto> GetConsumabelInfoShow(FindConsumabelInfoDto findConsumabelInfoDto);
        Task<ConsumableInfo> FindConsumabelInfoBll(string Id);
        Task<ConsumableInfoEnums> WarehousingBll(IFormFile formFile, string UserId);
    }
}
