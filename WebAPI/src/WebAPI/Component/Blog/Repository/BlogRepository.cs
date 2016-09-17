using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Repository;

namespace WebAPI.Component.Blog.Repository
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(DbContext context) : base(context)
        {
        }
    }
}
