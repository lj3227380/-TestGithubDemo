using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Utility.Filters
{
    public class CustomActionFilterAttribute : Attribute, IActionFilter
    { 
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("CustomActionFilterAttribute.OnActionExecuting");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("CustomActionFilterAttribute.OnActionExecuted");
        }
    }
}
