using IDepositoryDal;
using Microsoft.EntityFrameworkCore;
using Sister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 部门表数据库操作对象
    /// </summary>
    public class DepartmentInfoDal: IDepartmentInfoDal
    {
        // 注入数据库上下文对象
        private readonly DepositoryContext _depositoryContext1;
        public DepartmentInfoDal(DepositoryContext depositoryContext)
        {
            this._depositoryContext1 = depositoryContext;
        }
        public Task<bool> AddAsync(DepartmentInfo t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DelAsync(string[] Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(DepartmentInfo t)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取全部部门信息
        /// </summary>
        /// <returns></returns>
        public DbSet<DepartmentInfo> GetAll()
        {
            return _depositoryContext1.DepartmentInfos;
        }

        public Task<DepartmentInfo> GetAsync(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
