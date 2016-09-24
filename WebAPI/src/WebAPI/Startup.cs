using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAPI.Core.Repository.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        /** This method gets called by the runtime. Use this method to add services to the container. **/
        public void ConfigureServices(IServiceCollection services)
        {
            /** Register Entity Framework **/
            services.AddDbContext<DefaultDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            /** Register ASP.NET Framework **/
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultTokenProviders();

            /** Register WebAPI MVC Framework **/
            services.AddMvc()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();  // Serializes all return objects as JSON by default
                    });

            /** Register Services, Repositories & DbContexts **/            
            Core.Config.ServicesRegistration.RegisterServices(services);  // Manages regsitration of all component services

        }

        /** This method gets called by the runtime. Use this method to configure the HTTP request pipeline. **/
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}