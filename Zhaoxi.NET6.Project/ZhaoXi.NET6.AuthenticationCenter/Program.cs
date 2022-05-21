using ZhaoXi.NET6.AuthenticationCenter.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<JWTTokenOptions>(builder.Configuration.GetSection("JWTTokenOptions"));

//builder.Services.AddTransient<ICustomJWTService, CustomHSJWTService>();
builder.Services.AddTransient<ICustomJWTService, CustomRSSJWTervice>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
