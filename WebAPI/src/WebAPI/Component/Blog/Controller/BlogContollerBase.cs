using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Component.Blog.Controller.View.Builder;
using WebAPI.Component.Blog.Service;
using WebAPI.Core.Controller;

namespace WebAPI.Component.Blog.Controller
{
    
    public abstract class BlogControllerBase : AbstractController
    {
        protected readonly IBlogService _blogSvc;
        protected readonly IBlogViewBuilder _viewBldr;

        public BlogControllerBase(IBlogService blogService, IBlogViewBuilder viewBuilder)
        {
            _blogSvc = blogService;
            _viewBldr = viewBuilder;
        }

        public virtual async Task<View.BlogSummary> Create(View.Blog blog)
        {
            var newBlog = _viewBldr.NewBlog(blog);
            var model = await _blogSvc.Create(newBlog);
            var result = _viewBldr.BlogSummary(model);
            return result;
        }

        public virtual async Task<View.BlogSummary> Read(int id)
        {
            var blog = await _blogSvc.Read(id);
            var result = _viewBldr.BlogSummary(blog);
            return result;
        }

        public virtual async Task Update(int id, View.Blog blog)
        {
            var updateBlog = _viewBldr.UdpateBlog(id, blog);
            await _blogSvc.Update(updateBlog);
        }

        public virtual async Task Delete(int id)
        {
            await _blogSvc.Delete(id);
        }
    }
}