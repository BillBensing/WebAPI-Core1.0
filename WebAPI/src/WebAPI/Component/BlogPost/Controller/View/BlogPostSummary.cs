using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Controller.View;

namespace WebAPI.Component.BlogPost.Controller.View
{
    public class BlogPostSummary : BlogPost, IViewIdentifiable<int>
    {
        public int Id { get; set; }

        public int BlogId { get; set; }
    }
}
