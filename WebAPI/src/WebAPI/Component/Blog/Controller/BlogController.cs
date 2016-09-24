using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Component.Blog.Service;

namespace WebAPI.Component.Blog.Controller
{
    [Route("api/blog")]
    public class BlogController : Microsoft.AspNetCore.Mvc.Controller, IBlogController
    {
        protected readonly IBlogService _blogSvc;

        public BlogController(IBlogService blogService)
        {
            _blogSvc = blogService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Blog blog) {
            var result = await _blogSvc.Create(blog);
            return Created(string.Empty, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read(int id) {
            var result = await _blogSvc.Read(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Blog blog) {
            await _blogSvc.Update(blog);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            await _blogSvc.Delete(id);
            return NoContent();
        }
    }
}