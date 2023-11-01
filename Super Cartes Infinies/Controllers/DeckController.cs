using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public CardService _cardService;

        public DeckController(UserManager<IdentityUser> userManager, ApplicationDbContext context, PlayersService playersService, CardService cardsService) : base(playersService)
        {
            this._userManager = userManager;
            _context = context;
            _cardService = cardsService;
        }

        [HttpGet]
        public List<Card> GetPlayerDeck()
        {
            List<Card> result = new List<Card>();

            result = playersService.GetPlayerFromUserId(UserId).DeckCard;

            return result;
        }

        [HttpGet]
        public List<Card> GetInventory()
        {
            Player currentPlayer = _context.Players.Where(x => x.IdentityUserId == UserId).FirstOrDefault();

            List<Card> result = new List<Card>();

            result = _cardService.GetInventory(currentPlayer.Id).ToList();

            return result;
        }

        [HttpGet]
        public List<Card> GetFilteredCards(string FiltreChoisi)
        {
            List<Card> result = new List<Card>();

            result = _cardService.GetFilteredCards(FiltreChoisi).ToList();

            return result;
        }
    }
}
