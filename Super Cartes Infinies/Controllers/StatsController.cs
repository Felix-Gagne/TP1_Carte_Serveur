using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public StatsService _statsService;

        public StatsController(ApplicationDbContext context, StatsService statsService, PlayersService playersService) : base(playersService)
        {
            _context = context;
            _statsService = statsService;
        }

        [HttpGet]
        public Task<ActionResult<StatsDTO>> GetGeneralStats()
        {
            StatsDTO statsDTO = new StatsDTO();

            statsDTO = _statsService.GetGeneralStats(UserId);

            return statsDTO;
        }
    }
}
