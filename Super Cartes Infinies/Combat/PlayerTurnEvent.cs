﻿using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerTurnEvent : Event
    {
        public int PlayerId { get; set; }
        // L'évènement lorsqu'un joueur termine son tour
        public PlayerTurnEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            this.PlayerId = currentPlayerData.PlayerId;
            this.Events = new List<Event>();

            this.Events.Add(new CombatEvent(match, currentPlayerData, opposingPlayerData));

            // TODO: Faire piger une carte à l'adversaire
            Events.Add(new DrawCardEvent(currentPlayerData));
            // TODO: C'est la fin du tour du joueurCourrant, il faut mettre match à jour!
            // TODO: Le joueur qui commence son tour gagne du Mana. (Voir MatchPlayerData)
            if (!match.IsPlayerATurn)
            {
                match.IsPlayerATurn = true;
            }
        }

    }
}
