using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Service;
using View = WebAPI.Component.BlogPost.Controller.View;

namespace WebAPI.Component.BlogPost.Service
{
    public interface IBlogPostService : IService<BlogPost>
    {
        Task<IQueryable<BlogPost>> GetAllByBlogId(int blogId);
    }
}