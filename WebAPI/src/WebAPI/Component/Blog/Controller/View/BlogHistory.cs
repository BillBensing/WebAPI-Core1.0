using System;
using WebAPI.Core.Controller.View;

namespace WebAPI.Component.Blog.Controller.View
{
    public class BlogHistory : BlogSummary, IViewCreateHistory, IViewUpdateHistory
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
