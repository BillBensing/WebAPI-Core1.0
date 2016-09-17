using BlogComponent = WebAPI.Component.Blog;
using WebAPI.Core.Entity;

namespace WebAPI.Component.BlogPost
{
    public class BlogPost : AuditableEntity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public BlogComponent.Blog Blog { get; set; }
    }
}