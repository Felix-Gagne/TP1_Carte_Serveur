using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class StartMatchEvent : Event
    {
        public const int NB_STARTING_CARDS = 3;

        public StartMatchEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            Events = new List<Event> { };
            
            // On pige les cartes du début
            for(int i = 0; i < NB_STARTING_CARDS; i++)
            {
                Events.Add(new DrawCardEvent(currentPlayerData));
                Events.Add(new DrawCardEvent(opposingPlayerData));
            }
            
            // On fait piger la carte de début de tour du premier joueur
            Events.Add(new DrawCardEvent(currentPlayerData));
        }
    }
}
