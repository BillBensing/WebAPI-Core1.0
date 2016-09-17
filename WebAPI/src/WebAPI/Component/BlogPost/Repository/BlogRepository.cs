using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Repository;

namespace WebAPI.Component.BlogPost.Repository
{
    public class BlogPostRepository : Repository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(DbContext context) : base(context)
        {
        }
    }
}
