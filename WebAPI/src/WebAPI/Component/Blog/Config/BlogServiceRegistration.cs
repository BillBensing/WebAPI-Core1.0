using Microsoft.Extensions.DependencyInjection;
using WebAPI.Component.Blog.Repository;
using WebAPI.Component.Blog.Service;
using WebAPI.Core.Repository;
using WebAPI.Core.Service;

namespace WebAPI.Component.Blog.Config
{
    public static class BlogServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IRepository<Blog>, Repository<Blog>>();
            services.AddSingleton<IBlogRepository, BlogRepository>();
            services.AddSingleton<IBlogService, BlogService>();
        }
    }
}