using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;

namespace Super_Cartes_Infinies.Services
{
    public class StatsService
    {
        private ApplicationDbContext _context;

        public async Task<ActionResult<StatsDTO>> GetGeneralStats(string uId)
        {
            StatsDTO dto = new StatsDTO();



            return null;
        }
    }
}
