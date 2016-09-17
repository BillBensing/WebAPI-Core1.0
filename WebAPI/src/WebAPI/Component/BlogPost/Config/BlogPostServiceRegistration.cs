using Microsoft.Extensions.DependencyInjection;
using WebAPI.Component.BlogPost.Repository;
using WebAPI.Component.BlogPost.Service;
using WebAPI.Core.Repository;
using Entity = WebAPI.Component.BlogPost;

namespace WebAPI.Component.Blog.Config
{
    public static class BlogPostServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IRepository<Entity.BlogPost>, Repository<Entity.BlogPost>>();
            services.AddSingleton<IBlogPostRepository, BlogPostRepository>();
            services.AddSingleton<IBlogPostService, BlogPostService>();
        }
    }
}