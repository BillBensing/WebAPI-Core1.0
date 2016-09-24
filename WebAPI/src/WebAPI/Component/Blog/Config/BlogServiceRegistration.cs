using Microsoft.Extensions.DependencyInjection;
using WebAPI.Component.Blog.Controller.View.Builder;
using WebAPI.Component.Blog.Repository;
using WebAPI.Component.Blog.Service;
using WebAPI.Core.Factory;
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
            services.AddSingleton<IFactory<Blog>, Factory<Blog>>();
            services.AddSingleton<IBlogViewBuilder, BlogViewBuilder>();
            services.AddSingleton<IBlogService, BlogService>();
        }
    }
}