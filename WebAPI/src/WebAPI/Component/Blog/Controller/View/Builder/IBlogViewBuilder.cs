using Model = WebAPI.Component.Blog;

namespace WebAPI.Component.Blog.Controller.View.Builder
{
    public interface IBlogViewBuilder
    {
        Blog ToBlogView(Model.Blog model);
        BlogHistory ToBlogHistoryView(Model.Blog model);
        BlogSummary ToBlogSummaryView(Model.Blog model);
        Model.Blog ToBlogModel(Blog view);
        Model.Blog ToBlogModel(int id, Blog view);
    }
}