using System.Collections.Generic;
using BlogPostComponent = WebAPI.Component.BlogPost;
using WebAPI.Core.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Component.Blog
{
    public class Blog : AuditableEntity<int>
    {
        public Blog()
        {
            BlogPosts = new List<BlogPostComponent.BlogPost>().AsQueryable();
        }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Description { get; set; }

        public IQueryable<BlogPostComponent.BlogPost> BlogPosts { get; set; }
    }
}