using Microsoft.Extensions.DependencyInjection;
using WebAPI.Component.Blog.Config;

namespace WebAPI.Core.Config
{
    public class ServicesRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            BlogServiceRegistration.RegisterServices(services);
            BlogPostServiceRegistration.RegisterServices(services);
        }
    }
}