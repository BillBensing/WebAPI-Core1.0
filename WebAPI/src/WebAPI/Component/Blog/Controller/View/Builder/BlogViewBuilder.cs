using WebAPI.Component.Blog.Controller.View.Factory;
using WebAPI.Core.Factory;
using Model = WebAPI.Component.Blog;

namespace WebAPI.Component.Blog.Controller.View.Builder
{
    public class BlogViewBuilder : IBlogViewBuilder
    {
        protected IBlogViewFactory _viewFactory;

        public BlogViewBuilder(IBlogViewFactory viewFactory)
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