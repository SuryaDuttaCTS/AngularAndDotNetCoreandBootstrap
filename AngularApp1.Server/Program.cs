using AngularApp1.Server.Context;
using AngularApp1.Server.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogDbContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CodePulseConnectionString")));
builder.Services.AddScoped<ISQLCategoriesRepository, SQLCategoriesRepository>();
builder.Services.AddScoped<ISQLBlogPostRepository, SQLBlogPostRepository>();
builder.Services.AddScoped<ISQLImagerepository, SQLImageRepository>();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(options => {
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});



app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
