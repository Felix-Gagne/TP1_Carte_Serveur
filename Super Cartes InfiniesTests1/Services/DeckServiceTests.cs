using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Services.Tests
{
    [TestClass()]
    public class DeckServiceTests
    {

        DbContextOptions<ApplicationDbContext> options;
        public DeckServiceTests()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "DeskService")
            .Options;
        }

        [TestInitialize]
        public void Init()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            db.SaveChanges();
        }
        [TestCleanup]
        public void Dispose()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            db.Cards.RemoveRange(db.Cards);
            db.Decks.RemoveRange(db.Decks);
            db.Players.RemoveRange(db.Players);
            db.SaveChanges();
        }

        [TestMethod()]
        public async Task GetDecksTestAsync()
        {

            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);

            Player player = new Player
            {
                Id = 1,
                IdentityUserId = "Test",
                Name = "Test",
                DeckCard = new List<Deck>(),
                Money = 1,
            };

            db.Players.Add(player);

            Deck deck1 = new Deck
            {
                Id = 1,
                Name = "Test",
                PlayerId = player.Id,
            };

            player.DeckCard.Add(deck1);
            db.Decks.Add(deck1);
            db.SaveChanges();

            var deckresult = cardService.GetDecks(player.IdentityUserId);

            Assert.IsNotNull(deckresult);
            Assert.AreEqual(deck1.Id, deckresult[0].Id);
            Assert.AreEqual(deck1.Name, deckresult[0].Name);
            Assert.AreEqual(deck1.PlayerId, deckresult[0].PlayerId);
        }

        [TestMethod()]
        public void GetSelectedDeckTest()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);

            Player player = new Player
            {
                Id = 1,
                IdentityUserId = "Test",
                Name = "Test",
                DeckCard = new List<Deck>(),
                Money = 1,
                SelectedDeckId = 2,
            };

            db.Players.Add(player);

            Deck deck1 = new Deck
            {
                Id = 1,
                Name = "Test",
                PlayerId = player.Id,
            };

            Deck deck2 = new Deck
            {
                Id = 2,
                Name = "Test2",
                PlayerId = player.Id,
            };

            player.DeckCard.Add(deck1);
            player.DeckCard.Add(deck2);
            db.Decks.Add(deck1);
            db.Decks.Add(deck2);
            db.SaveChanges();

            var deckresult = cardService.GetSelectedDeck(player.IdentityUserId);

            Assert.IsNotNull(deckresult);
            Assert.AreEqual(deck2.Id, deckresult.Result.Value.Id);
            Assert.AreEqual(deck2.Name, deckresult.Result.Value.Name);
            Assert.AreEqual(deck2.PlayerId, deckresult.Result.Value.PlayerId);
        }

        [TestMethod()]
        public void GetSelectedDeckTestNull()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);

            Player player = new Player
            {
                Id = 1,
                IdentityUserId = "Test",
                Name = "Test",
                DeckCard = new List<Deck>(),
                Money = 1,
                SelectedDeckId = 2,
            };

            db.Players.Add(player);

            Deck deck1 = new Deck
            {
                Id = 1,
                Name = "Test",
                PlayerId = player.Id,
            };

            Deck deck2 = new Deck
            {
                Id = 2,
                Name = "Test2",
                PlayerId = player.Id,
            };

            player.DeckCard.Add(deck1);
            player.DeckCard.Add(deck2);
            db.Decks.Add(deck1);
            db.Decks.Add(deck2);
            db.SaveChanges();

            try
            {
                var deckresult = cardService.GetSelectedDeck(player.IdentityUserId);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Joueur null", ex.Message);
            }

        }

        [TestMethod()]
        public void CreateDeckTestFonctionne()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);

            Player player = new Player
            {
                Id = 1,
                IdentityUserId = "Test",
                Name = "Test",
                DeckCard = new List<Deck>(),
                Money = 1,
                SelectedDeckId = 2,
            };

            db.Players.Add(player);

            DeckDTO deck = new DeckDTO
            {
                Name = "Test",
                CardIds = new List<int>(),
            };

            db.SaveChanges();

            var deckresult = cardService.CreateDeck(deck, player.IdentityUserId);

            Assert.AreEqual("", deckresult.Result.Value);
        }

        [TestMethod()]
        public void CreateDeckTestNull()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);

            Player player = new Player
            {
                Id = 1,
                IdentityUserId = "Test",
                Name = "Test",
                DeckCard = new List<Deck>(),
                Money = 1,
                SelectedDeckId = 2,
            };

            db.Players.Add(player);

            db.SaveChanges();

            try
            {
                var deckresult = cardService.CreateDeck(null, player.IdentityUserId);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Pas de deck reçu.", ex.Message);
            }
        }

        [TestMethod()]
        public void DeleteDeckTest()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);

            Player player = new Player
            {
                Id = 1,
                IdentityUserId = "Test",
                Name = "Test",
                DeckCard = new List<Deck>(),
                Money = 1,
                SelectedDeckId = 2,
            };

            db.Players.Add(player);

            Deck deck1 = new Deck
            {
                Id = 1,
                Name = "Test",
                PlayerId = player.Id,
            };

            Deck deck2 = new Deck
            {
                Id = 2,
                Name = "Test2",
                PlayerId = player.Id,
            };

            player.DeckCard.Add(deck1);
            player.DeckCard.Add(deck2);
            db.Decks.Add(deck1);
            db.Decks.Add(deck2);
            db.SaveChanges();

            var deckresult = cardService.DeleteDeck(1, player.IdentityUserId);

            Assert.AreEqual("", deckresult.Result.Value);
        }

        [TestMethod()]
        public void EditDeckTest()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);

            Player player = new Player
            {
                Id = 1,
                IdentityUserId = "Test",
                Name = "Test",
                DeckCard = new List<Deck>(),
                Money = 1,
                SelectedDeckId = 2,
            };

            db.Players.Add(player);

            Deck deck1 = new Deck
            {
                Id = 1,
                Name = "Test",
                PlayerId = player.Id,
            };

            Deck deck2 = new Deck
            {
                Id = 2,
                Name = "Test2",
                PlayerId = player.Id,
            };

            EditDeckDTO deck = new EditDeckDTO
            {
                Name = "Test",
                Cards = new List<OwnedCard>(),
            };

            player.DeckCard.Add(deck1);
            player.DeckCard.Add(deck2);
            db.Decks.Add(deck1);
            db.Decks.Add(deck2);
            db.SaveChanges();

            var deckresult = cardService.EditDeck(1, player.IdentityUserId, deck);

            Assert.AreEqual("", deckresult.Result.Value);
        }

        [TestMethod()]
        public void EditDeckTestNull()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);

            Player player = new Player
            {
                Id = 1,
                IdentityUserId = "Test",
                Name = "Test",
                DeckCard = new List<Deck>(),
                Money = 1,
                SelectedDeckId = 2,
            };

            db.Players.Add(player);

            Deck deck1 = new Deck
            {
                Id = 1,
                Name = "Test",
                PlayerId = player.Id,
            };

            Deck deck2 = new Deck
            {
                Id = 2,
                Name = "Test2",
                PlayerId = player.Id,
            };

            EditDeckDTO deck = new EditDeckDTO
            {
                Name = "Test",
                Cards = new List<OwnedCard>(),
            };

            player.DeckCard.Add(deck1);
            player.DeckCard.Add(deck2);
            db.Decks.Add(deck1);
            db.Decks.Add(deck2);
            db.SaveChanges();

            var deckresult = cardService.EditDeck(1, player.IdentityUserId, null);

            Assert.AreEqual("Le deck est null.", deckresult.Result.Value);
        }

        [TestMethod()]
        public void EditSelectedDeckTest()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);

            Player player = new Player
            {
                Id = 1,
                IdentityUserId = "Test",
                Name = "Test",
                DeckCard = new List<Deck>(),
                Money = 1,
                SelectedDeckId = 2,
            };

            db.Players.Add(player);

            Deck deck1 = new Deck
            {
                Id = 1,
                Name = "Test",
                PlayerId = player.Id,
            };

            Deck deck2 = new Deck
            {
                Id = 2,
                Name = "Test2",
                PlayerId = player.Id,
            };

            EditDeckDTO deck = new EditDeckDTO
            {
                Name = "Test",
                Cards = new List<OwnedCard>(),
            };

            player.DeckCard.Add(deck1);
            player.DeckCard.Add(deck2);
            db.Decks.Add(deck1);
            db.Decks.Add(deck2);
            db.SaveChanges();

            var deckresult = cardService.EditSelectedDeck(1, player.IdentityUserId);

            Assert.AreEqual("", deckresult.Result.Value);
        }

        [TestMethod()]
        public void EditSelectedDeckTestNull()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);

            Player player = new Player
            {
                Id = 1,
                IdentityUserId = "Test",
                Name = "Test",
                DeckCard = new List<Deck>(),
                Money = 1,
                SelectedDeckId = 2,
            };

            db.Players.Add(player);

            Deck deck1 = new Deck
            {
                Id = 1,
                Name = "Test",
                PlayerId = player.Id,
            };

            Deck deck2 = new Deck
            {
                Id = 2,
                Name = "Test2",
                PlayerId = player.Id,
            };

            EditDeckDTO deck = new EditDeckDTO
            {
                Name = "Test",
                Cards = new List<OwnedCard>(),
            };

            player.DeckCard.Add(deck1);
            player.DeckCard.Add(deck2);
            db.Decks.Add(deck1);
            db.Decks.Add(deck2);
            db.SaveChanges();

            var deckresult = cardService.EditSelectedDeck(1, "Test2");

            Assert.AreEqual("Aucun joueur cibler.", deckresult.Result.Value);
        }
    }
}