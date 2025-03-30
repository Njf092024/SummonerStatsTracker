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
        private readonly RestClient _client;

        private const string _baseUrl = "https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/";

        public SummonerService(IConfiguration configuration)
        {
            _apiKey = configuration["RiotGames:ApiKey"] ?? throw new Exception("API Key is not configured");
            _client = new RestClient();

            if (string.IsNullOrEmpty(_apiKey))
            {
                Console.WriteLine("API Key is missing or not loaded!");
                throw new Exception("API Key is not configured.");
            }
            else
            {
                Console.WriteLine($"Using API Key: {_apiKey}");
            }
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

            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            throw new HttpRequestException("API Key is invalid or expired. Regenerate a new one at Riot Developer Portal.");

            if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            throw new HttpRequestException("Rate limit exceeded! try again and stop spamming pls.");

            if (response.IsSuccessful)
            throw new HttpRequestException($"API error: {response.StatusCode} - {response.Content}");

            if (string.IsNullOrEmpty(response.Content))
            throw new Exception($"No data returned from the API.");

            var result = JsonConvert.DeserializeObject(response.Content);
            if (result == null)
            throw new Exception("Failed to parse API response.");

            return result;
        }
    }
}
