using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Reddit.Filters
{
    public class ModelValidatoinActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            var modelState = actionExecutingContext.ModelState;
            
            if (!modelState.IsValid)
            {
                actionExecutingContext.Result = new BadRequestObjectResult(modelState);
            }
        }
    }
}
