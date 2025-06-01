using BookApi_Application.Handlers.Commands;
using BookApi_Application.Handlers.Queries;
using BookApi_Application.Interfaces;
using BookApi_Application.Services;
using BookApi_Domain.Interfaces;
using BookApi_Infrastructure.Configurations;
using BookApi_Infrastructure.Data.Contexts;
using BookApi_Infrastructure.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<MongodbSettings>(builder.Configuration.GetSection("MongoDb"));
builder.Services.AddScoped<MongoDbContext>();

builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddMediatR(typeof(GetBooksQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetBookQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(AddBookCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(DelBookCommandHandler).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
