using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services.Interfaces
{
    public interface IPlayersService
    {
        public Player GetPlayerFromUserId(string userId);
    }
}
