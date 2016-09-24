using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Controller.View;

namespace WebAPI.Component.Blog.Controller.View
{
    /// <summary>
    /// Object for creating a new blog.
    /// </summary>
    public class Blog
    {
        [Required, StringLength(100)]
        public string Url { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
