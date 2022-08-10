using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultEnums
{
    public enum UserInfoEnums
    {
        /// <summary>
        /// 修改信息成功
        /// </summary>
        EditUserInfoSuccess,
        /// <summary>
        /// 修改用户信息失败
        /// </summary>
        EditUserInfoError,
        /// <summary>
        /// 号码格式错误
        /// </summary>
        PhoneNumError,
        /// <summary>
        /// 邮箱格式错误
        /// </summary>
        EmailErro,
        /// <summary>
        /// 校验数据通过
        /// </summary>
        CheckSuccess,
        /// <summary>
        /// 用户信息不存在
        /// </summary>
        UserInfoNotExist,
    }
}
