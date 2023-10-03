using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Controllers;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;


namespace Super_Cartes_Infinies.Services
{
    public class UserService
    {

        private ApplicationDbContext _context;


        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterDTO register, IdentityUser user)
        {

            var list = await _context.StartingCards.ToListAsync();

            var player = new Player
            {
                IdentityUserId = user.Id,
                IdentityUser = user,
                Name = register.Username,
                DeckCard = new List<Card>(),
                Money = 0
            };

            foreach (StartingCards startingCard in list)
            {
                player.DeckCard.Add(startingCard.Card);
            }


            if (user.UserName != null && user.Email != null)
            {
                await _context.Players.AddAsync(player);
                await _context.SaveChangesAsync();

                // Return IdentityResult.Success to indicate success.
                return IdentityResult.Success;
            }
            else
            {
                return IdentityResult.Failed();
            }



        }




        public async Task<LoginResult> LoginUserAsync(LoginDTO login, IdentityUser user)
        {
            if (user != null)
            {
                if(login.Username != null && login.Password != null)
                {
                    return new LoginResult
                    {
                        Success = true,

                        MonDTO = new MonDTO { Name = login.Username, Id = user.Id }
                    };
                }
            }

            return new LoginResult
            {
                Success = false,
                Error = "L'utilisateur est introuvable ou le mot de passe ne concorde pas."
            };
        }

        /*[HttpPost]
        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }*/


    }
}

