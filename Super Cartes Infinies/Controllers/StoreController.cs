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

        [HttpPost("{cardId}")]
        public async Task<ActionResult<String>> BuyCard(int cardId)
        {
            StoreCard card = await _context.StoreCards.Where(x => x.Id == cardId).FirstOrDefaultAsync();
            return await _storeService.BuyCard(UserId, card);
        }

        [HttpPost("{ownedCardId}")]
        public async Task<ActionResult<String>> SellCard(int ownedCardId)
        {
            return await _storeService.SellCard(UserId, ownedCardId);
        }

        [HttpGet]
        public List<StoreCard> GetBuyableCards()
        {
            List<StoreCard> storeCards = new List<StoreCard>();

            storeCards = _storeService.GetBuyableCards(UserId).ToList();

            return storeCards;
        }

        [HttpGet]
        public List<Pack> GetPacks()
        {
            List<Pack> packs = new List<Pack>();

            packs = _storeService.GetPacks(UserId).ToList();

            return packs;
        }

        [HttpPost("{packId}")]
        public async Task<ActionResult<List<Card>>> BuyPack(int packId)
        {
            Pack pack = await _context.Packs.Where(x => x.Id == packId).FirstOrDefaultAsync();
            return await _storeService.BuyPack(UserId, pack);
        }
    }
}
