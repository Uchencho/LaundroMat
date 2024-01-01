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

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
