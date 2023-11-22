using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeckController : BaseController
    {

        #region Controller

        UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        public DeckService _deckService;

        public DeckController(UserManager<IdentityUser> userManager, ApplicationDbContext context, PlayersService playersService, DeckService deckService) : base(playersService)
        {
            this._userManager = userManager;
            _context = context;
            _deckService = deckService;
        }

        #endregion

        #region Deck

        [HttpGet]
        public List<Card> GetPlayerDeck()
        {
            List<Card> result = new List<Card>();

            result = playersService.GetPlayerFromUserId(UserId).DeckCard;

            return result;
        }

        [HttpGet]
        public List<Deck> GetDecks()
        {
            return _deckService.GetDecks(UserId);
        }

        [HttpPost]
        public async Task<ActionResult<String>> CreateDeck(DeckDTO deck)
        {
            return await _deckService.CreateDeck(deck, UserId);
        }

        [HttpDelete("{deckId}")]
        public async Task<ActionResult<String>> DeleteDeck(int deckId)
        {
            return await _deckService.DeleteDeck(deckId, UserId);
        }

        #endregion

        #region Inventory
        [HttpGet]
        public List<Card> GetInventory()
        {
            Player currentPlayer = _context.Players.Where(x => x.IdentityUserId == UserId).FirstOrDefault();

            List<Card> result = new List<Card>();

            result = _deckService.GetInventory(currentPlayer.Id).ToList();

            return result;
        }

        [HttpGet]
        public List<Card> GetFilteredCards(string FiltreChoisi)
        {
            List<Card> result = new List<Card>();

            result = _deckService.GetFilteredCards(FiltreChoisi).ToList();

            return result;
        }
        #endregion

    }
}
