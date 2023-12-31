﻿using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardActivationEvent : Event
    {
        public int PlayableCardId { get; set; }
        public int PlayerId { get; set; }
        
        // C'est important d'avir un CardActivationEvent pour permettre de jouer une animation sur la carte quand elle s'active
        public CardActivationEvent(Match match, PlayableCard playableCard, PlayableCard? opposingCard, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            Events = new List<Event>();

            PlayableCardId = playableCard.Id;
            PlayerId = currentPlayerData.PlayerId;
            
            // TODO: Implémenter la logique de combat du jeu (Il faut créer de nombreux énênements comme CardDamageEvent, PlayerDamageEvent, etc...)
        }
    }
}
