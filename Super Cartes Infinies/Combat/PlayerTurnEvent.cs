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

            if (!match.IsMatchCompleted)
            {
                foreach (PlayableCard card in opposingPlayerData.BattleField)
                {
                    if (card.StunTurnLeft > 0)
                    {
                        card.StunTurnLeft--;
                    }

                    if (card.StunTurnLeft == 0)
                    {
                        card.Stuned = false;
                    }

                    if (card.Poisoned)
                    {
                        card.Health -= card.PoisonedLevel;
                    }
                }

                foreach (PlayableCard card in currentPlayerData.BattleField)
                {
                    if (card.Poisoned)
                    {
                        card.Health -= card.PoisonedLevel;
                    }
                }

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
}
