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
        /// 获取用户信息
        /// </summary>
        /// <param name="findUserInfoDto">要查询的用户条件与分页条件</param>
        /// <returns></returns>
        public List<UserInfoDto> GetUserInfo(FindUserInfoDto findUserInfoDto, out int userInfoCoutn)
        {
            var userInfoList = (from a in _depositoryContext.UserInfos
                                    .Where(a => a.IsDelete == false)
                                join b in _depositoryContext.DepartmentInfos // 连表
                                on a.DepartmentId equals b.Id
                                select new UserInfoDto
                                {
                                    Id = a.Id,
                                    Account = a.Account,
                                    UserName = a.UserName,
                                    PhoneNum = a.PhoneNum,
                                    Email = a.Email,
                                    DepartmentName = b.DepartmentName,
                                    Sex = a.Sex == 0 ? '女' : '男',
                                    IsAdmin = a.IsAdmin == true ? '是' : '否',
                                    CreateTime = a.CreateTime.ToString(),
                                });
            // 进行查询
            if (findUserInfoDto.UserName != null)
            {
                userInfoList = userInfoList.Where(a => a.UserName.Contains(findUserInfoDto.UserName));
            }
            if (findUserInfoDto.Account != null)
            {
                userInfoList = userInfoList.Where(a => a.Account.Equals(findUserInfoDto.Account));
            }
            // 获取总条数
            userInfoCoutn = userInfoList.Count();

            return userInfoList.OrderBy(a => a.CreateTime) // 按添加时间排序
            .Skip(findUserInfoDto.limit * (findUserInfoDto.page - 1)).Take(findUserInfoDto.limit).ToList(); // 分页操作
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
