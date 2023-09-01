using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services.Interfaces;

namespace Super_Cartes_Infinies.Services
{
	public class PlayersService : IPlayersService
    {
        private ApplicationDbContext _context;

        public PlayersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Player GetPlayerFromUserId(string userId)
        {
            return _context.Players.Single(p => p.IdentityUserId == userId);
        }
    }
}

