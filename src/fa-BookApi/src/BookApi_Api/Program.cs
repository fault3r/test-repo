using BookApi_Application.Handlers.Commands;
using BookApi_Application.Handlers.Queries;
using BookApi_Application.Interfaces;
using BookApi_Application.Services;
using BookApi_Domain.Interfaces;
using BookApi_Infrastructure.Configurations;
using BookApi_Infrastructure.Data.Contexts;
using BookApi_Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(2, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new HeaderApiVersionReader("api-version"),
        new QueryStringApiVersionReader("v"),
        new UrlSegmentApiVersionReader());
});

builder.Services.Configure<MongodbSettings>(builder.Configuration.GetSection("MongoDb"));
builder.Services.AddScoped<MongoDbContext>();

builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddMediatR(typeof(GetBooksQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetBookQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(AddBookCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(DelBookCommandHandler).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API V1", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "API V2", Version = "v2" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "API V2");
    });
}

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
