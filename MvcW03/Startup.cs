using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcW03.MyMiddlewares;
using MvcW03.Security;
using System;

namespace MvcW03
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
            services.AddMemoryCache();
        

            services.AddControllersWithViews(opt =>
            {
                opt.Filters.Add(new AuthorizeFilter());
            });

            


            services.AddSingleton<AuthHelper>();
            services.AddHttpContextAccessor();


            var cookieOptions = Configuration.GetSection("CookieAuthOptions").Get<CookieAuthOptions>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.AccessDeniedPath = cookieOptions.AccessDeniedPath;
                options.LoginPath = cookieOptions.LoginPath;
                options.LogoutPath = cookieOptions.LogoutPath;
                options.Cookie.Name = cookieOptions.Name;
                options.SlidingExpiration = cookieOptions.SlidingExpiration;
                options.ExpireTimeSpan = TimeSpan.FromSeconds(cookieOptions.Timeout); 
            });


           
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

            app.UseCookiePolicy();

            //   app.UseMiddleware<LogMiddleware>(); KEND� M�DDLEWARE �M�Z� KULLANMAK ���N YOL 1


            //   app.UseMyLogMiddleware();      KEND� M�DDLEWARE �M�Z� KULLANMAK ���N YOL 2

            app.UseRouting();

            app.UseMyLogMiddleware();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
