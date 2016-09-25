using WebAPI.Core.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Component.BlogPost.Repository
{
    public interface IBlogPostRepository : IRepository<BlogPost> 
    {
        Task<IQueryable<BlogPost>> FindAllByBlogId(int blogId);
    }  
}