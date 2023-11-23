using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<StoreCard> GetBuyableCards(String userId)
        {
            return _context.StoreCards.OrderBy(x => x.Id);
        }

        public async Task<ActionResult<String>> BuyCard(string userId, StoreCard storeCard)
        {
            Player currentPlayer = await _context.Players.Where(x => x.IdentityUserId == userId).FirstOrDefaultAsync();

            //If the player doesn't have enough money
            if (currentPlayer.Money < storeCard.BuyAmount)
            {
                throw new Exception("Not enough money to buy this card brokie. Go get your money up.");
            }
            //Add the card to the player's Owned Card
            else
            {
                //Ajouter la logique pour ajouter une carte dans l'inventaire du joueur.
                OwnedCard carteAcheter = new OwnedCard
                {
                    PlayerId = currentPlayer.Id,
                    CardId = storeCard.CardId
                };
                currentPlayer.OwnedCard.Add(carteAcheter);
                currentPlayer.Money -= storeCard.BuyAmount;
                await _context.SaveChangesAsync();
            }

            return "Card successfully bought";
        }

        public async Task<ActionResult<String>> SellCard(string userId, int ownedCardId) 
        {
            Player currentPlayer = await _context.Players.Where(x => x.IdentityUserId == userId).FirstOrDefaultAsync();
            OwnedCard ownedCard = await _context.OwnedCards.Where(x => x.Id == ownedCardId).Where(y => y.PlayerId == currentPlayer.Id).FirstOrDefaultAsync();
            StoreCard sellPriceCard = await _context.StoreCards.Where(x => x.CardId == ownedCard.CardId).FirstOrDefaultAsync();

            if (currentPlayer.Id != ownedCard.PlayerId)
            {
                throw new Exception("Heille t'essaye de vendre la carte de ton homeboy la. Vent tes propres cartes.");
            }

            _context.OwnedCards.Remove(ownedCard);
            currentPlayer.OwnedCard.Remove(ownedCard);
            currentPlayer.Money += sellPriceCard.SellAmount;
            await _context.SaveChangesAsync();

            return "Card succefully sold.";
        }
    }
}
