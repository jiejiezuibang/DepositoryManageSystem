using Common.ResultEnums;
using DAL;
using IDepositoryBll;
using IDepositoryDal;
using Microsoft.EntityFrameworkCore;
using Sister;
using Sister.Dtos.UserInfo;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tools;

namespace BLL
{
    public class UserInfoBll : IUserInfoBll
    {
        // 注入操作用户信息数据对象
        private readonly IUserInfoDal _userInfoDal;
        // 注入md5加密对象
        private readonly MD5Encrypt _mD5Encrypt1;
        // 注入部门管理dal
        private readonly IDepartmentInfoDal _departmentInfoDal;
        // 注入用户角色dal
        private readonly IR_UserInfo_RoleInfoDal _r_UserInfo_RoleInfoDal;
        public UserInfoBll(IUserInfoDal userInfoDal, MD5Encrypt mD5Encrypt, IDepartmentInfoDal departmentInfoDal, IR_UserInfo_RoleInfoDal r_UserInfo_RoleInfoDal)
        {
            this._userInfoDal = userInfoDal;
            this._mD5Encrypt1 = mD5Encrypt;
            this._departmentInfoDal = departmentInfoDal;
            this._r_UserInfo_RoleInfoDal = r_UserInfo_RoleInfoDal;
        }

        /// <summary>
        /// 校验前端传递给来添加用户的数据
        /// </summary>
        /// <param name="addUserInfoDto">添加用户Dto</param>
        /// <returns></returns>
        public AjaxResult UserInfoDtoCheck(AddUserInfoDto addUserInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 校验前端传递过来的添加用户信息数据
            if (string.IsNullOrEmpty(addUserInfoDto.Account))
            {
                ajaxResult.msg = "账号不能为空";
                return ajaxResult;
            }
            if (string.IsNullOrEmpty(addUserInfoDto.UserName))
            {
                ajaxResult.msg = "用户名不能为空";
                return ajaxResult;
            }
            if (string.IsNullOrEmpty(addUserInfoDto.PassWord))
            {
                ajaxResult.msg = "密码不能为空";
                return ajaxResult;
            }
            if (string.IsNullOrEmpty(addUserInfoDto.TwoPassWord))
            {
                ajaxResult.msg = "确认密码不能为空";
                return ajaxResult;
            }
            if (!addUserInfoDto.PassWord.Equals(addUserInfoDto.TwoPassWord))
            {
                ajaxResult.msg = "两次密码不相同";
                return ajaxResult;
            }
            if (addUserInfoDto.PhoneNum == null)
            {

            }
            else if (!Regex.IsMatch(addUserInfoDto.PhoneNum, @"^1[3456789]\d{9}$"))
            {
                ajaxResult.msg = "手机号码格式不正确";
                return ajaxResult;
            }
            if (addUserInfoDto.Email == null)
            {

            }
            else if (!Regex.IsMatch(addUserInfoDto.Email, @"^[1-9][0-9]{4,}@qq.com$"))
            {
                ajaxResult.msg = "邮箱格式不正确";
                return ajaxResult;
            }
            ajaxResult.code = 200;
            return ajaxResult;
        }

        /// <summary>
        /// 校验前端传递给来修改用户的数据
        /// </summary>
        /// <param name="addUserInfoDto">修改用户Dto</param>
        /// <returns></returns>
        public AjaxResult UserInfoDtoCheck(EditUserInfoDto editUserInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            // 校验前端传递过来的添加用户信息数据
            if (string.IsNullOrEmpty(editUserInfoDto.Account))
            {
                ajaxResult.msg = "账号不能为空";
                return ajaxResult;
            }
            if (string.IsNullOrEmpty(editUserInfoDto.UserName))
            {
                ajaxResult.msg = "用户名不能为空";
                return ajaxResult;
            }
            if (editUserInfoDto.PhoneNum == null)
            {

            }
            else if (!Regex.IsMatch(editUserInfoDto.PhoneNum, @"^1[3456789]\d{9}$"))
            {
                ajaxResult.msg = "手机号码格式不正确";
                return ajaxResult;
            }
            if (editUserInfoDto.Email == null)
            {

            }
            else if (!Regex.IsMatch(editUserInfoDto.Email, @"^[1-9][0-9]{4,}@qq.com$"))
            {
                ajaxResult.msg = "邮箱格式不正确";
                return ajaxResult;
            }
            ajaxResult.code = 200;
            return ajaxResult;
        }

