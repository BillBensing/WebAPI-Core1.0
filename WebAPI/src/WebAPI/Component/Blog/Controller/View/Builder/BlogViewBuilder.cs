using WebAPI.Core.Factory;
using Model = WebAPI.Component.Blog;

namespace WebAPI.Component.Blog.Controller.View.Builder
{
    /// <summary>
    /// Builder for Blog Compoent views.  Allows you to view, or models, for the controller.
    /// </summary>
    public class BlogViewBuilder : IBlogViewBuilder
    {
        protected readonly IFactory<Blog> _viewFactory;

        public BlogViewBuilder(IFactory<Blog> viewFactory)
        {
            _viewFactory = viewFactory;
        }

        public Blog Blog(Model.Blog model)
        {
            if (model == null) return null;

            var result = _viewFactory.Create(BlogViewEnumerator.Blog) as Blog;
            result.Url = model.Url;
            result.Description = model.Description;

            return result;
        }

        public BlogSummary BlogSummary(Model.Blog model)
        {
            if (model == null) return null;

            var result = _viewFactory.Create(BlogViewEnumerator.BlogSummary) as BlogSummary;
            result.Id = model.Id;
            result.Url = model.Url;
            result.Description = model.Description;

            return result;
        }

        public Model.Blog NewBlog(Blog view)
        {
            if (view == null) return null;

            return new Model.Blog
            {
                Id = 0,
                Url = view.Url,
                Description = view.Description
            };
        }

        public Model.Blog UdpateBlog(int id, Blog view)
        {
            if (view == null) return null;

            return new Model.Blog
            {
                Id = id,
                Url = view.Url,
                Description = view.Description
            };
        }
    }
}