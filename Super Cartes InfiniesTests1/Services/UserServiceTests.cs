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
            db.Players.RemoveRange(db.Players);
            db.SaveChanges();
        }

        [TestMethod()]
        public async Task GoodRegisterTest()
        {
            ApplicationDbContext db = new ApplicationDbContext(options);
            UserService userService = new UserService(db);

            var cardListDepart = db.StartingCards.ToList();
            var deck = db.StartingCards.Select(x => x.Card).ToList();

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
            
            IdentityResult result = await userService.RegisterUserAsync(register, user);

            Player player = await db.Players.Where(x => x.IdentityUserId == user.Id).FirstOrDefaultAsync();

            Assert.IsNotNull(player);
            Assert.AreNotEqual(cardListDepart, 0);
            Assert.AreEqual(player.DeckCard.Count, deck.Count);
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


        [TestMethod()]
        public async Task LoginUserFailTest()
        {
            ApplicationDbContext db = new ApplicationDbContext(options);
            UserService userService = new UserService(db);

            IdentityUser user = null;

            // Act
            LoginDTO login = new LoginDTO
            {
                Username = "",
                Password = "Password",
            };

            LoginResult result = await userService.LoginUserAsync(login, user);

            Assert.IsFalse(result.Success); // Check that the login was not successful
            Assert.AreEqual(result.Error, "L'utilisateur est introuvable ou le mot de passe ne concorde pas."); // check that we return the good error
        }
    }
}
