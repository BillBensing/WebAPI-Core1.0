using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Controller.View;

namespace WebAPI.Component.BlogPost.Controller.View
{
    public class BlogPost : AbstractView
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
