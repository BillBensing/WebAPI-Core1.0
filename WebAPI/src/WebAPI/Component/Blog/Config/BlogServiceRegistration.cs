using Microsoft.Extensions.DependencyInjection;
using WebAPI.Component.Blog.Repository;
using WebAPI.Component.Blog.Service;

namespace WebAPI.Component.Blog.Config
{
    public static class BlogServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IBlogRepository, BlogRepository>();
            services.AddSingleton<IBlogService, BlogService>();
        }
    }
}