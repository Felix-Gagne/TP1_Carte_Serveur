﻿using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDamageEvent : Event
    {
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }
        public int OppositeCardId { get; set; }
        public int Damage { get; set; }

        public CardDamageEvent( PlayableCard playableCard, PlayableCard? opposingCard, MatchPlayerData opposingPlayerData, MatchPlayerData currentPlayerData)
        {
            Events = new List<Event>();
            PlayableCardId = playableCard.Id;
            OppositeCardId = opposingCard.Id;
            Damage = playableCard.Attack;

            if (opposingCard.Card.HasPower(Power.THORNS_ID))
            {
                playableCard.Health -= opposingCard.Card.GetPowerValue(Power.THORNS_ID);
            }

            if (playableCard.Health <= 0)
            {
                playableCard.Health = 0;
                Events.Add(new CardDeathEvent(playableCard, currentPlayerData, opposingPlayerData));
            }
            else
            {
                if (playableCard.Card.HasPower(Power.HEAL_ID))
                {
                    for (int i = 0; i < currentPlayerData.BattleField.Count; i++)
                    {
                        if (currentPlayerData.BattleField[i].Health + playableCard.Card.GetPowerValue(Power.HEAL_ID) <= currentPlayerData.BattleField[i].Card.Defense)
                        {
                            currentPlayerData.BattleField[i].Health += playableCard.Card.GetPowerValue(Power.HEAL_ID);
                        }
                        else
                        {
                            currentPlayerData.BattleField[i].Health = currentPlayerData.BattleField[i].Card.Defense;
                        }
                    }
                }

                if (Damage >= opposingCard.Health)
                {
                    opposingCard.Health = 0;
                    Events.Add(new CardDeathEvent(opposingCard, opposingPlayerData, currentPlayerData));
                }
                else
                {
                    opposingCard.Health -= Damage;
                }
            }
        }
    }
}
