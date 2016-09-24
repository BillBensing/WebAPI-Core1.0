﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI.Component.Blog.Controller.View;
using WebAPI.Component.Blog.Controller.View.Builder;
using WebAPI.Component.Blog.Service;
using Microsoft.Extensions.Logging;

namespace WebAPI.Component.Blog.Controller.Decorator
{
    public class BlogControllerLoggingDecorator : BlogControllerBase
    {
        protected ILogger _logger;

        public BlogControllerLoggingDecorator(IBlogService blogService, IBlogViewBuilder viewBuilder, ILogger logger) : base(blogService, viewBuilder)
        {
            _logger = logger;
        }

        public override async Task<BlogSummary> Create(View.Blog blog)
        {
            try
            {
                return await base.Create(blog);
            } catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }       
        }

        public override async Task<BlogSummary> Read(int id)
        {
            try
            {
                return await base.Read(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public override Task Update(int id, View.Blog blog)
        {
            try
            {
                return base.Update(id, blog);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public override Task Delete(int id)
        {
            try
            {
                return base.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
