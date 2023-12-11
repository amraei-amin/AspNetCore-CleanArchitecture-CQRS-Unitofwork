using Mapping;
using RoyalUtility.Interface;
using RoyalApplication;
using RoyalPersistence;
using Microsoft.AspNetCore.Hosting;
using System.Security.Authentication;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureHttpsDefaults(co =>
    {
        co.SslProtocols = SslProtocols.Tls12;
    });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRoyalMapping, RoyalMapping>();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);


var app = builder.Build();






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
