using WebApp.Utility.Filters;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Logging.AddLog4Net("CfgFile/log4net.Config");

var service = builder.Services;


// Add services to the container.
builder.Services.AddControllersWithViews(mvcOption =>
{
    //3.È«¾Ö×¢²á
    //mvcOption.Filters.Add<CustomCacheResourceFilterAttribute>();
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
