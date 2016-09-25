using System;
using WebAPI.Core.Controller.View;

namespace WebAPI.Component.BlogPost.Controller.View
{
    public class BlogPostHistory : BlogPostSummary, IViewCreateHistory, IViewUpdateHistory
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}