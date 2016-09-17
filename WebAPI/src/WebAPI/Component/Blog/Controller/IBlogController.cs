using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Component.Blog.Controller
{
    public interface IBlogController
    {
        Task<IActionResult> Create(Blog blog);
        Task<IActionResult> Read(int blogId);
        Task<IActionResult> Update(Blog blog);
        Task<IActionResult> Delete(int blogId);
    }
}
