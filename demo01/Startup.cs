using BLL;
using Common.Filter;
using DAL;
using IDepositoryBll;
using IDepositoryDal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools;

namespace demo01
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // 此方法由运行时调用。 使用此方法向容器添加服务
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // 注入session服务
            services.AddSession();
            // 注入数据库上下文对象
            services.AddDbContext<DepositoryContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("MvcMovieContext")));
            // 注册全局过滤器（登录校验用）
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(LoginFilter));
            });
            // 注入仓储层和业务层服务
            AddICustomIOC(services);
        }
        private static IServiceCollection AddICustomIOC(IServiceCollection services)
        {
            
            // 注入md5加密服务
            services.AddScoped<MD5Encrypt>();
            // 注入用户管理dal层服务
            services.AddScoped<IUserInfoDal, UserInfoDal>();
            // 注入用户管理bll层服务
            services.AddScoped<IUserInfoBll,UserInfoBll>();
            // 注入部门管理dal层服务
            services.AddScoped<IDepartmentInfoDal, DepartmentInfoDal>();
            // 注入部门管理bll层服务
            services.AddScoped<IDepartmentInfoBll, DepartmentInfoBll>();
            // 注入登录bll服务
            services.AddScoped<IAccountBll,AccountBll>();
            return services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession(); // 添加session服务

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=LoginView}/{id?}");
            });
        }
    }
}
