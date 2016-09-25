using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Component.BlogPost.Repository
{
    public class BlogPostRepository : Repository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(DbContext context) : base(context) { }

        public async Task<IQueryable<BlogPost>> FindAllByBlogId(int blogId)
        {
            return await Task.Run(() => findAllByBlogId(blogId) );
        }

        private IQueryable<BlogPost> findAllByBlogId(int blogId)
        {
            return FindBy(p => p.BlogId == blogId);
        }
    }
}
