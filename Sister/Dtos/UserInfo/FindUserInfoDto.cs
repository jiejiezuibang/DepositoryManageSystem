using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sister.Dtos.UserInfo
{
    public class FindUserInfoDto
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 每页数据量
        /// </summary>
        public int limit { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
    }
}
