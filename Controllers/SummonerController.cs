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

        public SummonerController()
        {
            _summonerService = new SummonerService();
        }
    }
}