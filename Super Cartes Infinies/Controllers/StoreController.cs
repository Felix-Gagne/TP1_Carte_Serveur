using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.ComponentModel;

namespace Super_Cartes_Infinies.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public StoreService _storeService;

        public StoreController(ApplicationDbContext context, StoreService storeService, PlayersService playersService) : base(playersService)
        {
            _context = context;
            _storeService = storeService;
        }

        [HttpPost]
        public async Task<ActionResult<String>> BuyCard(int cardId)
        {
            StoreCard card = await _context.StoreCards.Where(x => x.Id == cardId).FirstOrDefaultAsync();
            return await _storeService.BuyCard(UserId, card);
        }

        [HttpPost]
        public async Task<ActionResult<String>> SellCard(int cardId)
        {
            StoreCard card = _context.StoreCards.Where(x => x.Id == cardId).FirstOrDefault();
            return await _storeService.SellCard(UserId, cardId);
        }

        [HttpGet]
        public List<StoreCard> GetBuyableCards()
        {
            List<StoreCard> storeCards = new List<StoreCard>();

            storeCards = _storeService.GetBuyableCards(UserId).ToList();

            return storeCards;
        }
    }
}
