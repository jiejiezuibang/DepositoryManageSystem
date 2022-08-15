using Sister;
using Sister.Dtos.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDepositoryDal
{
    /// <summary>
    /// 用户管理接口
    /// </summary>
    public interface IUserInfoDal: IDelRemoveDal<UserInfo>
    {
    }
}
