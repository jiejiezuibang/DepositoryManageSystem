using Common.ResultEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDepositoryBll
{
    /// <summary>
    /// 登录管理bll层接口
    /// </summary>
    public interface IAccountBll
    {
        /// <summary>
        /// 用户登录操作
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <param name="UserName">用户名</param>
        /// <param name="Account">账号</param>
        /// <returns></returns>
        AccoutnLoginEnums DoLogin(string account, string password, out string UserName, out string Account, out string Id);
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <param name="verifyPwd">确认密码</param>
        /// <param name="account">账号</param>
        /// <returns></returns>
        AccoutnLoginEnums ResetPwdBll(string oldPwd, string newPwd, string verifyPwd, string account);
    }
}
