using EmployeeManagement.Filters;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Infrastructure.Interfaces;
using EmployeeManagement.Models.Infrastructure.Interfaces.Services;
using EmployeeManagement.Models.Infrastructure.Repositories;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // ���������� ���������
            services.AddDbContext<DataContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionStrings:EmployeeConnection"]);
                opts.EnableSensitiveDataLogging(true);
            });

            // ����������� �����������
            services.AddScoped<IDataRepository, DataRepository>();

            // ����������� ��������
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            // ���������� ������������ � ��������������� � ������� Razor
            services.AddControllersWithViews(options =>
            {
                // ���������� ������� ��������������� OperationCancelledException
                options.Filters.Add<OperationCancelledExceptionFilter>();
            }).AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            // // ���������� ���������� ������� ����� ����� �������� �����
            // SeedData.SeedDatabase(context);
        }
    }
}
