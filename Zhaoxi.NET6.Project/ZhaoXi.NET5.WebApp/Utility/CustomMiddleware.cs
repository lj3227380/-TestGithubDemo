using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ZhaoXi.NET5.WebApp.Utility
{
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UserShow(this IApplicationBuilder app)
        {
            app.Use(next => async context =>
            {
                await context.Response.WriteAsync("<p>==========this is Middleware 02 Start=============</p>");
               
                await context.Response.WriteAsync("<p>==========this is Middleware 02 End=============</p>");
            });//装配处理环节

            return app;
        }
    }
}
