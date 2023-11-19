using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDeathEvent : Event
    {
        public int PlayerId { get; set; }
        public int OppositCardId { get; set; }

        public CardDeathEvent(PlayableCard playableCard, MatchPlayerData playerDataOfDeathCard, MatchPlayerData opposingplayerData)
        {
            Events = new List<Event>();
            OppositCardId = playableCard.Id;

            

            playerDataOfDeathCard.BattleField.Remove(playableCard);
            playerDataOfDeathCard.Graveyard.Add(playableCard);

            if (playableCard.Card.HasPower(Power.EXPLOSION_ID))
            {
                for (int i = opposingplayerData.BattleField.Count - 1; i >= 0; i--)
                {

                    if (opposingplayerData.BattleField[i].Health - 5 <= 0)
                    {
                        opposingplayerData.BattleField[i].Health = 0;
                        Events.Add(new CardDeathEvent(opposingplayerData.BattleField[i], opposingplayerData, playerDataOfDeathCard));
                    }
                    else
                    {
                        opposingplayerData.BattleField[i].Health -= 5;
                    }
                }
                for (int i = playerDataOfDeathCard.BattleField.Count - 1; i >= 0; i--)
                {
                    if (playerDataOfDeathCard.BattleField[i].Health - 5 <= 0)
                    {
                        playerDataOfDeathCard.BattleField[i].Health = 0;
                        Events.Add(new CardDeathEvent(playerDataOfDeathCard.BattleField[i], playerDataOfDeathCard, opposingplayerData));
                    }
                    else
                    {
                        playerDataOfDeathCard.BattleField[i].Health -= 5;
                    }
                }
            }

        }
    }
}
