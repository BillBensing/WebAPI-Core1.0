using WebAPI.Component.BlogPost.Service;

namespace WebAPI.Component.BlogPost.Controller
{
    public class BlogPostController : Microsoft.AspNetCore.Mvc.Controller, IBlogPostController
    {
        protected readonly IBlogPostService _blogPostSvc;
        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostSvc = blogPostService;
        }
    }
}