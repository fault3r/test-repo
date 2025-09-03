
using csgrpc.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5218, o => o.Protocols = HttpProtocols.Http2);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGrpcService<HelloworldGrpcService>();
app.MapGet("/", () => "Communication with gRPC client.");

app.MapGrpcReflectionService();

app.Run();