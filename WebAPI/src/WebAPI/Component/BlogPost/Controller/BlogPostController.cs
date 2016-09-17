using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Component.BlogPost.Service;

namespace WebAPI.Component.BlogPost.Controller
{
    [Route("api/blog")]
    public class BlogPostController : Microsoft.AspNetCore.Mvc.Controller, IBlogPostController
    {
        protected readonly IBlogPostService _blogPostSvc;
        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostSvc = blogPostService;
        }

        [HttpPost("{blogId}/post")]
        public async Task<IActionResult> Create(int blogId, [FromBody]BlogPost blogPost)
        {
            var result = await _blogPostSvc.Create(blogPost);
            return Created(string.Empty, result);
        }

        [HttpGet("{blogId}/post/{postId}")]
        public async Task<IActionResult> Read(int blogId, int postId)
        {
            var result = await _blogPostSvc.Read(postId);
            return Ok(result);
        }

        [HttpPut("{blogId}/post/{postId}")]
        public async Task<IActionResult> Update(int blogId, [FromBody]BlogPost blogPost)
        {
            await _blogPostSvc.Update(blogPost);
            return NoContent();
        }

        [HttpDelete("{blogId}/post/{postId}")]
        public async Task<IActionResult> Delete(int blogId, int postId)
        {
            await _blogPostSvc.Delete(postId);
            return NoContent();
        }
    }
}