        /// <summary>
        /// 获取用户信息业务
        /// </summary>
        /// <param name="findUserInfoDto">查询用户和分页dto</param>
        /// <returns></returns>
        public List<UserInfoDto> GetUserInfoBll(FindUserInfoDto findUserInfoDto, out int userInfoCount)
        {
            var userInfoList = (from a in _userInfoDal.GetAll()
                                    .Where(a => a.IsDelete == false)
                                    .OrderByDescending(a => a.CreateTime)     // 降序排序
                                join b in _departmentInfoDal.GetAll() // 连表(左连)
                                on a.DepartmentId equals b.Id into JoinUserInfos
                                from JoinU in JoinUserInfos.DefaultIfEmpty()
                                select new UserInfoDto
                                {
                                    Id = a.Id,
                                    Account = a.Account,
                                    UserName = a.UserName,
                                    PhoneNum = a.PhoneNum,
                                    Email = a.Email,
                                    DepartmentName = JoinU.DepartmentName,
                                    Sex = a.Sex == 0 ? '女' : '男',
                                    IsAdmin = a.IsAdmin == true ? '是' : '否',
                                    CreateTime = a.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"), // 格式化时间
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
            userInfoCount = userInfoList.Count();

            return userInfoList// 按添加时间排序
            .Skip(findUserInfoDto.limit * (findUserInfoDto.page - 1)).Take(findUserInfoDto.limit).ToList(); // 分页操作
        }

        /// <summary>
        /// 添加用户信息业务
        /// </summary>
        /// <param name="addUserInfoDto"></param>
        /// <returns></returns>
        public bool AddUserInfo(AddUserInfoDto addUserInfoDto, out string msg)
        {
            try
            {
                // 根据account查询用户信息
                UserInfo userob = _userInfoDal.GetAll().FirstOrDefault(u => u.Account == addUserInfoDto.Account);
                // 判断账号是否存在
                if (userob != null)
                {
                    msg = "该账号以存在";
                    return false;
                }
                // 对要添加到数据的密码进行加密
                addUserInfoDto.PassWord = _mD5Encrypt1.StartEncrypy(addUserInfoDto.PassWord);
                // 创建用户信息对象赋值
                UserInfo userInfo = new UserInfo()
                {
                    Id = Guid.NewGuid().ToString(), // Guid.NewGuid() 获取一个不重复的guid值
                    Account = addUserInfoDto.Account,
                    UserName = addUserInfoDto.UserName,
                    PhoneNum = addUserInfoDto.PhoneNum,
                    Email = addUserInfoDto.Email,
                    DepartmentId = addUserInfoDto.DepartmentId,
                    Sex = addUserInfoDto.Sex,
                    IsAdmin = addUserInfoDto.IsAdmin,
                    CreateTime = DateTime.Now,
                    PassWord = addUserInfoDto.PassWord
                };
                // 执行添加操作并返回状态
                if (_userInfoDal.AddAsync(userInfo).Result)
                {
                    msg = "添加成功";
                    return true;
                }
                msg = "添加失败";
                return false;
            }
            catch
            {
                msg = "添加错误，服务器出现问题";
                return false;
            }
        }
        /// <summary>
        /// 根据Id查询对应用户信息业务
        /// </summary>
        /// <param name="Id">用户编号</param>
        /// <returns></returns>
        public async Task<UserInfo> FindIdUserInfo(string Id)
        {
            return await _userInfoDal.GetAsync(Id);
        }
        /// <summary>
        /// 删除用户信息业务
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        public async Task<bool> DelUserInfoBll(string[] IdList)
        {
            try
            {
                return await _userInfoDal.DelAsync(IdList);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 修改用户信息业务
        /// </summary>
        /// <param name="editUserInfoDto"></param>
        /// <returns></returns>
        public async Task<bool> UdpateUserInfo(EditUserInfoDto editUserInfoDto)
        {
            try
            {
                UserInfo userInfo = await _userInfoDal.GetAsync(editUserInfoDto.Id);
                userInfo.Account = editUserInfoDto.Account;
                userInfo.UserName = editUserInfoDto.UserName;
                userInfo.PhoneNum = editUserInfoDto.PhoneNum;
                userInfo.Email = editUserInfoDto.Email;
                userInfo.DepartmentId = editUserInfoDto.DepartmentId;
                userInfo.Sex = editUserInfoDto.Sex;
                userInfo.IsAdmin = editUserInfoDto.IsAdmin;
                return await _userInfoDal.EditAsync(userInfo);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取用户id和名称作为下拉框数据业务
        /// </summary>
        /// <returns></returns>
        public List<SelectOptionsDto> GetSelectInfoBll()
        {
            return _userInfoDal.GetAll().Select(u => new SelectOptionsDto { Value = u.Id, Title = u.UserName }).ToList();
        }
        /// <summary>
        /// 获取到当前角色拥有的用户
        /// </summary>
        /// <param name="RoleId">角色Id</param>
        /// <returns></returns>
        public List<string> GetBindUserInfo(string RoleId)
        {
            return _r_UserInfo_RoleInfoDal.GetAll().Where(r => r.RoleId.Equals(RoleId)).Select(r => r.UserId).ToList();
        }
        /// <summary>
        /// 校验修改用户基本信息数据
        /// </summary>
        /// <param name="editUserBaseInfoDto">修改用户基本信息dto</param>
        /// <returns></returns>
        public UserInfoEnums EditUserBaseInfoCheck(EditUserBaseInfoDto editUserBaseInfoDto)
        {
            if (editUserBaseInfoDto.PhoneNum == null)
            {

            }
            else if (!Regex.IsMatch(editUserBaseInfoDto.PhoneNum, @"^1[3456789]\d{9}$"))
            {
                return UserInfoEnums.PhoneNumError;
            }
            if (editUserBaseInfoDto.Email == null)
            {

            }
            else if (!Regex.IsMatch(editUserBaseInfoDto.Email, @"^[1-9][0-9]{4,}@qq.com$"))
            {
                return UserInfoEnums.EmailErro;
            }
            return UserInfoEnums.CheckSuccess;
        }
        /// <summary>
        /// 修改用户基本资料业务
        /// </summary>
        /// <param name="editUserBaseInfo">修改用户基本资料dto</param>
        /// <returns></returns>
        public async Task<UserInfoEnums> UpdateUserBaseInfo(EditUserBaseInfoDto editUserBaseInfo)
        {
            if (EditUserBaseInfoCheck(editUserBaseInfo) == UserInfoEnums.CheckSuccess)
            {
                // 根据账号查询到对应的用户信息
                UserInfo userInfo = await _userInfoDal.GetAll().FirstOrDefaultAsync(u => u.Account == editUserBaseInfo.Account);
                // 判断是否查询到对应的用户信息
                if (userInfo != null)
                {
                    userInfo.PhoneNum = editUserBaseInfo.PhoneNum;
                    userInfo.Email = editUserBaseInfo.Email;
                    // 判断是否修改成功
                    if (await _userInfoDal.EditAsync(userInfo))
                    {
                        return UserInfoEnums.EditUserInfoSuccess;
                    }
                    return UserInfoEnums.EditUserInfoError;
                }
                return UserInfoEnums.UserInfoNotExist;
            }
            return EditUserBaseInfoCheck(editUserBaseInfo);
        }
    }
}
