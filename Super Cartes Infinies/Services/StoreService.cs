using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
    public class StoreService
    {
        private ApplicationDbContext _context;

        public StoreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<StoreCard> GetBuyableCards()
        {
            return _context.StoreCards.OrderBy(x => x.Id);
        }
    }
}
