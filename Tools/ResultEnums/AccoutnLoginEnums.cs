using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultEnums
{
    // 用户登录板块枚举
    public enum AccoutnLoginEnums
    {
        /// <summary>
        /// 登录成功
        /// </summary>
        loginSuccess,
        /// <summary>
        /// 登录失败
        /// </summary>
        loginError,
        /// <summary>
        /// 账号为空
        /// </summary>
        accountIsNull,
        /// <summary>
        /// 密码为空
        /// </summary>
        PwdIsNull,
        /// <summary>
        /// 账号不存在
        /// </summary>
        accountNotExist,
        /// <summary>
        /// 密码错误
        /// </summary>
        PwdError,
        /// <summary>
        /// 两次密码不同
        /// </summary>
        TwoPwdError,
        /// <summary>
        /// 重置密码成功
        /// </summary>
        ResetPwdSuccess,
        UploadAvatarSucess,
        UploadAvaterError,
    }
}
