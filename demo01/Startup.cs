using BLL;
using Common.Filter;
using DAL;
using IDepositoryDal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        // �˷���������ʱ���á� ʹ�ô˷�����������ӷ���
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // ע��session����
            services.AddSession();
            // ע��ȫ�ֹ���������¼У���ã�
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(LoginFilter));
            });
            // ע��ִ����ҵ������
            AddICustomIOC(services);
        }
        private static IServiceCollection AddICustomIOC(IServiceCollection services)
        {
            // ע���û�����dal�����
            services.AddScoped<IUserInfoDal, UserInfoDal>();
            // ע���û�����bll�����
            services.AddScoped<UserInfoBll>();
            // ע�벿�Ź���dal�����
            services.AddScoped<IDepartmentInfoDal, DepartmentInfoDal>();
            // ע�벿�Ź���bll�����
            services.AddScoped<DepartmentInfoBll>();
            // ע���¼bll����
            services.AddScoped<AccountBll>();
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

            app.UseSession(); // ���session����

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
