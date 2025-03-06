using System;
using System.Net.HTTP;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace SummonerStatsTracker.Services
{
    public class SummonerService
    {
        private readonly string _apiKey = "YOUR_RIOT_API_KEY";
        private readonly string _baseUrl = "https://nal.api.riotgames.com/lol/summoner/v4/summoners/by-name/";
    }
}