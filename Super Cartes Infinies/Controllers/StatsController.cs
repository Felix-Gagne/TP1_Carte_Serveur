using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatsController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public StatsService _statsService;
        UserManager<IdentityUser> _userManager;

        public StatsController(ApplicationDbContext context, StatsService statsService, PlayersService playersService, UserManager<IdentityUser> userManager) : base(playersService)
        {
            this._userManager = userManager;
            _context = context;
            _statsService = statsService;
        }

        [HttpGet]
        public async Task<ActionResult<StatsDTO>> GetGeneralStats()
        {
            return await _statsService.GetGeneralStats(UserId);
        }

        [HttpGet("{deckId}")]
        public async Task<ActionResult<StatsDTO>> GetDeckStats(int deckId)
        {
            return await _statsService.GetDeckStats(UserId, deckId);
        }
    }
}
