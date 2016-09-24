using WebAPI.Component.BlogPost.Repository;
using WebAPI.Core.Repository;
using WebAPI.Core.Service;

namespace WebAPI.Component.BlogPost.Service
{
    public class BlogPostService : Service<BlogPost>, IBlogPostService
    {
        public BlogPostService(IBlogPostRepository repository) : base(repository)
        {
        }
    }
}
