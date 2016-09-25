using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Component.Blog.Controller.View.Builder;
using WebAPI.Component.Blog.Service;
using System;
using WebAPI.Component.Blog.Controller.Decorator;
using Microsoft.Extensions.Logging;

namespace WebAPI.Component.Blog.Controller
{
    [Route("api/blog")]
    [Produces("application/json")]
    public class BlogController : BlogControllerLogging, IBlogController
    {

        public BlogController(IBlogService blogService, IBlogViewBuilder viewBuilder, ILogger<BlogController> logger) 
            : base(blogService, viewBuilder, logger) { }

        [HttpPost]
        public async new Task<IActionResult> Create([FromBody] View.Blog blog)
        {
            IActionResult result;
            try
            {
                var newBlog = await base.Create(blog);
                result = Ok(newBlog);
            }
            catch (Exception)
            {
                result = StatusCode(500);
            }
            return result;
        }

        [HttpGet("{id}")]
        public async new Task<IActionResult> Read(int id)
        {
            IActionResult result;
            try
            {
                var blog = await base.Read(id);
                result = (blog != null) ? Ok(blog) : NotFound() as IActionResult;
            }
            catch (Exception)
            {
                result = StatusCode(500);
            }
            return result;
        }

        [HttpDelete("{id}")]
        public async new Task<IActionResult> Delete(int id)
        {
            IActionResult result;
            try
            {
                await base.Delete(id);
                result = NoContent();
            }
            catch (Exception)
            {
                result = StatusCode(500);
            }
            return result;
        }

        [HttpPut("{id}")]
        public async new Task<IActionResult> Update(int id, [FromBody] View.Blog blog)
        {
            IActionResult result;
            try
            {
                await base.Update(id, blog);
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