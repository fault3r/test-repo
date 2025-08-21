var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpClient("ItemHttpClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5005/api/v1/items/");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run("http://0.0.0.0:5002");
