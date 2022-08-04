using Common.ResultEnums;
using IDepositoryDal;
using Sister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;

namespace BLL
{
    public class AccountBll
    {
        // 注入用户管理dal
        private readonly IUserInfoDal _userInfoDal;
        MD5Encrypt mD5Encrypt = new MD5Encrypt();
        public AccountBll(IUserInfoDal userInfoDal)
        {
            this._userInfoDal = userInfoDal;
        }
        /// <summary>
        /// 用登录业务
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public AccoutnLoginEnums DoLogin(string account,string password,out string UserName,out string Account)
        {
            // 校验前端传递的值是否为空
            if (account == null)
            {
                UserName = null;
                Account = null;
                return AccoutnLoginEnums.accountIsNull;
            }
            if (password == null)
            {
                UserName = null;
                Account = null;
                return AccoutnLoginEnums.PwdIsNull;
            }
            // 通过account查询用户
            UserInfo userInfo = _userInfoDal.GetAll().FirstOrDefault(u => u.Account == account);
            if(userInfo == null)
            {
                UserName = null;
                Account = null;
                return AccoutnLoginEnums.accountNotExist;
            }
            if (userInfo.PassWord.Equals(mD5Encrypt.StartEncrypy(password)))
            {
                UserName = userInfo.UserName;
                Account = userInfo.Account;
                return AccoutnLoginEnums.loginSuccess;
            }
            else
            {
                UserName = null;
                Account = null;
                return AccoutnLoginEnums.PwdError;
            }
        }
        /// <summary>
        /// 重置用户密码业务
        /// </summary>
        public AccoutnLoginEnums ResetPwdBll(string oldPwd, string newPwd, string verifyPwd,string account)
        {
            // 通过account查询用户
            UserInfo userInfo = _userInfoDal.GetAll().FirstOrDefault(u => u.Account == account);
            // 判断用户输入的旧密码是否正确
            if (userInfo.PassWord.Equals(mD5Encrypt.StartEncrypy(oldPwd)))
            {
                // 判断用户输入的新密码和确认密码是否相同
                if (newPwd.Equals(verifyPwd))
                {
                    // 给用户赋值新密码
                    userInfo.PassWord = mD5Encrypt.StartEncrypy(newPwd);
                    // 修改密码操作
                    _userInfoDal.EditAsync(userInfo);
                    return AccoutnLoginEnums.ResetPwdSuccess;
                }
                else
                {
                    return AccoutnLoginEnums.TwoPwdError;
                }
            }
            return AccoutnLoginEnums.PwdError;
        }
    }
}
