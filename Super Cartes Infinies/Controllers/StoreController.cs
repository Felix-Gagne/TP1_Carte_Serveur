using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.ComponentModel;

namespace Super_Cartes_Infinies.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StoreService _storeService;
        UserManager<IdentityUser> _userManager;

        public StoreController(ApplicationDbContext context, StoreService storeService, UserManager<IdentityUser> userManager) 
        {
            _context = context;
            _storeService = storeService;
            _userManager = userManager;
        }

        [HttpPost("{cardId}")]
        public async Task<ActionResult<String>> BuyCard(int cardId)
        {
            StoreCard card = _context.StoreCards.Where(x => x.Id == cardId).FirstOrDefault();
            return null; //_storeService.BuyCard(, card);
        }

        [HttpPost("{cardId}")]
        public async Task<ActionResult<String>> SellCard(int cardId)
        {
            StoreCard card = _context.StoreCards.Where(x => x.Id == cardId).FirstOrDefault();
            return null; //_storeService.SellCard(,card);
        }

        [HttpGet]
        public List<StoreCard> GetBuyableCards()
        {
            List<StoreCard> storeCards = new List<StoreCard>();

            storeCards = _storeService.GetBuyableCards().ToList();

            return storeCards;
        }
    }
}
