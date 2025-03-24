using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SummonerStatsTracker.Services;

var builder = Host.CreateDefaultBuilder(args)
.ConfigurServices((context, services)=>
{
    services.AddSingleton<SummonerService>();
    services.AddSingleton<IConfiguration>(context.configuration);
})
.Build();

await builder.RunAsync();