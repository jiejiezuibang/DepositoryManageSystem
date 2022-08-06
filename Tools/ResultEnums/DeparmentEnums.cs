using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultEnums
{
    /// <summary>
    /// 部门管理板块枚举
    /// </summary>
    public enum DeparmentEnums
    {
        /// <summary>
        /// 添加部门信息成功
        /// </summary>
        AddDeparmentSuccess,
        /// <summary>
        /// 添加部门信息失败
        /// </summary>
        AddDeparmentError,
        /// <summary>
        /// 添加部门，部门也存在
        /// </summary>
        AddDeparmentNameExist,
        /// <summary>
        /// 修改部门信息成功
        /// </summary>
        EditDeparmentSuccess,
        /// <summary>
        /// 添加部门信息失败
        /// </summary>
        EditDeparmentError,
        /// <summary>
        /// 删除部门信息成功
        /// </summary>
        DelDeparmentSuccess,
        /// <summary>
        /// 删除部门信息失败
        /// </summary>
        DelDeparmentError,
        /// <summary>
        /// 部门信息操作发生错误
        /// </summary>
        DeparmentError,
    }
}
