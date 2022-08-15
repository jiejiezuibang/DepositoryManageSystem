using IDepositoryDal;
using Microsoft.EntityFrameworkCore;
using Sister;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DelBaseDal<T>:BaseDal<T>, IDelRemoveDal<T> where T:DelSister
    {
        // 注入数据库上下文对象
        private readonly DepositoryContext _depositoryContext;
        public DelBaseDal(DepositoryContext depositoryContext):base(depositoryContext)
        {
            this._depositoryContext = depositoryContext;
        }
        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(string Id)
        {
            return await _depositoryContext.Set<T>().FirstOrDefaultAsync(t => t.Id == Id && !t.IsDelete);
        }
        /// 软删除
        /// </summary>
        /// <param name="Id">要删除信息的Id</param>
        /// <returns></returns>
        public async Task<bool> DelAsync(string[] Id)
        {
            foreach (var item in Id)
            {
                // 获取到要删除的数据
                T entity = await _depositoryContext.Set<T>().FirstOrDefaultAsync(t => t.Id.Equals(item));
                // 进行软删除
                entity.IsDelete = true;
                entity.DeleteTime = DateTime.Now;
                // 打上修改标记
                _depositoryContext.Set<T>().Update(entity);
            }
            return await _depositoryContext.SaveChangesAsync() > 0;
        }
    }
}
