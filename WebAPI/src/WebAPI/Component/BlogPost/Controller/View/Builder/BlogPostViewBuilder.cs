using System.Linq;
using WebAPI.Core.Builders.ObjectBuilder;
using WebAPI.Core.Factory;
using Model = WebAPI.Component.BlogPost;

namespace WebAPI.Component.BlogPost.Controller.View.Builder
{
    public class BlogPostViewBuilder : IBlogPostViewBuilder
    {
        protected IObjectBuilder<Model.BlogPost, BlogPostSummary> _blogPostSummaryBuilder;
        protected IObjectBuilder<Model.BlogPost, BlogPost> _blogPostBuilder;

        public BlogPostViewBuilder( IObjectBuilder<Model.BlogPost, BlogPostSummary> blogPostSummaryBuilder,
                                    IObjectBuilder<Model.BlogPost, BlogPost> blogPostBuilder)
        {
            _blogPostSummaryBuilder = blogPostSummaryBuilder;
            _blogPostBuilder = blogPostBuilder;
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
            if (model == null) return _blogPostSummaryBuilder.EmptyObject();
            var result = _blogPostSummaryBuilder.ToObject(model);
            return result;
        }

        public IQueryable<BlogPostSummary> ToBlogPostSummaryView(IQueryable<Model.BlogPost> models) {

            if (!models.Any()) return _blogPostSummaryBuilder.EmptyQueryable();
            var result = _blogPostSummaryBuilder.ToQueryable(models);
            return result;
        }

        public BlogPost ToBlogPostView(Model.BlogPost model)
        {
            if (model == null) return null;
            var result = _blogPostBuilder.ToObject(model);
            return result;
        }
    }
}