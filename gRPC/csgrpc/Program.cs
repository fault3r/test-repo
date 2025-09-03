
using csgrpc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGrpcService<HelloworldGrpcService>();
app.MapGet("/", () => "Communication with gRPC client.");

app.Run();