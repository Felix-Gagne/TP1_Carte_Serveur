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

            List<PlayableCard> deadCardsPlayerofDeathCard = playerDataOfDeathCard.BattleField;
            List<PlayableCard> deadCardsOpposingPlayer = opposingplayerData.BattleField;

            if (playableCard.Card.HasPower(Power.EXPLOSION_ID))
            {
                for (int i = deadCardsPlayerofDeathCard.Count - 1; i >= 0; i--)
                {

                    if (deadCardsPlayerofDeathCard[i].Health - 5 <= 0)
                    {
                        deadCardsPlayerofDeathCard[i].Health = 0;
                    }
                    else
                    {
                        deadCardsPlayerofDeathCard[i].Health -= 5;
                    }
                }
                for (int i = deadCardsOpposingPlayer.Count - 1; i >= 0; i--)
                {
                    if (deadCardsOpposingPlayer[i].Health - 5 <= 0)
                    {
                        deadCardsOpposingPlayer[i].Health = 0;
                    }
                    else
                    {
                        deadCardsOpposingPlayer[i].Health -= 5;
                    }
                }

                //Boucle qui fait les dommages a toute les cartes du jouer qui possedait la carte avec EXPLOSION
                playerDataOfDeathCard.BattleField = deadCardsPlayerofDeathCard;
                for (int i = playerDataOfDeathCard.BattleField.Count - 1; i >= 0; i--)
                {

                    if (playerDataOfDeathCard.BattleField[i].Health == 0)
                    {
                        if (playerDataOfDeathCard.BattleField[i].Card.HasPower(Power.EXPLOSION_ID))
                        {
                            playerDataOfDeathCard.BattleField[i].Health = 0;
                        }
                        else
                        {
                            Events.Add(new CardDeathEvent(playerDataOfDeathCard.BattleField[i], playerDataOfDeathCard, opposingplayerData));
                        }
                    }
                }

                //Boucle qui fait les dommages a toute les cartes ennemies
                opposingplayerData.BattleField = deadCardsOpposingPlayer;
                for (int i = opposingplayerData.BattleField.Count - 1; i >= 0; i--)
                {

                    if (opposingplayerData.BattleField[i].Health == 0)
                    {
                        if (opposingplayerData.BattleField[i].Card.HasPower(Power.EXPLOSION_ID))
                        {
                            opposingplayerData.BattleField[i].Health = 0;
                        }
                        else
                        {
                            Events.Add(new CardDeathEvent(opposingplayerData.BattleField[i], opposingplayerData, playerDataOfDeathCard));
                        }
                    }
                }

                //Boucle qui tue les cartes avec EXPLOSION du joueur qui a la carte
                for (int i = playerDataOfDeathCard.BattleField.Count - 1; i >= 0; i--)
                {

                    if (playerDataOfDeathCard.BattleField[i].Health == 0)
                    {
                        Events.Add(new CardDeathEvent(playerDataOfDeathCard.BattleField[i], playerDataOfDeathCard, opposingplayerData));
                    }
                }

                //Boucle qui tue les cartes ennemie qui ont le power EXPLOSION
                for (int i = opposingplayerData.BattleField.Count - 1; i >= 0; i--)
                {

                    if (opposingplayerData.BattleField[i].Health == 0)
                    {
                        Events.Add(new CardDeathEvent(opposingplayerData.BattleField[i], opposingplayerData, playerDataOfDeathCard));
                    }
                }
            }
        }
    }
}
