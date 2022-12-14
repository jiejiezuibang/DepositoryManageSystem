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
                options.Filters.Add<LoginFilter>();
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
            // 注入角色管理dal服务
            services.AddScoped<IRoleInfoDal, RoleInfoDal>();
            // 注入角色管理bll服务
            services.AddScoped<IRoleInfoBll, RoleInfoBll>();
            // 注入用户角色dal服务
            services.AddScoped<IR_UserInfo_RoleInfoDal, R_UserInfo_RoleInfoDal>();
            // 注入用户角色bll服务
            services.AddScoped<IR_UserInfo_RoleInfoBll, R_UserInfo_RoleInfoBll>();
            // 注入菜单信息dal服务
            services.AddScoped<IMenuInfoDal, MenuInfoDal>();
            // 注入菜单信息bll服务
            services.AddScoped<IMenuInfoBll, MenuInfoBll>();
            // 注入角色权限dal服务
            services.AddScoped<IR_RoleInfo_MenuInfoDal, R_RoleInfo_MenuInfoDal>();
            // 注入耗材信息dal服务
            services.AddScoped<IConsumableInfoDal, ConsumableInfoDal>();
            // 注入耗材信息bll服务
            services.AddScoped<IConsumableInfoBll, ConsumableInfoBll>();
            // 注入耗材类别dal服务
            services.AddScoped<ICategoryDal, CategoryDal>();
            // 注入耗材类别bll服务
            services.AddScoped<ICategoryBll, CategoryBll>();
            // 注入耗材记录dal服务
            services.AddScoped<IConsumableRecordDal, ConsumableRecordDal>();
            // 注入耗材记录dal服务
            services.AddScoped<IConsumableRecordDal, ConsumableRecordDal>();
            // 注入工作流模板dal服务
            services.AddScoped<IWorkFlow_ModelDal, WorkFlow_ModelDal>();
            // 注入工作流模板bll服务
            services.AddScoped<IWorkFlow_ModelBll, WorkFlow_ModelBll>();
            // 注入工作流步骤dal服务
            services.AddScoped<IWorkFlow_InstanceStepDal, WorkFlow_InstanceStepDal>();
            // 注入工作流步骤bll服务
            services.AddScoped<IWorkFlow_InstanceStepBll, WorkFlow_InstanceStepBll>();
            // 注入工作流实例dal服务
            services.AddScoped<IWorkFlow_InstanceDal, WorkFlow_InstanceDal>();
            // 注入工作流实例bll服务
            services.AddScoped<IWorkFlow_InstanceBll, WorkFlow_InstanceBll>();
            // 注入文件信息dal服务
            services.AddScoped<IFileInfoDal, FileInfoDal>();
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
