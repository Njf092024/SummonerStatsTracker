using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SummonerStatsTracker.Services;

var builder = Host.CreateDefaultBuilder(args)
.configurationServices((context, services)=>
{
    services.AddSingleton<SummonerService>();
})
.Build();

await builder.RunAsync();