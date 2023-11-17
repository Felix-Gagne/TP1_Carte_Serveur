﻿using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardActivationEvent : Event
    {
        public PlayableCard PlayableCard { get; set; }
        public int PlayerId { get; set; }
        
        // C'est important d'avir un CardActivationEvent pour permettre de jouer une animation sur la carte quand elle s'active
        public CardActivationEvent(Match match, PlayableCard playableCard, PlayableCard? opposingCard, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            Events = new List<Event>();

            PlayableCard = playableCard;
            PlayerId = currentPlayerData.PlayerId;

            // TODO: Implémenter la logique de combat du jeu (Il faut créer de nombreux énênements comme CardDamageEvent, PlayerDamageEvent, etc...)

            if (opposingCard == null)
            {
                Events.Add(new PlayerDamageEvent(match, playableCard,currentPlayerData, opposingPlayerData));
            }
            else
            {
                Events.Add(new CardDamageEvent(opposingCard, playableCard, currentPlayerData, opposingPlayerData));
                Events.Add(new CardDamageEvent(playableCard, opposingCard, opposingPlayerData, currentPlayerData));

                if (opposingCard.Health <= 0)
                {
                    Events.Add(new CardDeathEvent(opposingCard, opposingPlayerData));
                }
                if (playableCard.Health <= 0)
                {
                    Events.Add(new CardDeathEvent(playableCard, currentPlayerData));
                }
            }
        }
    }
}
