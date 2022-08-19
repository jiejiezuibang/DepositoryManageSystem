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
        /// <summary>
        /// 文件信息数据集
        /// </summary>
        public DbSet<FileInfo> FileInfos { get; set; }
        /// <summary>
        /// 用户角色数据集
        /// </summary>
        public DbSet<R_UserInfo_RoleInfo> R_UserInfo_RoleInfos { get; set; }
        /// <summary>
        /// 菜单信息数据集
        /// </summary>
        public DbSet<MenuInfo> MenuInfos { get; set; }
        /// <summary>
        /// 角色权限数据集
        /// </summary>
        public DbSet<R_RoleInfo_MenuInfo> R_RoleInfo_MenuInfos { get; set; }
        /// <summary>
        /// 耗材信息表
        /// </summary>
        public DbSet<ConsumableInfo> ConsumableInfos { get; set; }
        /// <summary>
        /// 耗材类别表
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //=> options.UseSqlServer($"server=DESKTOP-FSDTD8V\\SQLEXPRESS;database=DepositoryManageSystem;uid=sa;pwd=123");
    }
}
