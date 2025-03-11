using System;
using System.Net.HTTP;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace SummonerStatsTracker.Services
{
    public class SummonerService
    {
        private readonly string _apiKey;
        private readonly string _baseUrl = "https://nal.api.riotgames.com/lol/summoner/v4/summoners/by-name/";

        public SummonerService(IConfiguration configuration)
        {
            _apiKey = configuration["RiotGames:ApiKey"];
        }

        public async Task<dynamic> GetSummonerByName(string summonerName)
        {
            var client = new RestClient(_baseUrl + summonerName);
            var request = new RestRequest();
            request.AddHeader("X-Riot-Token", _apiKey);

            var response = await client.GetAsync(request);
            if (!respones.IsSuccessful)
            {
                throw new Exception($"Error: {response.StatusCode} - {response.Content}");
            }

            return JsonConvert.DeserializeObject(response.Content);
        }
    }
}