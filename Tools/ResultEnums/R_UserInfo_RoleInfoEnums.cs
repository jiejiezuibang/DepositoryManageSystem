using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultEnums
{
    public enum R_UserInfo_RoleInfoEnums
    {
        /// <summary>
        /// 绑定用户成功
        /// </summary>
        BindUserSuccess,
        /// <summary>
        /// 绑定用户失败
        /// </summary>
        BindUserError,
        /// <summary>
        /// 角色Id为空
        /// </summary>
        RoleIdIsNull,
    }
}
