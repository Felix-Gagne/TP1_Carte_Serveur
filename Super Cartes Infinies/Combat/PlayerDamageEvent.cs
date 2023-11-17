using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerDamageEvent : Event
    {
        public int PlayableCardId { get; set; }
        public int Damage { get; set; }

        public PlayerDamageEvent(Match match, PlayableCard? playableCard,MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            Events = new List<Event>();
            Damage = playableCard.Attack;

            if (Damage >= opposingPlayerData.Health)
            {
                opposingPlayerData.Health = 0;
                Events.Add(new PlayerDeathEvent(match, currentPlayerData));
            }
            else
            {
                opposingPlayerData.Health -= Damage;
            }

        }
    }
}
