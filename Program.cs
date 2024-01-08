using LaundroMat.DBContexts;
using LaundroMat.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<LaundroMatContext>(
    dbContextOptions => dbContextOptions.UseSqlite(
        builder.Configuration["connectionStrings:LaundroMatConnectionString"]));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandler(appBuilder =>
{
    appBuilder.Run(async ctx =>
    {
        ctx.Response.StatusCode = 500;
        await ctx.Response.WriteAsync("An unexpected error occured, please try again later");
    });
});

app.MapControllers();

app.Run();
