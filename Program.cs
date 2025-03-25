using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SummonerStatsTracker.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwwaggerDoc("v1", new OpenApiInfo { Title = " Summoner API", Version = "v1" });
});