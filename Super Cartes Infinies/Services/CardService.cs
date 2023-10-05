using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
    public class CardService
    {
        private ApplicationDbContext _context;
        public CardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Card> GetAllCards()
        {
            return _context.Cards.OrderBy(c => c.Id);
        }

        public IEnumerable<Card> GetFilteredCards(string filtre)
        {

            if (filtre == "Attack")
            {
                return _context.Cards.OrderBy(c => c.Attack);
            }
            if (filtre == "Defense")
            {
                return _context.Cards.OrderBy(c => c.Defense);
            }
            if (filtre == "Name")
            {
                return _context.Cards.OrderBy(c => c.Name);
            }
            return _context.Cards.OrderBy(c => c.Id);
        }
    }
}
