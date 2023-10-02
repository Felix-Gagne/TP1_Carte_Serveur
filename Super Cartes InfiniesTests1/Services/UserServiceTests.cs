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

        [TestMethod()]
        public async void RegisterUserAsyncTest()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            UserService userService = new UserService(db);

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

            Assert.Fail();
        }
    }
}