using IDepositoryDal;
using Microsoft.EntityFrameworkCore;
using Sister;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class R_UserInfo_RoleInfoDal : IR_UserInfo_RoleInfoDal
    {
        /// <summary>
        /// 注入数据库上下文对象
        /// </summary>
        private readonly DepositoryContext _depositoryContext;
        public R_UserInfo_RoleInfoDal(DepositoryContext depositoryContext)
        {
            this._depositoryContext = depositoryContext;
        }
        /// <summary>
        /// 添加用户角色信息表
        /// </summary>
        /// <param name="r_UserInfo_RoleInfo"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(R_UserInfo_RoleInfo r_UserInfo_RoleInfo)
        {
            // 打上添加标记
            await _depositoryContext.AddAsync(r_UserInfo_RoleInfo);
            // 执行sql操作并返回bool值
            return await _depositoryContext.SaveChangesAsync() > 0;
        }

        public Task<bool> DelAsync(string[] Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(R_UserInfo_RoleInfo t)
        {
            throw new NotImplementedException();
        }

        public DbSet<R_UserInfo_RoleInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<R_UserInfo_RoleInfo> GetAsync(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
