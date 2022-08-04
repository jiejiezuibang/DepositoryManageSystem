using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDepositoryDal
{
    // 仓储层基本接口
    public interface IBaseDal<T> where T:class,new()
    {
        // 增
        Task<bool> AddAsync(T t);
        // 删
        Task<bool> DelAsync(string[] Id);
        // 改
        Task<bool> EditAsync(T t);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        DbSet<T> GetAll();
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> GetAsync(string Id);
    }
}
