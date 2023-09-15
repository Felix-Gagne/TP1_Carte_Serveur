using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerDeathEvent : Event
    {

        public PlayerDeathEvent(Match match, MatchPlayerData currentPlayerData)
        {
            Events = new List<Event>();

            if (match.PlayerDataA.Id == currentPlayerData.Id)
            {
                match.WinnerUserId = match.UserAId;
            }
            else
            {
                match.WinnerUserId = match.UserBId;
            }
            match.IsMatchCompleted = true;

        }
    }
}
