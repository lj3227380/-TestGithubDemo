using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Utility.Filters
{
    public class CustomCacheResourceFilterAttribute : Attribute, IResourceFilter
    {

        private readonly static Dictionary<string, object> CacheDictionary = new Dictionary<string, object>();

        /// <summary>
        /// 在XX资源之前
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //在这里就可以先判断缓存
            string key = context.HttpContext.Request.Path;
            if (CacheDictionary.ContainsKey(key))
            {
                //就和一个断路器一样：只要是对 context.Result 赋值，就不再继续往后，直接响应给请求方
                context.Result = (IActionResult)CacheDictionary[key];
            }
            Console.WriteLine("CustomResourceFilterAttribute.OnResourceExecuting");
        }

        /// <summary>
        /// 在XX资源之后
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnResourceExecuted(ResourceExecutedContext context)
        { 
            string key = context.HttpContext.Request.Path;
            if (context.Result!=null)
            {
                CacheDictionary[key] = context.Result;
            } 
            Console.WriteLine("CustomResourceFilterAttribute.OnResourceExecuted");
        }
    }
}
