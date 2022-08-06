using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sister
{
    public class DepositoryContext:DbContext
    {
        public DepositoryContext(DbContextOptions<DepositoryContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// 用户管理数据集
        /// </summary>
        public DbSet<UserInfo> UserInfos { get; set; }
        /// <summary>
        /// 部门管理数据集
        /// </summary>
        public DbSet<DepartmentInfo> DepartmentInfos { get; set; }
        /// <summary>
        /// 角色管理数据集
        /// </summary>
        public DbSet<RoleInfo> RoleInfos { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //=> options.UseSqlServer($"server=DESKTOP-FSDTD8V\\SQLEXPRESS;database=DepositoryManageSystem;uid=sa;pwd=123");
    }
}
