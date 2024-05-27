
using EmployeeSignInSystem.Repositories;
using EmployeeSignInSystem.Services;
using EmployeeSignInSystem.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSignInSystem.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;

namespace Employee.SignIn.System
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<EmployeeSigningSystemContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Conn")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<EmployeeSigningSystemContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, EmployeeSigningSystemContext, Guid>>()
                .AddRoleStore<RoleStore<ApplicationRole, EmployeeSigningSystemContext, Guid>>();


            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ApplicationUser, ApplicationUser>();
            //services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<Microsoft.AspNetCore.Identity.UserManager<ApplicationUser>, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser>>();
           
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IGuardService, GuardService>();
            services.AddScoped<IGuardRepository, GuardRepository>();
            
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //if identity cookie present in browser, auto submit to server
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Main}/{id?}");
            });
        }
    }
}

