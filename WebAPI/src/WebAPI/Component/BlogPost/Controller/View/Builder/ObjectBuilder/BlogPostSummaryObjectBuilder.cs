using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Component.BlogPost.Controller.View.Builder;
using WebAPI.Core.Builders.ObjectBuilder;
using WebAPI.Core.Factory;
using Model = WebAPI.Component.BlogPost;

namespace WebAPI.Component.BlogPost.Controller.View
{
    public class BlogPostSummaryObjectBuilder : ObjectBuilder<Model.BlogPost, View.BlogPostSummary>
    {
        protected IFactory<BlogPost> _factory;

        public BlogPostSummaryObjectBuilder(IFactory<BlogPost> factory)
        {
            _factory = factory;
        }
        public override BlogPostSummary ToObject(Model.BlogPost fromObject)
        {
            var result = _factory.Create(BlogPostEnumerator.BlogPostSummary) as BlogPostSummary;
            result.Id = fromObject.Id;
            result.BlogId = fromObject.BlogId;
            result.Content = fromObject.Content;
            result.Title = fromObject.Title;
            return result;
        }
    }
}
