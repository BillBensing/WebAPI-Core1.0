using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Component.Blog.Controller
{
    public interface IBlogController
    {
        Task<IActionResult> Create(View.Blog blog);
        Task<IActionResult> Read(int id);
        Task<IActionResult> Update(int id, View.Blog blog);
        Task<IActionResult> Delete(int id);
    }
}