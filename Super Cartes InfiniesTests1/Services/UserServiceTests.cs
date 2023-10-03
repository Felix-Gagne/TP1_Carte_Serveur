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
            // TODO Initialize the database options using an InMemoryDatabase
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                // TODO Install the Microsoft.EntityFrameworkCore.InMemory package
                .UseInMemoryDatabase(databaseName: "UserService")
                .Options;
        }

        [TestInitialize]
        public void Init()
        {
            // TODO Minimize the context's lifetime
            using ApplicationDbContext db = new ApplicationDbContext(options);

            // TODO Add test data, including cards with non-null properties
            var cardList = new List<Card>
            {
                new Card { Id = 1, Attack = 10, Defense = 10, ImageUrl = "allo", Name = "yo"},
                new Card { Id = 2, Attack = 11, Defense = 10, ImageUrl = "allo", Name = "yo"},
            };
            db.Cards.AddRange(cardList);

            var startingCardsList = new List<StartingCards>
            {
                new StartingCards {Id = 1, CardId = 1},
                new StartingCards {Id = 2, CardId = 2},
            };
            db.StartingCards.AddRange(startingCardsList);

            db.SaveChanges();
        }

        [TestCleanup]
        public void Dispose()
        {
            // TODO Clear test data to reset the database
            using ApplicationDbContext db = new ApplicationDbContext(options);
            db.Cards.RemoveRange(db.Cards);
            db.StartingCards.RemoveRange(db.StartingCards);
            db.SaveChanges();
        }

        [TestMethod()]
        public async Task GoodRegisterTest()
        {
            ApplicationDbContext db = new ApplicationDbContext(options);
            UserService userService = new UserService(db);

            var cardList2 = db.StartingCards.ToList();
            var cardList = db.StartingCards.Include(sc => sc.Card).ToList();

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

            foreach (var card in cardList)
            {
                player.DeckCard.Add(card.Card);
            }

            IdentityResult result = await userService.RegisterUserAsync(register, user);

            Assert.IsTrue(result.Succeeded); // Check if the registration was successful
        }

        [TestMethod()]
        public async Task BadRegisterTest()
        {
            ApplicationDbContext db = new ApplicationDbContext(options);
            UserService userService = new UserService(db);

            var register = new RegisterDTO
            {
                Password = "Passw0rd!",
                PasswordConfirm = "Passw0rd!",
                Username = "Test",
                Email = null
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

            IdentityResult result = await userService.RegisterUserAsync(register, user);

            Assert.IsFalse(result.Succeeded); // Check if the registration was successful
        }

        [TestMethod()]
        public async Task LoginUserAsyncTest()
        {
            ApplicationDbContext db = new ApplicationDbContext(options);
            UserService userService = new UserService(db);

            IdentityUser user = new IdentityUser
            {
                Id = "user123", 
                UserName = "TestUser",
                Email = "test@example.com",
            };

            // Act
            LoginDTO login = new LoginDTO
            {
                Username = "TestUser",
                Password = "Password",
            };

            LoginResult result = await userService.LoginUserAsync(login, user);

            Assert.IsTrue(result.Success); // Check that the login was successful
            Assert.AreEqual(login.Username, result.MonDTO.Name); // Check that the returned name matches the login username
            Assert.AreEqual(user.Id, result.MonDTO.Id);
        }
    }
}
