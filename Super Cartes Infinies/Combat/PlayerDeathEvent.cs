using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerDeathEvent : Event
    {

        public PlayerDeathEvent(Match match, MatchPlayerData opposingPlayerData)
        {
            Events = new List<Event>();

        }
    }
}
