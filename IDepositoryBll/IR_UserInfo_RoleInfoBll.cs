using Common.ResultEnums;
using Sister.Dtos.R_UserInfo_RoleInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDepositoryBll
{
    public interface IR_UserInfo_RoleInfoBll
    {
        /// <summary>
        /// 给用户绑定角色
        /// </summary>
        /// <param name="bindUserDto">绑定角色Id</param>
        /// <returns></returns>
        Task<R_UserInfo_RoleInfoEnums> BindUserAsync(BindUserDto bindUserDto); 
    }
}
