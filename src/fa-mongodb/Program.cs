using fa_mongodb.Data;
using fa_mongodb.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<MongoDbContext>(p =>
    new MongoDbContext("mongodb://localhost:27017", "LibraryCollection"));

builder.Services.AddScoped<BookRepository>();


builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
