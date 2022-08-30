using Common.ResultEnums;
using IDepositoryBll;
using IDepositoryDal;
using Microsoft.AspNetCore.Http;
using Sister;
using Sister.Dtos.Account;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tools;

namespace BLL
{
    public class AccountBll : IAccountBll
    {
        // 注入用户管理dal
        private readonly IUserInfoDal _userInfoDal;
        // 构建md5加密dal
        MD5Encrypt mD5Encrypt = new MD5Encrypt();
        // 构建文件管理
        public readonly IFileInfoDal _fileInfoDal;
        public AccountBll(IUserInfoDal userInfoDal, IFileInfoDal fileInfoDal)
        {
            this._userInfoDal = userInfoDal;
            this._fileInfoDal = fileInfoDal;
        }
        /// <summary>
        /// 用登录业务
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public AccoutnLoginEnums DoLogin(string account, string password, out string UserName, out string Account, out string Id)
        {
            UserName = null;
            Account = null;
            Id = null;
            // 校验前端传递的值是否为空
            if (account == null)
            {
                return AccoutnLoginEnums.accountIsNull;
            }
            if (password == null)
            {
                return AccoutnLoginEnums.PwdIsNull;
            }
            // 通过account查询用户
            UserInfo userInfo = _userInfoDal.GetAll().FirstOrDefault(u => u.Account == account);
            if (userInfo == null)
            {
                return AccoutnLoginEnums.accountNotExist;
            }
            if (userInfo.PassWord.Equals(mD5Encrypt.StartEncrypy(password)))
            {
                // 获取用户对应文件信息
                Sister.FileInfo fileInfo = _fileInfoDal.GetAll().FirstOrDefault(f => f.RelationId.Equals(userInfo.Id));
                UserName = userInfo.UserName;
                Account = userInfo.Account;
                Id = userInfo.Id;
                return AccoutnLoginEnums.loginSuccess;
            }
            else
            {
                return AccoutnLoginEnums.PwdError;
            }
        }
        /// <summary>
        /// 重置用户密码业务
        /// </summary>
        public AccoutnLoginEnums ResetPwdBll(string oldPwd, string newPwd, string verifyPwd, string account)
        {
            // 通过account查询用户
            UserInfo userInfo = _userInfoDal.GetAll().FirstOrDefault(u => u.Account == account);
            // 判断用户输入的旧密码是否正确
            if (userInfo.PassWord.Equals(mD5Encrypt.StartEncrypy(oldPwd)))
            {
                // 判断用户输入的新密码和确认密码是否相同
                if (newPwd.Equals(verifyPwd))
                {
                    // 给用户赋值新密码
                    userInfo.PassWord = mD5Encrypt.StartEncrypy(newPwd);
                    // 修改密码操作
                    _userInfoDal.EditAsync(userInfo);
                    return AccoutnLoginEnums.ResetPwdSuccess;
                }
                else
                {
                    return AccoutnLoginEnums.TwoPwdError;
                }
            }
            return AccoutnLoginEnums.PwdError;
        }
        /// <summary>
        /// 上传头像业务
        /// </summary>
        /// <param name="formFile"></param>
        public AccoutnLoginEnums UploadAvatarBll(IFormFile formFile, string userId, string wwwrootPath, out string msg,out string UserAvatar)
        {
            try
            {
                UserAvatar = null;
                // 获取文件大小
                long fileSize = formFile.Length;
                // 判断文件大小是否适合上传 52428800(50mb)
                if (fileSize > 0 && fileSize < 52428800)
                {
                    // 可以上传的文件后缀名
                    List<string> filetype = new List<string>()
                        {
                            ".gif",".jpg",".jpeg",".png",".bmp"
                        };
                    // 获取文件后缀名
                    string fileExtension = Path.GetExtension(formFile.FileName);
                    // 判断文件格式是否正确
                    if (filetype.Contains(fileExtension.ToLower()))
                    {
                        // 存放头像的文件夹路径
                        string wwwroot_Avatars = Path.Combine(wwwrootPath, "Avatars");
                        // 新头像名称(时间戳)
                        string newAvatar = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() + Path.GetExtension(formFile.FileName);
                        // 最终存放头像的路径
                        string avaterPath = Path.Combine(wwwroot_Avatars, newAvatar);
                        // 获取当前登录用户文件信息
                        Sister.FileInfo fi = _fileInfoDal.GetAll().FirstOrDefault(f => f.RelationId.Equals(userId));
                        // 判断是否已经上传了头像
                        if (fi == null)
                        {
                            // 向数据库添加数据
                            Sister.FileInfo fileInfo = new Sister.FileInfo()
                            {
                                Id = Guid.NewGuid().ToString(),
                                RelationId = userId,
                                OldFileName = formFile.FileName,
                                NewFileName = newAvatar,
                                Extension = fileExtension,
                                Length = fileSize,
                                CreateTime = DateTime.Now,
                                Creator = userId,
                                Category = FileInfoCategoryEnums.图片
                            };
                            // 判断头像是否上传成功
                            if (!_fileInfoDal.AddAsync(fileInfo).Result)
                            {
                                msg = "上传头像失败";
                                return AccoutnLoginEnums.UploadAvaterError;
                            }
                        }
                        else
                        {
                            // 获取用户旧头像名称
                            string AvatarName = fi.NewFileName;
                            // 旧头像文件地址
                            string oldAvatarName = Path.Combine(wwwrootPath, "Avatars", AvatarName);
                            // 删除旧头像
                            System.IO.File.Delete(oldAvatarName);

                            // 添加新头像
                            fi.OldFileName = formFile.FileName;
                            fi.NewFileName = newAvatar;
                            fi.Extension = fileExtension;
                            fi.Length = fileSize;
                            fi.CreateTime = DateTime.Now;
                            fi.Creator = userId;
                            // 判断是否修改成功
                            if (!_fileInfoDal.EditAsync(fi).Result)
                            {
                                msg = "上传头像失败";
                                return AccoutnLoginEnums.UploadAvaterError;
                            }
                        }
                        // 上传头像
                        using (FileStream fs = new FileStream(avaterPath, FileMode.Create, FileAccess.Write))
                        {
                            formFile.CopyTo(fs);
                        }
                        UserAvatar = newAvatar;
                        msg = "上传头像成功";
                        return AccoutnLoginEnums.UploadAvatarSucess;
                    }
                    msg = "图片格式错误，上传失败";
                    return AccoutnLoginEnums.UploadAvaterError;
                }
                msg = "图片大小超过限制，上传失败";
                return AccoutnLoginEnums.UploadAvaterError;
                
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                UserAvatar = null;
                return AccoutnLoginEnums.UploadAvaterError;
            }
        }
        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserAvaterBll(string userId)
        {
            Sister.FileInfo fileInfo = _fileInfoDal.GetAll().FirstOrDefault(f => f.RelationId.Equals(userId));
            if (fileInfo == null)
            {
                return "头像a.jpg";
            }
            return fileInfo.NewFileName;
        }
    }
}
