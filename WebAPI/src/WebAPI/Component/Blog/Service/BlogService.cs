using WebAPI.Component.Blog.Repository;
using WebAPI.Core.Repository;
using WebAPI.Core.Service;

namespace WebAPI.Component.Blog.Service
{
    public class BlogService : Service<Blog>, IBlogService
    {
        public BlogService(IBlogRepository repository) : base(repository)
        {
        }
    }
}
