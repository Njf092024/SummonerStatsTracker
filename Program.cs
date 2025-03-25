using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SummonerStatsTracker.Services;
using Microsoft.OpenApi.Models;

var builder = Host.CreateDefaultBuilder(args)
.ConfigureServices((context, services)=>
{
    services.AddSingleton<SummonerService>();
    services.AddSingleton<IConfiguration>(context.Configuration);
})
.Build();

await builder.RunAsync();