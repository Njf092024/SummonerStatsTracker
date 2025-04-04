using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SummonerStatsTracker.Services;

namespace SummonerStatsTracker.Controllers
{
    [ApiController]
    [Route("api/summoner")]
    public class SummonerController : ControllerBase
    {
        private readonly SummonerService _summonerService;

        public SummonerController(IConfiguration configuration)
        {
            _summonerService = new SummonerService(configuration);
        }

        [HttpGet("{summonerName}")]
        public async Task<IActionResult> GetSummoner(string summonerName)
        {
            try
            {
                var summoner = await _summonerService.GetSummonerByName(summonerName);
                return Ok(summoner);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = "error occurred while retrieving summoner", error = ex.Message });
            }
        }
    }
}