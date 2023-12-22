using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerDamageEvent : Event
    {
        public int PlayableCardId { get; set; }
        public int Damage { get; set; }

        public PlayerDamageEvent(Match match, PlayableCard? playableCard,MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            Events = new List<Event>();
            Damage = playableCard.Attack;
            if(playableCard.Card.HasPower(Power.LIGHTINGSTRIKE_ID))
            {
                if(playableCard.Card.GetPowerValue(Power.LIGHTINGSTRIKE_ID) < opposingPlayerData.Health)
                {
                    opposingPlayerData.Health -= playableCard.Card.GetPowerValue(Power.LIGHTINGSTRIKE_ID);
                    playableCard.Health = 0;
                    currentPlayerData.BattleField.Remove(playableCard);
                    currentPlayerData.Graveyard.Add(playableCard);
                }
                else
                {
                    opposingPlayerData.Health = 0;
                    playableCard.Health = 0;
                    currentPlayerData.BattleField.Remove(playableCard);
                    currentPlayerData.Graveyard.Add(playableCard);
                    Events.Add(new PlayerDeathEvent(match, currentPlayerData));
                }
            }
            else
            {
                if (Damage >= opposingPlayerData.Health)
                {
                    opposingPlayerData.Health = 0;
                    Events.Add(new PlayerDeathEvent(match, currentPlayerData));
                }
                else
                {
                    opposingPlayerData.Health -= Damage;
                }
            }
        }
    }
}
