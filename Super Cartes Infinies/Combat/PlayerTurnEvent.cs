using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerTurnEvent : Event
    {
        public int PlayerId { get; set; }
        // L'évènement lorsqu'un joueur termine son tour
        public PlayerTurnEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            this.PlayerId = currentPlayerData.PlayerId;
            Events = new List<Event>();

            //Combat
            Events.Add(new CombatEvent(match, currentPlayerData, opposingPlayerData));

            // TODO: Faire piger une carte à l'adversaire
            Events.Add(new DrawCardEvent(opposingPlayerData));
            // Joueur Opposé gagne du Mana
            Events.Add(new GainManaEvent(opposingPlayerData));
            if (!match.IsPlayerATurn)
            {
                match.IsPlayerATurn = true;
            }
            else
            {
                match.IsPlayerATurn = false;
            }
        }

    }
}
