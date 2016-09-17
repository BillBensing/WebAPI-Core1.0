﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Component.BlogPost.Controller
{
    public interface IBlogPostController
    {
        Task<IActionResult> Create(int blogId, BlogPost blogPost);
        Task<IActionResult> Read(int blogId, int postId);
        Task<IActionResult> Update(int blogId, BlogPost blogPost);
        Task<IActionResult> Delete(int blogId, int postId);
    }
}
