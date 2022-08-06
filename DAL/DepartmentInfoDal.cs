using IDepositoryDal;
using Microsoft.EntityFrameworkCore;
using Sister;
using Sister.Dtos.DeparmentInfo;
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
        private readonly DepositoryContext _depositoryContext;
        public DepartmentInfoDal(DepositoryContext depositoryContext)
        {
            this._depositoryContext = depositoryContext;
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="departmentInfo">部门信息对象</param>
        /// <returns></returns>
        public async Task<bool> AddAsync(DepartmentInfo departmentInfo)
        {
            // 打上添加标记
            await _depositoryContext.AddAsync(departmentInfo);
            // 判断添加是否成功,返回bool值
            return await _depositoryContext.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// 批量删除或单个删除部门信息
        /// </summary>
        /// <param name="IdList">部门id数组</param>
        /// <returns></returns>
        public async Task<bool> DelAsync(string[] IdList)
        {
            foreach(string item in IdList)
            {
                // 查询要修改的部门数据
                DepartmentInfo departmentInfo = _depositoryContext.DepartmentInfos.Find(item);
                // 进行软删除
                departmentInfo.IsDelete = true;
                departmentInfo.DeleteTime = DateTime.Now;
                // 打上修改标记
                _depositoryContext.DepartmentInfos.Update(departmentInfo);
            }
            // 判断软删除是否成功,返回bool值
            return await _depositoryContext.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<bool> EditAsync(DepartmentInfo departmentInfo)
        {
            // 打上修改标记
            _depositoryContext.DepartmentInfos.Update(departmentInfo);
            // 执行修改操作并且判断然后返回对应bool值
            return await _depositoryContext.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// 获取全部部门信息
        /// </summary>
        /// <returns></returns>
        public DbSet<DepartmentInfo> GetAll()
        {
            return _depositoryContext.DepartmentInfos;
        }
        
        public Task<DepartmentInfo> GetAsync(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
