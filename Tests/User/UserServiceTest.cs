using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.User
{
    [TestClass]
    internal class UserServiceTest
    {
        private ApplicationDbContext _dbContext;
        private UserService _userService;
        public UserServiceTest()
        {

        }

        [TestInitialize]
        public void Init()
        {
        }

        [TestCleanup]
        public void Dispose()
        {
        }

        [TestMethod]
        public async void RegisterUserAsync()
        {
            


            var register = new RegisterDTO
            {
                Password = "Passw0rd!",
                PasswordConfirm = "Passw0rd!",
                Username = "Test",
                Email = "asd@gmail.com"
            };

            var result = await _userService.RegisterUserAsync(register);

            Assert.AreEqual(IdentityResult.Success, result);

            /*var user = await _dbContext.Users.Where(x => x.UserName == register.Username).SingleOrDefaultAsync();
            Assert.IsNotNull(user);

            var player = await _dbContext.Players.SingleOrDefaultAsync(x => x.IdentityUserId == user.Id);
            Assert.IsNotNull(player);

            var carteDepart = await _dbContext.StartingCards.ToListAsync();


            foreach(var card in carteDepart)
            {
                player.DeckCard.Add(card.Card);
            }
            */




        }


    }
}
