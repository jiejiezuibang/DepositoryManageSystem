using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.UserInfo
{
    /// <summary>
    /// 用户基本信息dto
    /// </summary>
    public class EditUserBaseInfoDto
    {
        public string Account { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
    }
}
