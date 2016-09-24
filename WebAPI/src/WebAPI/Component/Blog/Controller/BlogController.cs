using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Component.Blog.Controller.View.Builder;
using WebAPI.Component.Blog.Service;

namespace WebAPI.Component.Blog.Controller
{
    [Route("api/blog")]
    public class BlogController : Microsoft.AspNetCore.Mvc.Controller, IBlogController
    {
        protected readonly IBlogService _blogSvc;
        protected readonly IBlogViewBuilder _viewBldr;

        public BlogController(IBlogService blogService, IBlogViewBuilder viewBuilder)
        {
            _blogSvc = blogService;
            _viewBldr = viewBuilder;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] View.Blog blog) {
            var newBlog = _viewBldr.NewBlog(blog);
            var result = await _blogSvc.Create(newBlog);
            return Created(string.Empty, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read(int id) {
            var blog = await _blogSvc.Read(id);
            var result = _viewBldr.BlogSummary(blog);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] View.Blog blog) {
            var updateBlog = _viewBldr.UdpateBlog(id, blog);
            await _blogSvc.Update(updateBlog);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _blogSvc.Delete(id);
            return NoContent();
        }
    }
}