using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sister.Dtos.UserInfo
{
    public class AddUserInfoDto
    {
        public string Id { get; set; }
        public string Account { get; set; }
        public string UserName { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string DepartmentId { get; set; }
        public int Sex { get; set; }
        public bool IsAdmin { get; set; }
        public string CreateTime { get; set; }
        public string PassWord { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string TwoPassWord { get; set; }
    }
}
