using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Utility.Filters
{
    public class CustomCacheActionFilterAttribute : Attribute, IActionFilter
    {

        private readonly static Dictionary<string, object> CacheDictionary = new Dictionary<string, object>();


        public void OnActionExecuting(ActionExecutingContext context)
        {
            //在这里就可以先判断缓存
            string key = context.HttpContext.Request.Path;
            if (CacheDictionary.ContainsKey(key))
            {
                //就和一个断路器一样：只要是对 context.Result 赋值，就不再继续往后，直接响应给请求方
                context.Result = (IActionResult)CacheDictionary[key];
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string key = context.HttpContext.Request.Path;
            if (context.Result != null)
            {
                CacheDictionary[key] = context.Result;
            }
        }
    }
}
