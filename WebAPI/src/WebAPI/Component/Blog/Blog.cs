using System.Collections.Generic;
using BlogPostComponent = WebAPI.Component.BlogPost;
using WebAPI.Core.Entity;
using System.Linq;

namespace WebAPI.Component.Blog
{
    public class Blog : AuditableEntity<int>
    {
        public Blog()
        {
            BlogPosts = new List<BlogPostComponent.BlogPost>().AsQueryable();
        }
        public string Url { get; set; }
        public IQueryable<BlogPostComponent.BlogPost> BlogPosts { get; set; }
    }
}