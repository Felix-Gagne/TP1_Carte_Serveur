using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Super_Cartes_Infinies.Services.Tests
{
    [TestClass()]
    public class CardServiceTests
    {

        DbContextOptions<ApplicationDbContext> options;
        public CardServiceTests()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "CardService")
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
            db.Players.RemoveRange(db.Players);
            db.SaveChanges();
        }

        /*[TestMethod()]
        public void GetAllCardsTest()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);

            Player player = new Player {
                Id = 100,
                Name = "Test",
                Money = 250,
                IdentityUserId = "HA1B2-HD12N",
            };

            List<Card> cards = new List<Card>();

            Card carte1 = new Card
            {
                Name = "Potat",
                Attack = 2,
                Defense = 3,
                Id = 1,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            Card carte2 = new Card
            {
                Name = "Test",
                Attack = 12,
                Defense = 30,
                Id = 2,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            Card carte3 = new Card
            {
                Name = "Banana",
                Attack = 4,
                Defense = 15,
                Id = 3,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            db.Cards.Add(carte1);
            db.Cards.Add(carte2);
            db.Cards.Add(carte3);
            db.Players.Add(player);
            db.SaveChanges();

            cards.Add(carte1);
            cards.Add(carte2);
            cards.Add(carte3);

            var result = cardService.GetInventory(player.Id).ToList();


            Assert.AreEqual(cards.IndexOf(carte1), result.IndexOf(carte1));
            Assert.AreEqual(cards.IndexOf(carte2), result.IndexOf(carte2));
            Assert.AreEqual(cards.IndexOf(carte3), result.IndexOf(carte3));
        }*/

        [TestMethod()]
        public void GetFilteredCardsTest()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);
            List<Card> cards = new List<Card>();

            Card carte1 = new Card
            {
                Name = "Potat",
                Attack = 2,
                Defense = 3,
                Id = 1,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            Card carte2 = new Card
            {
                Name = "Test",
                Attack = 12,
                Defense = 30,
                Id = 2,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            Card carte3 = new Card
            {
                Name = "Banana",
                Attack = 4,
                Defense = 15,
                Id = 3,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            cards.Add(carte1);
            cards.Add(carte2);
            cards.Add(carte3);

            db.Cards.Add(carte1);
            db.Cards.Add(carte2);
            db.Cards.Add(carte3);
            db.SaveChanges();

            var result = cardService.GetFilteredCards(null).ToList();


            Assert.AreEqual(cards.IndexOf(carte1), result.IndexOf(carte1));
            Assert.AreEqual(cards.IndexOf(carte2), result.IndexOf(carte2));
            Assert.AreEqual(cards.IndexOf(carte3), result.IndexOf(carte3));
        }

        [TestMethod()]
        public void GetFilteredCardsAttackTest()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);
            List<Card> cards = new List<Card>();

            Card carte1 = new Card
            {
                Name = "Potat",
                Attack = 2,
                Defense = 3,
                Id = 1,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            Card carte2 = new Card
            {
                Name = "Test",
                Attack = 12,
                Defense = 30,
                Id = 2,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            Card carte3 = new Card
            {
                Name = "Banana",
                Attack = 4,
                Defense = 15,
                Id = 3,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            cards.Add(carte1);
            cards.Add(carte3);
            cards.Add(carte2);

            db.Cards.Add(carte1);
            db.Cards.Add(carte2);
            db.Cards.Add(carte3);
            db.SaveChanges();

            var result = cardService.GetFilteredCards("Attack").ToList();


            Assert.AreEqual(cards.IndexOf(carte1), result.IndexOf(carte1));
            Assert.AreEqual(cards.IndexOf(carte2), result.IndexOf(carte2));
            Assert.AreEqual(cards.IndexOf(carte3), result.IndexOf(carte3));
        }

        [TestMethod()]
        public void GetFilteredCardsDefenseTest()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);
            List<Card> cards = new List<Card>();

            Card carte1 = new Card
            {
                Name = "Potat",
                Attack = 2,
                Defense = 30,
                Id = 1,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            Card carte2 = new Card
            {
                Name = "Test",
                Attack = 12,
                Defense = 14,
                Id = 2,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            Card carte3 = new Card
            {
                Name = "Banana",
                Attack = 4,
                Defense = 15,
                Id = 3,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            cards.Add(carte2);
            cards.Add(carte3);
            cards.Add(carte1);

            db.Cards.Add(carte1);
            db.Cards.Add(carte2);
            db.Cards.Add(carte3);
            db.SaveChanges();

            var result = cardService.GetFilteredCards("Defense").ToList();


            Assert.AreEqual(cards.IndexOf(carte1), result.IndexOf(carte1));
            Assert.AreEqual(cards.IndexOf(carte2), result.IndexOf(carte2));
            Assert.AreEqual(cards.IndexOf(carte3), result.IndexOf(carte3));
        }

        [TestMethod()]
        public void GetFilteredCardsNameTest()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);
            List<Card> cards = new List<Card>();

            Card carte1 = new Card
            {
                Name = "Potat",
                Attack = 2,
                Defense = 30,
                Id = 1,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            Card carte2 = new Card
            {
                Name = "Test",
                Attack = 12,
                Defense = 14,
                Id = 2,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            Card carte3 = new Card
            {
                Name = "Banana",
                Attack = 4,
                Defense = 15,
                Id = 3,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            cards.Add(carte3);
            cards.Add(carte1);
            cards.Add(carte2);

            db.Cards.Add(carte1);
            db.Cards.Add(carte2);
            db.Cards.Add(carte3);
            db.SaveChanges();

            var result = cardService.GetFilteredCards("Name").ToList();


            Assert.AreEqual(cards.IndexOf(carte1), result.IndexOf(carte1));
            Assert.AreEqual(cards.IndexOf(carte2), result.IndexOf(carte2));
            Assert.AreEqual(cards.IndexOf(carte3), result.IndexOf(carte3));
        }


        [TestMethod()]
        public void GetFilteredCardsAnyOtherStringTest()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            DeckService cardService = new DeckService(db);
            List<Card> cards = new List<Card>();

            Card carte1 = new Card
            {
                Name = "Potat",
                Attack = 2,
                Defense = 30,
                Id = 1,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            Card carte2 = new Card
            {
                Name = "Test",
                Attack = 12,
                Defense = 14,
                Id = 2,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            Card carte3 = new Card
            {
                Name = "Banana",
                Attack = 4,
                Defense = 15,
                Id = 3,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/35/Basic_human_drawing.png"
            };

            cards.Add(carte1);
            cards.Add(carte2);
            cards.Add(carte3);

            db.Cards.Add(carte1);
            db.Cards.Add(carte2);
            db.Cards.Add(carte3);
            db.SaveChanges();

            var result = cardService.GetFilteredCards("").ToList();


            Assert.AreEqual(cards.IndexOf(carte1), result.IndexOf(carte1));
            Assert.AreEqual(cards.IndexOf(carte2), result.IndexOf(carte2));
            Assert.AreEqual(cards.IndexOf(carte3), result.IndexOf(carte3));
        }
    }
}