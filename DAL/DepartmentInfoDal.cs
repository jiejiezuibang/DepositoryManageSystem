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
            // 创建上下文对象
            DepositoryContext depositoryContext = new DepositoryContext();
            return depositoryContext.DepartmentInfos;
        }

        public Task<DepartmentInfo> GetAsync(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
