using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDeathEvent : Event
    {
        public int PlayerId { get; set; }
        public int OppositCardId { get; set; }

        public CardDeathEvent(PlayableCard oppositeCard, MatchPlayerData opposingPlayerData)
        {
            Events = new List<Event>();
            OppositCardId = oppositeCard.Id;

            opposingPlayerData.BattleField.Remove(oppositeCard);
            opposingPlayerData.Graveyard.Add(oppositeCard);

        }
    }
}
