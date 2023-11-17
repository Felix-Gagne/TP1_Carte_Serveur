using Super_Cartes_Infinies.Models;
using System.Text.Json.Serialization;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayCardEvent : Event
    {
        public PlayableCard LaCarte { get; set; }
        public int PlayerId { get; set; }

        // L'évènement lorsqu'un joueur joue une carte
        public PlayCardEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, PlayableCard playableCard)
        {
            this.LaCarte = playableCard;
            this.PlayerId = currentPlayerData.PlayerId;
            this.Events = new List<Event>();

            if(LaCarte.Id != 0)
            {
                // TODO: Utiliser le mana du joueur pour jouer la carte.
                this.Events.Add(new LoseManaEvent(currentPlayerData, LaCarte));
                // TODO: Déplacer la carte sur le BattleField
                currentPlayerData.BattleField.Add(currentPlayerData.Hand.Where(x => x.Id == LaCarte.Id).SingleOrDefault());
                currentPlayerData.Hand.Remove(currentPlayerData.Hand.Where(x => x.Id == LaCarte.Id).SingleOrDefault());
                
            }

            // Pour l'instant le joueur ne peut jouer qu'une seule carte, alors on termine le tour!
            //this.Events.Add(new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData));
        }
    }
}
