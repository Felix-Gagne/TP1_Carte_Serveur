using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class LoseManaEvent : Event
    {
        public LoseManaEvent(MatchPlayerData playerData, PlayableCard playableCard)
        {

            playerData.Mana -= playableCard.Card.ManaCost;

        }
    }
}
