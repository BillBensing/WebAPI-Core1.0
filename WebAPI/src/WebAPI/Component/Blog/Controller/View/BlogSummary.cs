using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Controller.View;

namespace WebAPI.Component.Blog.Controller.View
{
    public class BlogSummary : Blog, IViewIdentifiable<int>
    {
       public int Id { get; set; }
    }
}
