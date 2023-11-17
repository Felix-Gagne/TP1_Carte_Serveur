using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class GainManaEvent : Event
    {

        public GainManaEvent(MatchPlayerData playerData)
        {

            playerData.Mana += MatchPlayerData.GAINING_MANA;

        }
    }
}
