using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;

namespace Super_Cartes_Infinies.Services
{
    public class StatsService
    {
        private ApplicationDbContext _context;

        public StatsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<StatsDTO>> GetGeneralStats(string uId)
        {
            Player currentPlayer = await _context.Players.Where(x => x.IdentityUserId == uId).FirstOrDefaultAsync();

            List<OwnedCard> playerOwnedCards = await _context.OwnedCards.Where(x => x.PlayerId == currentPlayer.Id).ToListAsync();

            List<Card> playerCards = new List<Card>();

            foreach(var c in playerOwnedCards)
            {
                playerCards.Add(c.Card);
            }

            StatsDTO stats = new StatsDTO
            {
                Wins = currentPlayer.Wins,
                Loses = currentPlayer.Loses,
                Cards = playerCards
            };

            return stats;
        }
    }
}
