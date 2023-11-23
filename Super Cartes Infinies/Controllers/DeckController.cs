using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Models.Message;
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

        [HttpPut("{deckId}")]
        public async Task<ActionResult<Message>> EditDeck(int deckId, EditDeckDTO deckDTO)
        {
            return await _deckService.EditDeck(deckId, UserId, deckDTO);
        }

        #endregion

        #region Inventory
        [HttpGet]
        public async Task<List<OwnedCard>> GetInventory()
        {
            try
            {
                Player currentPlayer = _context.Players.Where(x => x.IdentityUserId == UserId).FirstOrDefault();

                List<OwnedCard> result = new List<OwnedCard>();

                result = await _deckService.GetInventory(currentPlayer.Id);

                return result;
            }
            catch (AucunJoueruTrouver e)
            {
                throw e; 
            }
            catch (ListeDeCarteVide a)
            {
                throw a;
            }
            //Test : utiliser des owner card a la place de cards
            /*
            Player currentPlayer = _context.Players.Where(x => x.IdentityUserId == UserId).FirstOrDefault();

            List<OwnedCard> result = new List<OwnedCard>();

            result = _deckService.GetInventory(currentPlayer.Id).ToList();

            return result;*/
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
