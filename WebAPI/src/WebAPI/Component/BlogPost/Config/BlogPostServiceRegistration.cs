using Microsoft.Extensions.DependencyInjection;
using WebAPI.Component.BlogPost.Repository;
using WebAPI.Component.BlogPost.Service;

namespace WebAPI.Component.Blog.Config
{
    public static class BlogPostServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IBlogPostRepository, BlogPostRepository>();
            services.AddSingleton<IBlogPostService, BlogPostService>();
        }
    }
}