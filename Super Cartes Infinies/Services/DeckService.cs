using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;

namespace Super_Cartes_Infinies.Services
{
    public class DeckService
    {

        #region Service

        private ApplicationDbContext _context;
        public DeckService(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Deck

        public List<Deck> GetDecks(string userId)
        {
            Player player = _context.Players.Where(x => x.IdentityUserId == userId).FirstOrDefault();

            List<Deck> decks = _context.Decks.Where(x => x.PlayerId == player.Id).OrderBy(x => x.Id).ToList();

            return decks;
        }

        public async Task<ActionResult<String>> CreateDeck(DeckDTO deckDTO, string userId) 
        {
            if(deckDTO == null)
            {
                throw new Exception("Pas de deck reçu.");
            }
            
            Player currentPlayer = await _context.Players.Where(x => x.IdentityUserId == userId).FirstOrDefaultAsync();

            List<OwnedCard> owned = new List<OwnedCard>();

            foreach(int id in deckDTO.CardIds)
            {
                owned.Add(_context.OwnedCards.Where(x => x.Id == id).FirstOrDefault());
            }

            Deck deck = new Deck
            {
                PlayerId = currentPlayer.Id,
                Name = deckDTO.Name,
                Cards = owned,
            };

            _context.Decks.Add(deck);
            await _context.SaveChangesAsync();

            return "";
        }

        public async Task<ActionResult<String>> DeleteDeck(int deckId, string userId)
        {
            Player currentPlayer = await _context.Players.Where(x => x.IdentityUserId == userId).FirstOrDefaultAsync();
            Deck deleteDeck = await _context.Decks.Where(x => x.Id == deckId).Where(y => y.PlayerId == currentPlayer.Id).FirstOrDefaultAsync();

            if(deleteDeck.PlayerId != currentPlayer.Id)
            {
                return "This is not your deck.";
            }

            _context.Decks.Remove(deleteDeck);
            _context.SaveChangesAsync();

            return "";
        }


        public async Task<ActionResult<String>> EditDeck(int deckId, string userId, DeckDTO deckDto)
        {
            Player currentPlayer = await _context.Players.Where(x => x.IdentityUserId == userId).FirstOrDefaultAsync();
            Deck editDeck = await _context.Decks.Where(x => x.Id == deckId).Where(y => y.PlayerId == currentPlayer.Id).FirstOrDefaultAsync();

            if(deckDto == null)
            {
                return "Le deck est null";
            }

            _context.Decks.Update(editDeck);
            await _context.SaveChangesAsync();

            return "";
        }

        #endregion

        #region Inventory

        public IEnumerable<Card> GetInventory(int playerId)
        {
            List<OwnedCard> owned = _context.OwnedCards.Where(x => x.PlayerId == playerId).ToList();
            List<Card> returnedCards = new List<Card>();

            foreach (var item in owned)
            {
                returnedCards.Add(_context.Cards.Where(x => x.Id == item.CardId).FirstOrDefault());
            }


            return returnedCards;
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

        #endregion

    }
}
