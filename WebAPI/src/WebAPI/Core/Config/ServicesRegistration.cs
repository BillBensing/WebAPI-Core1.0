using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Component.Blog.Config;
using WebAPI.Core.Repository.Context;

namespace WebAPI.Core.Config
{
    public class ServicesRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            /** Register Core Services **/
            services.AddScoped<DbContext, DefaultDbContext>();

            /** Register Component Services **/
            BlogServiceRegistration.RegisterServices(services);
            BlogPostServiceRegistration.RegisterServices(services);
        }
    }
}