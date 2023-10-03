using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MatchController : BaseController
    {
        private MatchesService _matchesService;

        public MatchController(MatchesService matchesService, PlayersService playersService): base(playersService)
        {
            _matchesService = matchesService;
        }

        [HttpPost]
        public async Task<ActionResult<JoiningMatchData?>> JoinMatch()
        {
            return await _matchesService.JoinMatch(UserId);
        }

        [HttpPost("{matchId}")]
        public async Task<ActionResult<string>> StartMatch(int matchId)
        {
            return await _matchesService.StartMatch(UserId, matchId);
        }

        [HttpPost("{matchId}/{playableCardId}")]
        public async Task<ActionResult<string>> PlayCard(int matchId, int playableCardId)
        {
            return await _matchesService.PlayCard(UserId, matchId, playableCardId);
        }

        [HttpGet("{matchId}/{turnIndex}")]
        public async Task<ActionResult<List<string>?>> UpdateMatch(int matchId, int turnIndex)
        {
            return await _matchesService.UpdateMatch(UserId, matchId, turnIndex);
        }

        [HttpGet("{matchId}")]
        public async Task<ActionResult<string>> EndMatch(int matchId)
        {
            return await _matchesService.EndMatch(matchId);
        }
    }
}
