using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Component.BlogPost.Controller.Decorator;
using WebAPI.Component.BlogPost.Controller.View.Builder;
using WebAPI.Component.BlogPost.Service;
using System.Threading.Tasks;
using System;

namespace WebAPI.Component.BlogPost.Controller
{
    [Route("api/blog")]
    public class BlogPostController : BlogPostControllerLogging, IBlogPostController
    {
        public BlogPostController(
            IBlogPostService blogPostService, 
            IBlogPostViewBuilder viewBuilder,
            ILogger<BlogPostController> logger) 
            : base(blogPostService, viewBuilder, logger) { }

        [HttpPost("{blogId}/post")]
        public new async Task<IActionResult> Create(int blogId, [FromBody] View.BlogPost blogPost)
        {
            IActionResult result;
            try
            {
                var post = await base.Create(blogId, blogPost);
                result = Ok(post);
            }
            catch (Exception)
            {
                result = StatusCode(500);
            }
            return result;
        }

        [HttpGet("{blogId}/post")]
        public new async Task<IActionResult> ReadAll(int blogId)
        {
            IActionResult result;
            try
            {
                var posts = await base.ReadAll(blogId);
                result = Ok(posts);
            }
            catch (Exception)
            {
                result = StatusCode(500);
            }
            return result;
        }

        [HttpGet("{blogId}/post/{postId}")]
        public new async Task<IActionResult> Read(int blogId, int postId)
        {
            IActionResult result;
            try
            {
                var post = await base.Read(blogId,postId);
                result = (post != null) ? Ok(post) : NotFound() as IActionResult;
            }
            catch (Exception)
            {
                result = StatusCode(500);
            }
            return result;
        }

        [HttpPut("{blogId}/post/{postId}")]
        public new async Task<IActionResult> Update(int blogId, int postId, [FromBody] View.BlogPost blogPost)
        {
            IActionResult result;
            try
            {
                await base.Update(blogId, postId, blogPost);
                result = NoContent();
            }
            catch (Exception)
            {
                result = StatusCode(500);
            }
            return result;
        }

        [HttpDelete("{blogId}/post/{postId}")]
        public new async Task<IActionResult> Delete(int blogId, int postId)
        {
            IActionResult result;
            try
            {
                await base.Delete(blogId, postId);
                result = NoContent();
            }
            catch (Exception)
            {
                result = StatusCode(500);
            }
            return result;
        }
    }
}