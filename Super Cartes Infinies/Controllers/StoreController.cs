using Microsoft.AspNetCore.Http;
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

        public StoreController(ApplicationDbContext context, StoreService storeService) 
        {
            _context = context;
            _storeService = storeService;
        }

        [HttpPost]
        public async Task<ActionResult> BuyCard()
        {
            return null;
        }

        [HttpPost]
        public async Task<ActionResult> SellCard()
        {
            return null;
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
