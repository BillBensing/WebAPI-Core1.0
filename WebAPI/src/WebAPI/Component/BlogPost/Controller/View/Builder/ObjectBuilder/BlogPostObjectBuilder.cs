using WebAPI.Component.BlogPost.Controller.View.Builder;
using WebAPI.Core.Builders.ObjectBuilder;
using WebAPI.Core.Factory;
using Model = WebAPI.Component.BlogPost;

namespace WebAPI.Component.BlogPost.Controller.View
{
    public class BlogPostObjectBuilder : ObjectBuilder<Model.BlogPost, View.BlogPost>
    {
        protected IFactory<BlogPost> _factory;

        public BlogPostObjectBuilder(IFactory<BlogPost> factory)
        {
            _factory = factory;
        }

        public override BlogPost ToObject(Model.BlogPost fromObject)
        {
            var result = _factory.Create(BlogPostEnumerator.BlogPost) as BlogPost;
            result.Content = fromObject.Content;
            result.Title = fromObject.Title;
            return result;
        }
    }
}