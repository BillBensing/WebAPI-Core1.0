using Microsoft.Extensions.DependencyInjection;
using WebAPI.Component.Blog.Controller.View.Builder;
using WebAPI.Component.Blog.Repository;
using WebAPI.Component.Blog.Service;
using WebAPI.Core.Factory;
using WebAPI.Core.Repository;
using View = WebAPI.Component.Blog.Controller.View;

namespace WebAPI.Component.Blog.Config
{
    public static class BlogServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IBlogRepository, BlogRepository>();

            services.AddSingleton<IFactory<View.Blog>, Factory<View.Blog>>();
            services.AddSingleton<IBlogViewBuilder, BlogViewBuilder>();
            services.AddSingleton<IBlogService, BlogService>();
        }
    }
}