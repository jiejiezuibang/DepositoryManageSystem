using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sister.Dtos.UserInfo
{
    public class UserInfoDto
    {
        public string Id { get; set; }
        public string Account { get; set; }
        public string UserName { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public char Sex { get; set; }
        public char IsAdmin { get; set; }
        public string CreateTime { get; set; }
        /// <summary>
        /// 用户数据总条数
        /// </summary>
        public int count { get; set; }
    }
}
