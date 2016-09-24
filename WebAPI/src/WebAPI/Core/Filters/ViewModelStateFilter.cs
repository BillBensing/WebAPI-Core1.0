using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace WebAPI.Core.Filters
{
    /// <summary>
    /// Validate if the reqeust body is formatted propery
    /// </summary>
    public class ViewModelStateFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            /** No Implementation **/
        }

        /// <summary>
        /// Evaluates ModelState and returns an error message if invalid.
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var error = context.ModelState.SelectMany(x => x.Value.Errors).First();
                if (error.ErrorMessage != null && error.ErrorMessage != String.Empty)
                    context.Result = BadReqeustObjectBuilder(error.ErrorMessage);
                else if (error.Exception?.Message != null)
                    context.Result = BadReqeustObjectBuilder(error.Exception.Message);
                else
                    context.Result = BadReqeustObjectBuilder(context.ModelState);
            }
        }

        private BadRequestObjectResult BadReqeustObjectBuilder(string message)
        {
            var result = new { Exception = message };
            return new BadRequestObjectResult(result);
        }

        private BadRequestObjectResult BadReqeustObjectBuilder(ModelStateDictionary state)
        {
            return new BadRequestObjectResult(state);
        }
    }
}
