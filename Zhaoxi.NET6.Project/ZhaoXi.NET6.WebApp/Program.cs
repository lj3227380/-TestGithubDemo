using Microsoft.AspNetCore.Builder;

//WebӦ�ó���Ľ�����~~
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();



//Func<HttpContext, Func<Task>, Task> middleware = async (context, fun) =>
// { 
//     await context.Response.WriteAsync("=========Middleware 01 strat =============");
//     await fun.Invoke();
//     await context.Response.WriteAsync("===========Middleware 01 end==========="); 
// };
//app.Use(async (context, fun) =>
//{
//    await context.Response.WriteAsync("=========Middleware 01 strat =============");
//    await fun.Invoke();
//    await context.Response.WriteAsync("===========Middleware 01 end===========");
//});

//app.Use(async (context, fun) =>
//{
//    await context.Response.WriteAsync("=========Middleware 02 strat =============");
//    await fun.Invoke();
//    await context.Response.WriteAsync("===========Middleware 02 end===========");
//});

//app.Use(async (context, fun) =>
//{
//    await context.Response.WriteAsync("=========Middleware 03 strat =============");
//    await fun.Invoke();
//    await context.Response.WriteAsync("===========Middleware 03 end===========");
//});

//.NET6����ʽ��  �����.NET5 ��༸��չʾ~~���س�ʵ�ֻ���һ���ģ�����ֻ�Ƕ��η�װ��~/
//.NET ����ʽ��  ���Դ��

//.NET6 �ܵ�װ��---����.NET5

{
    //IApplicationBuilder appbuilder = (IApplicationBuilder)app;

    //appbuilder.Use(next => async context =>
    //{
    //    await context.Response.WriteAsync("<p>==========this is Middleware 01 Start=============</p>");
    //    await next.Invoke(context);
    //    await context.Response.WriteAsync("<p>==========this is Middleware 01 End=============</p>");
    //});

    //appbuilder.Use(next => async context =>
    //{
    //    await context.Response.WriteAsync("<p>==========this is Middleware 02 Start=============</p>");
    //    await next.Invoke(context);
    //    await context.Response.WriteAsync("<p>==========this is Middleware 02 End=============</p>");
    //});//װ�䴦����

    //appbuilder.Use(next => async context =>
    //{
    //    await context.Response.WriteAsync("<p>==========this is Middleware 2.5 Start=============</p>");

    //    await context.Response.WriteAsync("<p>==========this is Middleware 2.5 End=============</p>");
    //});//װ�䴦����
}

{

}


//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
