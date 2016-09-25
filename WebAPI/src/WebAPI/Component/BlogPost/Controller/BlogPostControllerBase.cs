using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Component.BlogPost.Controller.View.Builder;
using WebAPI.Component.BlogPost.Service;
using WebAPI.Core.Controller;

namespace WebAPI.Component.BlogPost.Controller
{
    public class BlogPostControllerBase : AbstractController
    {
        protected readonly IBlogPostService _blogPostSvc;
        protected readonly IBlogPostViewBuilder _viewBldr;

        public BlogPostControllerBase(IBlogPostService blogPostService, IBlogPostViewBuilder viewBuilder)
        {
            _blogPostSvc = blogPostService;
            _viewBldr = viewBuilder;
        }

        public virtual async Task<View.BlogPostSummary> Create(int blogId, [FromBody] View.BlogPost blogPost)
        {
            var newPost = _viewBldr.ToBlogPostModel(blogId, blogPost);
            var model = await _blogPostSvc.Create(newPost);
            var result = _viewBldr.ToBlogPostSummaryView(model);
            return result;
        }

        public virtual async Task<View.BlogPostSummary> Read(int blogId, int postId)
        {
            var post = await _blogPostSvc.Read(postId);
            var result = _viewBldr.ToBlogPostSummaryView(post);
            return result;
        }


        public virtual async Task Update(int blogId, int postId, [FromBody] View.BlogPost blogPost)
        {
            var model = _viewBldr.ToBlogPostModel(blogId, postId, blogPost);
            await _blogPostSvc.Update(model);
        }

        public virtual async Task Delete(int blogId, int postId)
        {
            await _blogPostSvc.Delete(postId);
        }
    }
}