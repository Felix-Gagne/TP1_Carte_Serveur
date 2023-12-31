﻿using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CombatEvent : Event
    {
        public CombatEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            Events = new List<Event>();

            // TODO: C'est le moment de faire s'affronter les cartes
            // Pour chaque carte sur le BattleField du joueur courrant, il faut créer un CardActivationEvent
            // L'opposingCard c'est la carte qui a le même index sur le BattleField de l'adversaire
            // Si il n'y en a pas, on passe simplement null
        }
    }
}
