using IDepositoryDal;
using Microsoft.EntityFrameworkCore;
using Sister;
using Sister.Dtos.UserInfo;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserInfoDal : IUserInfoDal
    {
        // 注入数据库上下文对象
        private readonly DepositoryContext _depositoryContext;
        public UserInfoDal(DepositoryContext depositoryContext)
        {
            this._depositoryContext = depositoryContext;
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(UserInfo userInfo)
        {
            // 创建上下文对象
            // 打上添加标记
            await _depositoryContext.UserInfos.AddAsync(userInfo);
            // 对数据库进行操作
            return await _depositoryContext.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        public async Task<bool> DelAsync(string[] IdList)
        {
            // 用来存储要删除的用户对象
            List<UserInfo> userInfos = new List<UserInfo>();
            foreach (var item in IdList)
            {
                // 查询要删除的用户信息
                UserInfo userinfo = _depositoryContext.UserInfos.Find(item);
                // 判断是否查询到
                if (userinfo != null)
                {
                    // 修改状态
                    userinfo.IsDelete = true;
                    userinfo.DeleteTime = DateTime.Now;
                    userInfos.Add(userinfo);
                }
            }
            // 打上删除标记
            _depositoryContext.UpdateRange(userInfos);
            // 操作数据库并返回是否成功
            return await _depositoryContext.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public async Task<bool> EditAsync(UserInfo userInfo)
        {
            // 对对应的用户信息进行修改
            _depositoryContext.UserInfos.Update(userInfo);
            // 对数据库进行操作
            return await _depositoryContext.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// 根据Id查询用户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<UserInfo> GetAsync(string Id)
        {
            // 查询对应用户数据
            return await _depositoryContext.UserInfos.FindAsync(Id);
        }
        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        /// <returns></returns>
        public DbSet<UserInfo> GetAll()
        {
            return _depositoryContext.UserInfos;
        }
    }
}
