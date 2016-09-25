using Microsoft.Extensions.DependencyInjection;
using WebAPI.Component.BlogPost.Controller.View.Builder;
using WebAPI.Component.BlogPost.Repository;
using WebAPI.Component.BlogPost.Service;
using WebAPI.Core.Builders.ObjectBuilder;
using WebAPI.Core.Factory;
using View = WebAPI.Component.BlogPost.Controller.View;
using Model = WebAPI.Component.BlogPost;
using WebAPI.Core.Controller.Pagination;

namespace WebAPI.Component.Blog.Config
{
    public static class BlogPostServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IBlogPostRepository, BlogPostRepository>();

            services.AddSingleton<IObjectBuilder<Model.BlogPost, View.BlogPostSummary>, View.BlogPostSummaryObjectBuilder>();
            services.AddSingleton<IObjectBuilder<Model.BlogPost, View.BlogPost>, View.BlogPostObjectBuilder>();
            services.AddSingleton<IFactory<View.BlogPost>, Factory<View.BlogPost>>();

            services.AddSingleton<IBlogPostViewBuilder, BlogPostViewBuilder>();

            services.AddSingleton<IBlogPostService, BlogPostService>();

            services.AddSingleton<IPaginationBuilder<View.BlogPostSummary>, PaginationBuilder<View.BlogPostSummary>>();
        }
    }
}