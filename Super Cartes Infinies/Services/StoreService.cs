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

            return "";
        }

        public async Task<ActionResult<String>> SellCard(string userId, int ownedCardId) 
        {
            Player currentPlayer = await _context.Players.Where(x => x.IdentityUserId == userId).FirstOrDefaultAsync();
            OwnedCard ownedCard = await _context.OwnedCards.Where(x => x.Id == ownedCardId).Where(y => y.PlayerId == currentPlayer.Id).FirstOrDefaultAsync();
            //Test : vendre la ownerCard
            //StoreCard sellPriceCard = await _context.StoreCards.Where(x => x.CardId == ownedCard.CardId).FirstOrDefaultAsync();

            if (currentPlayer.Id != ownedCard.PlayerId)
            {
                throw new Exception("Heille t'essaye de vendre la carte de ton homeboy la. Vent tes propres cartes.");
            }

            currentPlayer.Money += ownedCard.Card.prixVente;
            currentPlayer.OwnedCard.Remove(ownedCard);
            _context.OwnedCards.Remove(ownedCard);
            await _context.SaveChangesAsync();

            return "";
        }

        public IEnumerable<Pack> GetPacks(String userId)
        {
            return _context.Packs.OrderBy(x => x.Id);
        }

        public async Task<ActionResult<List<Card>>> BuyPack(string userId, Pack pack)
        {
            Player currentPlayer = await _context.Players.Where(x => x.IdentityUserId == userId).FirstOrDefaultAsync();
            List<Card> cards = new List<Card>();
            Random random = new Random();

            if (currentPlayer.Money < pack.Price)
            {
                throw new Exception("Not enough money to buy this card brokie. Go get your money up.");
            }
            else
            {

                Rarity? GetRandomRarity(List<Probability> probabilities)
                {
                    
                    foreach (var p in probabilities)
                    {
                        double x = random.NextDouble();
                        if (p.value > x)
                        {
                            return p.rarity;
                        }
                    }

                    return null;
                }

                List<Rarity> GenerateRarities(int nbCards, Rarity defaultRarity, List<Probability> probabilities)
                {
                    List<Rarity> rarities = new List<Rarity>();

                    foreach(var p in probabilities)
                    {
                        if(p.baseQty == 1)
                        {
                            rarities.Add(p.rarity);
                        }
                    }

                    while(rarities.Count < nbCards)
                    {
                        Rarity? rarity = GetRandomRarity(probabilities);

                        if(rarity == null)
                        {
                            rarities.Add(defaultRarity);
                        }
                        else
                        {
                            rarities.Add((Rarity)rarity);
                        }
                    };

                    return rarities;
                }

                //Trouver les rareté obtenus
                var result = GenerateRarities(pack.NbCards, pack.BaseRarity, pack.Probabilities);

                //Choisir les carets avec les raretés

                foreach (var r in result)
                {
                    List<Card> cardsOfRarity = _context.Cards.Where(c => c.Rarity == r).ToList();

                    int index = random.Next(cardsOfRarity.Count);
                    cards.Add(cardsOfRarity[index]);
                }


                foreach(var c in cards)
                {
                    OwnedCard newOwnedCard = new OwnedCard()
                    {
                        PlayerId = currentPlayer.Id,
                        CardId = c.Id,
                    };
                    currentPlayer.OwnedCard.Add(newOwnedCard);
                };

                currentPlayer.Money -= pack.Price;
                await _context.SaveChangesAsync();
            }

            return cards;
        }
    }
}
