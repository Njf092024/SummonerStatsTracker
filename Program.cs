using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SummonerStatsTracker.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(configuration);

builder.Services.AddSingleton<SummonerService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = " Summoner API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Summoner API v1");
        c.RoutePrefix = string.Empty;
    });
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();