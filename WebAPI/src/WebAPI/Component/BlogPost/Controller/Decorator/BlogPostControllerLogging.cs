using Microsoft.Extensions.Logging;
using WebAPI.Component.BlogPost.Controller.View.Builder;
using WebAPI.Component.BlogPost.Service;

namespace WebAPI.Component.BlogPost.Controller.Decorator
{
    public class BlogPostControllerLogging : BlogPostControllerBase
    {
        protected readonly ILogger _logger;

        public BlogPostControllerLogging(
            IBlogPostService blogPostService,
            IBlogPostViewBuilder viewBuilder,
            ILogger logger) : base(blogPostService, viewBuilder)
        {
            _logger = logger;
        }
    }
}
