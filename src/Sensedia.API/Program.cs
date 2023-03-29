using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sensedia.API.Error;
using Sensedia.API.Middleware;
using Sensedia.Core.Entities;
using Sensedia.Core.Interfaces.Generic;
using Sensedia.Core.Interfaces.Products;
using Sensedia.Infrastructure.Context;
using Sensedia.Infrastructure.Factory;
using Sensedia.Infrastructure.Repository.Products;
using Sensedia.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

var fileCustomEnv = $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json";
if (fileCustomEnv == null)
{
    fileCustomEnv = "appsettings.Development.json";
}

var configManager = new ConfigurationBuilder()
     .AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json"), false, true)
     .AddJsonFile(Path.Combine(Environment.CurrentDirectory, fileCustomEnv), true, true)
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("SensediaLocalSqlLite");

builder.Services.AddDbContext<SensediaContext>(x => x.UseSqlite(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins", p =>
    {
        p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
        .Where(e => e.Value.Errors.Count > 0)
        .SelectMany(x => x.Value.Errors)
        .Select(x => x.ErrorMessage).ToArray();

        var errorResponse = new ApiValidationErroResponse
        {
            Errors = errors
        };
        return new BadRequestObjectResult(errorResponse);
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigins");
app.UseStaticFiles();


app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<SensediaContext>();
var logger = services.GetRequiredService<ILoggerFactory>();
await context.Database.MigrateAsync();
await BuildFactoryFake.BuildFactoryAsync(context, logger);
await SensediaContextSeed.SeedAsync(context, logger);

app.Run();
