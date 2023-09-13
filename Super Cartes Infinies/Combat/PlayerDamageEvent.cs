using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerDamageEvent : Event
    {
        public int PlayableCardId { get; set; }
        public int Damage { get; set; }

        public PlayerDamageEvent(Match match, PlayableCard? playableCard, MatchPlayerData opposingPlayerData)
        {
            Events = new List<Event>();
            Damage = playableCard.Attack;

            if (Damage >= opposingPlayerData.Health)
            {
                Events.Add(new PlayerDeathEvent(match, opposingPlayerData));
            }
            else
            {
                opposingPlayerData.Health = opposingPlayerData.Health - Damage;
            }

        }
    }
}
