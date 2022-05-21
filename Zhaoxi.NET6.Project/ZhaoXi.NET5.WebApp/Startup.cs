using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZhaoXi.NET5.WebApp.Utility;

namespace ZhaoXi.NET5.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        //ConfigureServices:

        //这个方法被运行时环境调用--使用这个方法来把服务添加到容器中去=== 
        //注册IOC容器
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        //Configure：

        //这个方法被运行时环境调用,使用这个方法来配置Http请求的管道；
        //一、管道---啥是管道？
        //1.通道--Http请求的处理的过程；发起Http请求到达服务器后，服务器处理这个请求，HttpContext-Http上下文--经过多个环节的处理--最终把处理的结果写入到Reposne---结果返回给客户端；

        //二、如果Configure 啥也不干~~注释所有的代码,---响应404---404找不到资源--谁响应的？--服务器
        //1.无论怎么访问这个ip+端口----都是404---这个方法是配置了请求级处理--配置好了以后，任何一个请求来了，都必须要贯穿这个过程；

        //2.app来配置的：IApplicationBuilder，是一个建造者；   a. new建造者   b.use   c.build下
        //3.use中的参数---接受一个RequestDelegate 委托，返回一个RequestDelegate委托

        //三、asp.net core 底层设计这个管道有什么好处？
        //1.任意环节，可以自由扩展；

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            {
                //Func<RequestDelegate, RequestDelegate> middleware = new Func<RequestDelegate, RequestDelegate>(this.Show);
            }
            {
                //Func<RequestDelegate, RequestDelegate> middleware = new Func<RequestDelegate, RequestDelegate>(next =>
                //{
                //    return new RequestDelegate(context =>
                //    { 
                //        Task task= Task.Run(() =>
                //        {
                //            context.Response.WriteAsync("<p>==========this is Middleware 01 Start=============</p>");
                //            context.Response.WriteAsync("<p>==========this is Middleware 01 End=============</p>");
                //        }); 
                //        return task;
                //    });
                //}); 
            }

            {
                //Func<RequestDelegate, RequestDelegate> middleware = next =>
                //{
                //    return new RequestDelegate(context =>
                //    {
                //        Task task = Task.Run(() =>
                //        {
                //            context.Response.WriteAsync("<p>==========this is Middleware 01 Start=============</p>");
                //            context.Response.WriteAsync("<p>==========this is Middleware 01 End=============</p>");
                //        });
                //        return task;
                //    });
                //};
            }

            {
                //Func<RequestDelegate, RequestDelegate> middleware = next =>
                //{
                //    return context =>
                //    {
                //        return Task.Run(() =>
                //        {
                //            context.Response.WriteAsync("<p>==========this is Middleware 01 Start=============</p>");
                //            context.Response.WriteAsync("<p>==========this is Middleware 01 End=============</p>");
                //        });
                //    };
                //};
            }

            {
                //     Func<RequestDelegate, RequestDelegate> middleware = next =>
                //context =>
                //{
                //    return Task.Run(() =>
                //    {
                //        context.Response.WriteAsync("<p>==========this is Middleware 01 Start=============</p>");
                //        context.Response.WriteAsync("<p>==========this is Middleware 01 End=============</p>");
                //    });
                //};
            }
             
            {
                //    Func<RequestDelegate, RequestDelegate> middleware = next =>
                //async context =>
                //{
                //    await context.Response.WriteAsync("<p>==========this is Middleware 01 Start=============</p>");
                //    await context.Response.WriteAsync("<p>==========this is Middleware 01 End=============</p>");
                //};
            }
            {
                //   Func<RequestDelegate, RequestDelegate> middleware = next =>
                //async context =>
                //{
                //    await context.Response.WriteAsync("<p>==========this is Middleware 01 Start=============</p>");
                //    await next.Invoke(context);
                //    await context.Response.WriteAsync("<p>==========this is Middleware 01 End=============</p>");
                //};

                //   app.Use(middleware);//装配处理环节

                //   Func<RequestDelegate, RequestDelegate> middleware2 = next =>
                //   async context =>
                //   {
                //       await context.Response.WriteAsync("<p>==========this is Middleware 02 Start=============</p>");
                //       await next.Invoke(context);
                //       await context.Response.WriteAsync("<p>==========this is Middleware 02 End=============</p>");
                //   };

                //   app.Use(middleware2);//装配处理环节

                //   Func<RequestDelegate, RequestDelegate> middleware3 = next =>
                //   async context =>
                //   {
                //       await context.Response.WriteAsync("<p>==========this is Middleware 03 Start=============</p>");
                //       await context.Response.WriteAsync("<p>==========this is Middleware 03 End=============</p>");
                //   };

                //   app.Use(middleware3);//装配处理环节
            }


            //这就是我们装配的管道---middleware 中间件；管道的装配，就是把多个中间件，给装配起来；
            //app.Use(next => async context =>
            // {
            //     await context.Response.WriteAsync("<p>==========this is Middleware 01 Start=============</p>");
            //     await next.Invoke(context);
            //     await context.Response.WriteAsync("<p>==========this is Middleware 01 End=============</p>");
            // });

            //app.Use(next => async context =>
            //{
            //    await context.Response.WriteAsync("<p>==========this is Middleware 02 Start=============</p>");
            //    await next.Invoke(context);
            //    await context.Response.WriteAsync("<p>==========this is Middleware 02 End=============</p>");
            //});//装配处理环节

            //app.Use(next => async context =>
            //{
            //    await context.Response.WriteAsync("<p>==========this is Middleware 2.5 Start=============</p>");
            //    await next.Invoke(context);
            //    await context.Response.WriteAsync("<p>==========this is Middleware 2.5 End=============</p>");
            //});//装配处理环节


            //app.Use(next => async context =>
            //{
            //    await context.Response.WriteAsync("<p>==========this is Middleware 03 Start=============</p>");
            //    await context.Response.WriteAsync("<p>==========this is Middleware 03 End=============</p>");
            //});//装配处理环节

            //底层究竟是怎么做的？ 想不想听听底层究竟是怎么做的？ 想听刷一个6666； 翻翻源码；

            //看.NET5 底层源码：
            //1.在底层定义了一个结合，保存Func<RequestDelegate, RequestDelegate> 的集合_components；
            //2.调用use方法--就是把委托保存到集合中去了
            //3.ApplicationBuilder 是一个应用程序的建造者，最后必然会执行Build方法
            //4.执行到build后，定义了一个RequestDalagate 委托；把_components集合翻转下，  循环翻转后的集合
            //5.循环第一次，把定义好的响应404的委托当做参数传进来---  把最后use的这个中间件返回了---  响应404的委托 失效了，返回的中间件赋值给之前定义的响应404的变量
            //6.循环第二次：  传进来的参数，是循环第一次得到的结果，第二个委托，把传进来的参数包裹了一层； 两层嵌套的委托，返回回去；赋值给之前定义的好的响应404的委托；
            //7.循环第三次：把之前循环执行的结果，当做参数传递进来，包裹了一层委托；  返回回去了；装配了处理的环节；


            //请求来了以后，就按照装配的这个顺序去执行呗~~  到现在还没有懵逼应该刷个666   

            //app.UserShow();

            //app.Map("home", app =>
            //{
            //    app.Use(); ;//
            //});

              
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }

        //ConfigureServices：服务保存到容器中；---服务还是用来在某一个环节中处理的逻辑；
        //Configure:配置处理环节---10个环节的处理--处理每个环节，都需要独立的服务来处理；独立的服务-在容器中；

        //ConfigureServices:  配置每个环节做什么；
        //Configure:  有多少个环节；


        public RequestDelegate Show(RequestDelegate requestDelegate)
        {
            return null;
        }

    }
}
