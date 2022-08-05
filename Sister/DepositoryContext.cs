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

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<DepartmentInfo> DepartmentInfos { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //=> options.UseSqlServer($"server=DESKTOP-FSDTD8V\\SQLEXPRESS;database=DepositoryManageSystem;uid=sa;pwd=123");
    }
}
