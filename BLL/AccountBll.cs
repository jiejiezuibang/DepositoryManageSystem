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
        public bool DoLogin(string account,string password,out string msg,out string UserName,out string Account)
        {
            // 校验前端传递的值是否为空
            if (account == null)
            {
                msg = "账号不能为空";
                UserName = null;
                Account = null;
                return false;
            }
            if (password == null)
            {
                msg = "密码不能为空";
                UserName = null;
                Account = null;
                return false;
            }
            // 通过account查询用户
            UserInfo userInfo = _userInfoDal.GetAll().FirstOrDefault(u => u.Account == account);
            if(userInfo == null)
            {
                msg = "该账号不存在";
                UserName = null;
                Account = null;
                return false;
            }
            if (userInfo.PassWord.Equals(mD5Encrypt.StartEncrypy(password)))
            {
                msg = "登录成功";
                UserName = userInfo.UserName;
                Account = userInfo.Account;
                return true;
            }
            msg = "登录失败，密码错误";
            UserName = null;
            Account = null;
            return false;
        }
    }
}
