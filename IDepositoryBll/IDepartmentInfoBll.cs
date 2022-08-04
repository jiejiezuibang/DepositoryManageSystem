using Sister;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDepositoryBll
{
    /// <summary>
    /// 部门管理bll层接口
    /// </summary>
    public interface IDepartmentInfoBll
    {
        /// <summary>
        /// 获取全部部门信息
        /// </summary>
        /// <returns></returns>
        List<DepartmentInfo> GetDepartmentInfoBll();
    }
}
