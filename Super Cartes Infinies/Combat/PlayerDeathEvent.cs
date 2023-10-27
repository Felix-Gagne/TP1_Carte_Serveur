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
                Events.Add(new EndMatchEvent(match, match.PlayerDataA, match.PlayerDataB));
            }
            else
            {
                match.WinnerUserId = match.UserBId;
                Events.Add(new EndMatchEvent(match, match.PlayerDataB, match.PlayerDataA));
            }
            match.IsMatchCompleted = true;

        }
    }
}
