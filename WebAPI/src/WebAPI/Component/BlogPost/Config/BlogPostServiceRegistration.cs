using Microsoft.Extensions.DependencyInjection;
using WebAPI.Component.BlogPost.Controller.View.Builder;
using WebAPI.Component.BlogPost.Repository;
using WebAPI.Component.BlogPost.Service;
using WebAPI.Core.Factory;
using View = WebAPI.Component.BlogPost.Controller.View;

namespace WebAPI.Component.Blog.Config
{
    public static class BlogPostServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IBlogPostRepository, BlogPostRepository>();

            services.AddSingleton<IFactory<View.BlogPost>, Factory<View.BlogPost>>();
            services.AddSingleton<IBlogPostViewBuilder, BlogPostViewBuilder>();
            services.AddSingleton<IBlogPostService, BlogPostService>();
        }
    }
}