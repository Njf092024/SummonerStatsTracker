using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.Extensions.Configuration;

namespace SummonerStatsTracker.Services
{
    public class SummonerService
    {
        private readonly string? _apiKey;
        private readonly string _baseUrl = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/";

        public SummonerService(IConfiguration configuration)
        {
            _apiKey = configuration["RiotGames:ApiKey"];
        }

        public async Task<dynamic> GetSummonerByName(string summonerName)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new Exception("API Key is not configured.");
            }
        
            var client = new RestClient(_baseUrl + summonerName);
            var request = new RestRequest();
            request.AddHeader("X-Riot-Token", _apiKey);

            var response = await client.GetAsync(request);

            Console.WriteLine("Response Status Code: " + response.StatusCode);
            Console.WriteLine("Response Content: " + response.Content);
            
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error: {response.StatusCode} - {response.Content}");
            }

            if (string.IsNullOrEmpty(response.Content))
            {
                throw new Exception("No data returned from the API");
            }

            var result = JsonConvert.DeserializeObject(response.Content);
            if (result == null)
            {
                throw new Exception("Failed to deserialize the response");
            }

            return result;
        }
    }
}
