using System.Linq;
using System.Threading.Tasks;
using WebAPI.Component.BlogPost.Repository;
using WebAPI.Core.Service;

namespace WebAPI.Component.BlogPost.Service
{
    public class BlogPostService : Service<BlogPost>, IBlogPostService
    {
        protected readonly IBlogPostRepository _blogRepo;

        public BlogPostService(IBlogPostRepository repository) : base(repository)
        {
            _blogRepo = repository;
        }

        public async Task<IQueryable<BlogPost>> GetAllByBlogId(int blogId)
        {
            var result = await _blogRepo.FindAllByBlogId(blogId);
            return result;
        }
    }
}