using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
//
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PieShop
{
    public class Startup
    {
        //---------------Start of connecting database ---------------
        //You have to set up the configuration class so it can be use to find the "DefaultConnection" in appsetting
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.Which you can use for depenency injection
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //---------------End of connecting database ---------------

            //Two services I added
            //AddScoped will create an instance of MockPieRepository as IPieRepository that will disapper when the request is over
            //Whenever a class is going to require any of these type they will be injected automatically by the build in dependency injection system
            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Allows the app u redirect http request to https 
            app.UseHttpsRedirection();
            //Allows app to serve static files such as images,js,css,etc
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //This code is responsible to map incoming request to correct route(controller/action)  
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{Id?}"

                );
            });
        }
    }
}
