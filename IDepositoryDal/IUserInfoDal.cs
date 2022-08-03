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
    public interface IUserInfoDal: IBaseDal<UserInfo>
    {
        //获取用户信息(包括分页和查询)
        List<UserInfoDto> GetUserInfo(FindUserInfoDto findUserInfoDto,out int DataCount);
    }
}
