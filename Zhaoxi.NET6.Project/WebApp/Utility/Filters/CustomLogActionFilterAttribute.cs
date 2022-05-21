using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Utility.Filters
{
    public class CustomLogActionFilterAttribute : Attribute, IActionFilter
    {

        private readonly ILogger<CustomLogActionFilterAttribute> _logger;

        public CustomLogActionFilterAttribute(ILogger<CustomLogActionFilterAttribute> logger)
        { 
            _logger = logger;
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"参数：{Newtonsoft.Json.JsonConvert.SerializeObject(context.HttpContext.Request.Query)}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"执行结果：{Newtonsoft.Json.JsonConvert.SerializeObject(context.Result)}");
        }
    }
}
