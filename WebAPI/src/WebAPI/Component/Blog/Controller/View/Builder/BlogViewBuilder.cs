using System;
using Model = WebAPI.Component.Blog;

namespace WebAPI.Component.Blog.Controller.View.Builder
{
    public class BlogViewBuilder : IBlogViewBuilder
    {
        public Blog Blog(Model.Blog model)
        {
            return new View.Blog
            {
                Url = model.Url,
                Description = model.Description
            };
        }

        public BlogSummary BlogSummary(Model.Blog model)
        {
            return new View.BlogSummary
            {
                Id = model.Id,
                Url = model.Url,
                Description = model.Description
            };
        }

        public Model.Blog NewBlog(Blog view)
        {
            return new Model.Blog
            {
                Id = 0,
                Url = view.Url,
                Description = view.Description
            };
        }

        public Model.Blog UdpateBlog(int id, Blog view)
        {
            return new Model.Blog
            {
                Id = id,
                Url = view.Url,
                Description = view.Description
            };
        }
    }
}