using Super_Cartes_Infinies.Models;
using System.Text.Json.Serialization;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayCardEvent : Event
    {
        public int PlayableCardId { get; set; }
        public int PlayerId { get; set; }

        // L'évènement lorsqu'un joueur joue une carte
        public PlayCardEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int playableCardId)
        {
            this.PlayableCardId = playableCardId;
            this.PlayerId = currentPlayerData.PlayerId;
            this.Events = new List<Event>();

            if(playableCardId != 0)
            {
                // TODO: Déplacer la carte sur le BattleField
                currentPlayerData.BattleField.Add(currentPlayerData.Hand.Where(x => x.Id == PlayableCardId).SingleOrDefault());
            }

            // Pour l'instant le joueur ne peut jouer qu'une seule carte, alors on termine le tour!
            this.Events.Add(new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData));
        }
    }
}
