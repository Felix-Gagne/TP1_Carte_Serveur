using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDamageEvent : Event
    {
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }
        public int OppositeCardId { get; set; }
        public int Damage { get; set; }

        public CardDamageEvent( PlayableCard playableCard, PlayableCard? opposingCard, MatchPlayerData opposingPlayerData, MatchPlayerData currentPlayerData)
        {
            Events = new List<Event>();
            PlayableCardId = playableCard.Id;
            OppositeCardId = opposingCard.Id;
            Damage = playableCard.Attack;

            if (Damage >= opposingCard.Health)
            {
                opposingCard.Health = 0;
                Events.Add(new CardDeathEvent(opposingCard, opposingPlayerData));
            }
            else
            {
                opposingCard.Health = opposingCard.Health - Damage;
            }
        }
    }
}
