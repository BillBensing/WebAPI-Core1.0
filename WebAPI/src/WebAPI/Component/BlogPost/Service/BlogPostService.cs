using WebAPI.Core.Repository;
using WebAPI.Core.Service;

namespace WebAPI.Component.BlogPost.Service
{
    public class BlogPostService : Service<BlogPost>, IBlogPostService
    {
        public BlogPostService(IRepository<BlogPost> repository) : base(repository)
        {
        }
    }
}
