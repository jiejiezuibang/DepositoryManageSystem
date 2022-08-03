using DAL;
using IDepositoryDal;
using Sister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class DepartmentInfoBll
    {
        // 注入部门管理dal
        private readonly IDepartmentInfoDal _departmentInfoDal;
        public DepartmentInfoBll(IDepartmentInfoDal departmentInfoDal)
        {
            this._departmentInfoDal = departmentInfoDal;
        }
        /// <summary>
        /// 获取部门表信息
        /// </summary>
        /// <returns></returns>
        public List<DepartmentInfo> GetDepartmentInfoBll()
        {
            return _departmentInfoDal.GetAll().ToList();
        }
    }
}
