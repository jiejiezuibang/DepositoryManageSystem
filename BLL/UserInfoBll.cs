using DAL;
using IDepositoryDal;
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
    public class UserInfoBll
    {
        // 注入操作用户信息数据对象
        private readonly IUserInfoDal _userInfoDal;
        // 注入md5加密对象
        private readonly MD5Encrypt _mD5Encrypt1;
        public UserInfoBll(IUserInfoDal userInfoDal,MD5Encrypt mD5Encrypt)
        {
            this._userInfoDal = userInfoDal;
            this._mD5Encrypt1 = mD5Encrypt;
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
        /// <param name="findUserInfoDto"></param>
        /// <returns></returns>
        public List<UserInfoDto> GetUserInfoBll(FindUserInfoDto findUserInfoDto,out int userInfoCount)
        {
            return _userInfoDal.GetUserInfo(findUserInfoDto, out userInfoCount);
        }

        /// <summary>
        /// 添加用户信息业务
        /// </summary>
        /// <param name="addUserInfoDto"></param>
        /// <returns></returns>
        public bool AddUserInfo(AddUserInfoDto addUserInfoDto,out string msg)
        {
            try
            {
                // 根据account查询用户信息
                UserInfo userob = _userInfoDal.GetAll().FirstOrDefault(u => u.Account == addUserInfoDto.Account);
                // 判断账号是否存在
                if(userob != null)
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
                if(_userInfoDal.AddAsync(userInfo).Result)
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
    }
}
