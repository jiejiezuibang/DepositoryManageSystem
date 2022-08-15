using Common.ResultEnums;
using IDepositoryBll;
using IDepositoryDal;
using Sister;
using Sister.Dtos.R_UserInfo_RoleInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 角色信息表bll层
    /// </summary>
    public class R_UserInfo_RoleInfoBll : IR_UserInfo_RoleInfoBll
    {
        // 注入角色信息dal对象
        private readonly IR_UserInfo_RoleInfoDal _iR_UserInfo_RoleInfoDal;
        public R_UserInfo_RoleInfoBll(IR_UserInfo_RoleInfoDal r_UserInfo_RoleInfoDal)
        {
            this._iR_UserInfo_RoleInfoDal = r_UserInfo_RoleInfoDal;
        }
        /// <summary>
        /// 为用户绑定角色
        /// </summary>
        /// <param name="bindUserDto">添加用户角色信息dto</param>
        /// <returns></returns>
        public async Task<R_UserInfo_RoleInfoEnums> BindUserAsync(BindUserDto bindUserDto)
        {
            // 判断角色Id是否存在
            if (string.IsNullOrEmpty(bindUserDto.RoleId))
            {
                return R_UserInfo_RoleInfoEnums.RoleIdIsNull;
            }
            //解绑角色
            foreach(var item in _iR_UserInfo_RoleInfoDal.GetAll().Where(a => a.RoleId.Equals(bindUserDto.RoleId)).ToList())
            {
                // 穿梭框右侧的数据和数据库用户角色表信息配对
                if(bindUserDto.UserId != null)
                {
                    if (!bindUserDto.UserId.Any(u => u.Equals(item.UserId)))
                    {
                        await _iR_UserInfo_RoleInfoDal.DelRemoveAsync(item.Id);
                    }
                }
                else
                {
                    await _iR_UserInfo_RoleInfoDal.DelRemoveAsync(item.Id);
                }
            }



            //绑定角色
            if (bindUserDto.UserId != null)
            {
                
                foreach (string item in bindUserDto.UserId)
                {
                    // 判断指定角色是否存在指定用户
                    if (!_iR_UserInfo_RoleInfoDal.GetAll().Where(a => a.RoleId.Equals(bindUserDto.RoleId)).Any(a => a.UserId.Equals(item)))
                    {
                        // 创建用户信息对象并赋值
                        R_UserInfo_RoleInfo r_UserInfo_RoleInfo = new R_UserInfo_RoleInfo
                        {
                            Id = Guid.NewGuid().ToString(),
                            RoleId = bindUserDto.RoleId,
                            UserId = item,
                            CreateTime = DateTime.Now,
                        };
                        await _iR_UserInfo_RoleInfoDal.AddAsync(r_UserInfo_RoleInfo);
                    }
                }
            }
            return R_UserInfo_RoleInfoEnums.BindUserSuccess;
        }
    }
}
