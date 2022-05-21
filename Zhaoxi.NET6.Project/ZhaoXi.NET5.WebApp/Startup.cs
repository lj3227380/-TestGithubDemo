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

        //�������������ʱ��������--ʹ������������ѷ�����ӵ�������ȥ=== 
        //ע��IOC����
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        //Configure��

        //�������������ʱ��������,ʹ���������������Http����Ĺܵ���
        //һ���ܵ�---ɶ�ǹܵ���
        //1.ͨ��--Http����Ĵ���Ĺ��̣�����Http���󵽴�������󣬷����������������HttpContext-Http������--����������ڵĴ���--���հѴ���Ľ��д�뵽Reposne---������ظ��ͻ��ˣ�

        //�������Configure ɶҲ����~~ע�����еĴ���,---��Ӧ404---404�Ҳ�����Դ--˭��Ӧ�ģ�--������
        //1.������ô�������ip+�˿�----����404---������������������󼶴���--���ú����Ժ��κ�һ���������ˣ�������Ҫ�ᴩ������̣�

        //2.app�����õģ�IApplicationBuilder����һ�������ߣ�   a. new������   b.use   c.build��
        //3.use�еĲ���---����һ��RequestDelegate ί�У�����һ��RequestDelegateί��

        //����asp.net core �ײ��������ܵ���ʲô�ô���
        //1.���⻷�ڣ�����������չ��

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

                //   app.Use(middleware);//װ�䴦����

                //   Func<RequestDelegate, RequestDelegate> middleware2 = next =>
                //   async context =>
                //   {
                //       await context.Response.WriteAsync("<p>==========this is Middleware 02 Start=============</p>");
                //       await next.Invoke(context);
                //       await context.Response.WriteAsync("<p>==========this is Middleware 02 End=============</p>");
                //   };

                //   app.Use(middleware2);//װ�䴦����

                //   Func<RequestDelegate, RequestDelegate> middleware3 = next =>
                //   async context =>
                //   {
                //       await context.Response.WriteAsync("<p>==========this is Middleware 03 Start=============</p>");
                //       await context.Response.WriteAsync("<p>==========this is Middleware 03 End=============</p>");
                //   };

                //   app.Use(middleware3);//װ�䴦����
            }


            //���������װ��Ĺܵ�---middleware �м�����ܵ���װ�䣬���ǰѶ���м������װ��������
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
            //});//װ�䴦����

            //app.Use(next => async context =>
            //{
            //    await context.Response.WriteAsync("<p>==========this is Middleware 2.5 Start=============</p>");
            //    await next.Invoke(context);
            //    await context.Response.WriteAsync("<p>==========this is Middleware 2.5 End=============</p>");
            //});//װ�䴦����


            //app.Use(next => async context =>
            //{
            //    await context.Response.WriteAsync("<p>==========this is Middleware 03 Start=============</p>");
            //    await context.Response.WriteAsync("<p>==========this is Middleware 03 End=============</p>");
            //});//װ�䴦����

            //�ײ㾿������ô���ģ� �벻�������ײ㾿������ô���ģ� ����ˢһ��6666�� ����Դ�룻

            //��.NET5 �ײ�Դ�룺
            //1.�ڵײ㶨����һ����ϣ�����Func<RequestDelegate, RequestDelegate> �ļ���_components��
            //2.����use����--���ǰ�ί�б��浽������ȥ��
            //3.ApplicationBuilder ��һ��Ӧ�ó���Ľ����ߣ�����Ȼ��ִ��Build����
            //4.ִ�е�build�󣬶�����һ��RequestDalagate ί�У���_components���Ϸ�ת�£�  ѭ����ת��ļ���
            //5.ѭ����һ�Σ��Ѷ���õ���Ӧ404��ί�е�������������---  �����use������м��������---  ��Ӧ404��ί�� ʧЧ�ˣ����ص��м����ֵ��֮ǰ�������Ӧ404�ı���
            //6.ѭ���ڶ��Σ�  �������Ĳ�������ѭ����һ�εõ��Ľ�����ڶ���ί�У��Ѵ������Ĳ���������һ�㣻 ����Ƕ�׵�ί�У����ػ�ȥ����ֵ��֮ǰ����ĺõ���Ӧ404��ί�У�
            //7.ѭ�������Σ���֮ǰѭ��ִ�еĽ���������������ݽ�����������һ��ί�У�  ���ػ�ȥ�ˣ�װ���˴���Ļ��ڣ�


            //���������Ժ󣬾Ͱ���װ������˳��ȥִ����~~  �����ڻ�û���±�Ӧ��ˢ��666   

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

        //ConfigureServices�����񱣴浽�����У�---������������ĳһ�������д�����߼���
        //Configure:���ô�����---10�����ڵĴ���--����ÿ�����ڣ�����Ҫ�����ķ��������������ķ���-�������У�

        //ConfigureServices:  ����ÿ��������ʲô��
        //Configure:  �ж��ٸ����ڣ�


        public RequestDelegate Show(RequestDelegate requestDelegate)
        {
            return null;
        }

    }
}
