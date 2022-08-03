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
        DbSet<T> GetAll();
        // 查
        Task<T> GetAsync(string Id);
    }
}
