using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDeathEvent : Event
    {
        public int PlayerId { get; set; }
        public int OppositCardId { get; set; }

        public CardDeathEvent(PlayableCard playableCard, MatchPlayerData playerData)
        {
            Events = new List<Event>();
            OppositCardId = playableCard.Id;

            playerData.BattleField.Remove(playableCard);
            playerData.Graveyard.Add(playableCard);

        }
    }
}
