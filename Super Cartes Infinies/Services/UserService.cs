﻿using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<IdentityResult> RegisterUserAsync(RegisterDTO register, IdentityUser user, IdentityResult result)
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

            if(result.Succeeded)
            {
                await _context.Players.AddAsync(player);
                await _context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            return result;

        }

        /*public async Task<LoginResult> LoginUserAsync(LoginDTO login)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(login.Username, login.Password, true, lockoutOnFailure: false);

            if (signInResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(login.Username);
                if(user != null)
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
        }*/

        /*[HttpPost]
        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }*/


    }
}
