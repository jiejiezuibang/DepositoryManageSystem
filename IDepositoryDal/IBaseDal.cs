using Microsoft.EntityFrameworkCore;
using Sister;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDepositoryDal
{
    // 仓储层基本接口
    public interface IBaseDal<T> where T: BaseSister
    {
        // 增
        Task<bool> AddAsync(T t);
        // 软删
        //Task<bool> DelAsync(string[] Id);
        
        // 改
        Task<bool> EditAsync(T t);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        DbSet<T> GetAll();
        /// <summary>
        /// 硬删
        /// </summary>
        /// <param name="Id">要删除Id</param>
        /// <returns></returns>
        Task<bool> DelRemoveAsync(string Id);
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        //Task<T> GetAsync(string Id);
    }
}
