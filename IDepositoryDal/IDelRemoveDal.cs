using Sister;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDepositoryDal
{
    public interface IDelRemoveDal<T>:IBaseDal<T> where T:DelSister
    {
        // 软删
        Task<bool> DelAsync(string[] Id);
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> GetAsync(string Id);
    }
}
