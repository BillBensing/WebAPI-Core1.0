using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Component.Blog.Controller.View.Builder;
using WebAPI.Component.Blog.Service;
using WebAPI.Component.Blog.Controller.View;
using System;
using WebAPI.Component.Blog.Controller.Decorator;
using Microsoft.Extensions.Logging;

namespace WebAPI.Component.Blog.Controller
{
    [Route("api/blog")]
    public class BlogController : BlogControllerLoggingDecorator, IBlogController
    {

        public BlogController(IBlogService blogService, IBlogViewBuilder viewBuilder, ILogger logger) : base(blogService, viewBuilder, logger) { }

        [HttpPost]
        public async new Task<IActionResult> Create(View.Blog blog)
        {
            try
            {
                var result = await base.Create(blog);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async new Task<IActionResult> Read(int id)
        {
            try
            {
                var blog = await base.Read(id);
                var result = (blog != null) ? Ok(blog) : NotFound() as IActionResult;
                return result;
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async new Task<IActionResult> Delete(int id)
        {
            try
            {
                await base.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async new Task<IActionResult> Update(int id, View.Blog blog)
        {
            try
            {
                await base.Update(id, blog);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}