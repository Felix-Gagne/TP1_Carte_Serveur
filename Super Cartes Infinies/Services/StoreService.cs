using Microsoft.AspNetCore.Mvc;
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

        public Task<ActionResult> BuyCard(string userId, StoreCard storeCard)
        {
            Player currentPlayer = _context.Players.Where(x => x.IdentityUserId == userId).FirstOrDefault();

            //If the player doesn't have enough money
            if (currentPlayer.Money < storeCard.BuyAmount)
            {
                throw new Exception("Not enough money to buy this card brokie");
            }

            //If the player already pocesses the card
            else if(currentPlayer.DeckCard.Contains(storeCard.Card))
            {
                throw new Exception("You already got this card dummy");
            }

            //Add the card to the player's deck
            else
            {
                //Ajouter la logique pour ajouter une carte dans l'inventaire du joueur.
                currentPlayer.DeckCard.Add(storeCard.Card);
                currentPlayer.Money -= storeCard.BuyAmount;
                _context.SaveChangesAsync();
            }

            return null;
        }

        public Task<ActionResult> SellCard(string userId, Card card) 
        {
            Player currentPlayer = _context.Players.Where(x => x.IdentityUserId == userId).FirstOrDefault();

            StoreCard storeCard = _context.StoreCards.Where(x => x.CardId == card.Id).FirstOrDefault();
            
            if(card == null)
            {
                return null;
            }

            currentPlayer.Money += storeCard.SellAmount;
            currentPlayer.DeckCard.Remove(card);
            _context.SaveChangesAsync();

            return null;
        }
    }
}
