using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeckController : BaseController
    {
        UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public DeckController(UserManager<IdentityUser> userManager, ApplicationDbContext context, PlayersService playersService) : base(playersService)
        {
            this._userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public List<Card> GetPlayerDeck()
        {
            List<Card> result = new List<Card>();

            result = playersService.GetPlayerFromUserId(UserId).DeckCard;

            return result;
        }
    }
}
