using WebAPI.Core.Factory;
using Model = WebAPI.Component.BlogPost;

namespace WebAPI.Component.BlogPost.Controller.View.Builder
{
    public class BlogPostViewBuilder : IBlogPostViewBuilder
    {
        protected readonly IFactory<BlogPost> _viewFactory;

        public BlogPostViewBuilder(IFactory<BlogPost> viewFactory)
        {
            _viewFactory = viewFactory;
        }

        public Model.BlogPost ToBlogPostModel(int blogId, BlogPost view)
        {
            if (view == null) return null;
            return new Model.BlogPost
            {
                BlogId = blogId,
                Title = view.Title,
                Content = view.Content
            };
        }

        public Model.BlogPost ToBlogPostModel(int blogId, int postId, BlogPost view)
        {
            if (view == null) return null;
            var result = this.ToBlogPostModel(blogId, view);
            result.Id = postId;
            return result;            
        }

        public BlogPostSummary ToBlogPostSummaryView(Model.BlogPost model)
        {
            if (model == null) return null;

            var result = _viewFactory.Create(BlogPostEnumerator.BlogPostSummary) as BlogPostSummary;
            result.Id = model.Id;
            result.BlogId = model.BlogId;
            result.Content = model.Content;
            result.Title = model.Title;
            return result;
        }

        public BlogPost ToBlogPostView(Model.BlogPost model)
        {
            if (model == null) return null;

            var result = _viewFactory.Create(BlogPostEnumerator.BlogPost) as BlogPost;
            result.Content = model.Content;
            result.Title = model.Title;
            return result;
        }
    }
}