using IDepositoryDal;
using Microsoft.EntityFrameworkCore;
using Sister;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoleInfoDal :DelBaseDal<RoleInfo>,IRoleInfoDal
    {
        // 注入上下文对象
        private DepositoryContext _depositoryContext;
        public RoleInfoDal(DepositoryContext depositoryContext):base(depositoryContext)
        {
            this._depositoryContext = depositoryContext;
        }
        ///// <summary>
        ///// 添加角色信息
        ///// </summary>
        ///// <param name="roleInfo">角色信息</param>
        ///// <returns></returns>
        //public async Task<bool> AddAsync(RoleInfo roleInfo)
        //{
        //    // 打上添加标记
        //    await _depositoryContext.RoleInfos.AddAsync(roleInfo);
        //    // 执行添加操作并且返回bool值
        //    return await _depositoryContext.SaveChangesAsync() > 0;
        //}
        ///// <summary>
        ///// 删除角色信息
        ///// </summary>
        ///// <param name="Id">要删除角色id</param>
        ///// <returns></returns>
        //public async Task<bool> DelAsync(string[] Id)
        //{
        //    foreach(var item in Id)
        //    {
        //        // 查询到要删除的角色信息
        //        RoleInfo roleInfo = await _depositoryContext.RoleInfos.FindAsync(item);
        //        // 进行软删除
        //        roleInfo.IsDelete = true;
        //        roleInfo.DeleteTime = DateTime.Now;
        //        // 打上修改标记
        //        _depositoryContext.RoleInfos.Update(roleInfo);
        //    }
        //    // 执行删除操作并且返回bool值
        //    return await _depositoryContext.SaveChangesAsync() > 0;
        //}
        ///// <summary>
        ///// 修改角色信息
        ///// </summary>
        ///// <param name="roleInfo">角色信息</param>
        ///// <returns></returns>
        //public async Task<bool> EditAsync(RoleInfo roleInfo)
        //{
        //    // 打上修改标记
        //    _depositoryContext.RoleInfos.Update(roleInfo);
        //    // 执行修改操作并且返回bool值
        //    return await _depositoryContext.SaveChangesAsync() > 0;
        //}
        ///// <summary>
        ///// 获取全部角色信息
        ///// </summary>
        ///// <returns></returns>
        //public DbSet<RoleInfo> GetAll()
        //{
        //    return _depositoryContext.RoleInfos;
        //}

        //public Task<RoleInfo> GetAsync(string Id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
