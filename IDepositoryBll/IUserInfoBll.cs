using Sister;
using Sister.Dtos.UserInfo;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDepositoryBll
{
    /// <summary>
    /// 用户管理bll层接口
    /// </summary>
    public interface IUserInfoBll
    {
        /// <summary>
        /// 校验添加dto
        /// </summary>
        /// <param name="addUserInfoDto"></param>
        /// <returns></returns>
        AjaxResult UserInfoDtoCheck(AddUserInfoDto addUserInfoDto);
        /// <summary>
        /// 校验修改dto
        /// </summary>
        /// <param name="editUserInfoDto"></param>
        /// <returns></returns>
        AjaxResult UserInfoDtoCheck(EditUserInfoDto editUserInfoDto);
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="findUserInfoDto"></param>
        /// <param name="userInfoCount"></param>
        /// <returns></returns>
        List<UserInfoDto> GetUserInfoBll(FindUserInfoDto findUserInfoDto, out int userInfoCount);
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="addUserInfoDto"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool AddUserInfo(AddUserInfoDto addUserInfoDto, out string msg);
        /// <summary>
        /// 根据id查询对应用户信息业务
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<UserInfo> FindIdUserInfo(string Id);
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        Task<bool> DelUserInfoBll(string[] IdList);
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="editUserInfoDto"></param>
        /// <returns></returns>
        Task<bool> UdpateUserInfo(EditUserInfoDto editUserInfoDto);

    }
}
