using IDepositoryDal;
using Microsoft.EntityFrameworkCore;
using Sister;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDal<T> :IBaseDal<T> where T: BaseSister
    {
        // 注入数据库上下文对象
        private readonly DepositoryContext _depositoryContext;
        public BaseDal(DepositoryContext depositoryContext)
        {
            this._depositoryContext = depositoryContext;
        }
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="entity">要添加的对象</param>
        /// <returns></returns>
        public async Task<bool> AddAsync(T entity)
        {
            await _depositoryContext.Set<T>().AddAsync(entity);
            return await _depositoryContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        
        /// <summary>
        /// 硬删除
        /// </summary>
        /// <param name="Id">要是的数据Id</param>
        /// <returns></returns>
        public async Task<bool> DelRemoveAsync(string Id)
        {
            // 查询到要删除的数据并且打上删除标记
            _depositoryContext.Set<T>().Remove(await _depositoryContext.Set<T>().FindAsync(Id));
            return await _depositoryContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 改
        /// </summary>
        /// <param name="entity">要修改的实体</param>
        /// <returns></returns>
        public async Task<bool> EditAsync(T entity)
        {
            _depositoryContext.Set<T>().Update(entity);
            return await _depositoryContext.SaveChangesAsync()>0;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public DbSet<T> GetAll()
        {
            return _depositoryContext.Set<T>();
        }
        
    }
}
