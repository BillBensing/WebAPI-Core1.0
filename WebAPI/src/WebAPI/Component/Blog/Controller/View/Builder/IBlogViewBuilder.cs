using Model = WebAPI.Component.Blog;

namespace WebAPI.Component.Blog.Controller.View.Builder
{
    public interface IBlogViewBuilder
    {
        Blog Blog(Model.Blog model);
        BlogSummary BlogSummary(Model.Blog model);
        Model.Blog NewBlog(Blog view);
        Model.Blog UdpateBlog(int id, Blog view);
    }
}