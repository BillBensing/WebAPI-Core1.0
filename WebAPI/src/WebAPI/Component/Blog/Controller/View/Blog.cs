using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Controller.View;

namespace WebAPI.Component.Blog.Controller.View
{
    /// <summary>
    /// Basic Blog object
    /// </summary>
    public class Blog : AbstractView
    {
        [Required]
        public string Url { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
