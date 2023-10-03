using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Services.Tests
{
    [TestClass()]
    public class UserServiceTests 
    {
        DbContextOptions<ApplicationDbContext> options;
        public UserServiceTests()
        {
            // TODO On initialise les options de la BD, on utilise une InMemoryDatabase
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                // TODO il faut installer la dépendance Microsoft.EntityFrameworkCore.InMemory
                .UseInMemoryDatabase(databaseName: "UserService")
                .Options;
        }

        [TestInitialize]
        public void Init()
        {
            // TODO avoir la durée de vie d'un context la plus petite possible
            using ApplicationDbContext db = new ApplicationDbContext(options);
            // TODO on ajoute des données de tests
            var cardList = new List<Card>
            {
                new Card { Id = 1, Attack = 10, Defense = 10, ImageUrl = "allo", Name = "yo"},
                new Card { Id = 2, Attack = 11, Defense = 10, ImageUrl = "allo", Name = "yo"},
            };
            db.Cards.Add(cardList[0]);
            db.Cards.Add(cardList[1]);
            db.SaveChanges();


            var startingCardsList = new List<StartingCards>
            {
                new StartingCards {Id = 1, Card = cardList.First(), CardId = 1},
                new StartingCards {Id = 2, Card = cardList.Last(), CardId = 2},
            };
            db.StartingCards.Add(startingCardsList[0]);
            db.StartingCards.Add(startingCardsList[1]);
            db.SaveChanges();
        }
        [TestCleanup]
        public void Dispose()
        {
            //TODO on efface les données de tests pour remettre la BD dans son état initial
            using ApplicationDbContext db = new ApplicationDbContext(options);
            db.Cards.RemoveRange(db.Cards);
            db.SaveChanges();
        }

        [TestMethod()]
        public async Task RegisterUserAsyncTest()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            UserService userService = new UserService(db);

            var cardList = db.StartingCards.ToList();

            var register = new RegisterDTO
            {
                Password = "Passw0rd!",
                PasswordConfirm = "Passw0rd!",
                Username = "Test",
                Email = "asd@gmail.com"
            };

            IdentityUser user = new IdentityUser()
            {
                UserName = register.Username,
                Email = register.Email,
            };

            Player player = new Player()
            {
                IdentityUserId = user.Id,
                IdentityUser = user,
                Name = register.Username,
                DeckCard = new List<Card>(),
                Money = 0
            };

            foreach(var card in cardList)
            {
                player.DeckCard.Add(card.Card);
            }

            IdentityResult result = await userService.RegisterUserAsync(register, user);

            Assert.IsTrue(result.Succeeded); // Check if the registration was successful
        }
    }
}