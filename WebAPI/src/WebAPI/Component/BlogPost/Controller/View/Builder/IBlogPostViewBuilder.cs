﻿using System.Linq;
using Model = WebAPI.Component.BlogPost;

namespace WebAPI.Component.BlogPost.Controller.View.Builder
{
    public interface IBlogPostViewBuilder
    {
        BlogPost ToBlogPostView(Model.BlogPost model);
        BlogPostSummary ToBlogPostSummaryView(Model.BlogPost model);
        IQueryable<BlogPostSummary> ToBlogPostSummaryView(IQueryable<Model.BlogPost> models);
        Model.BlogPost ToBlogPostModel(int blogId, BlogPost view);
        Model.BlogPost ToBlogPostModel(int blogId, int postId, BlogPost view);
    }
}
