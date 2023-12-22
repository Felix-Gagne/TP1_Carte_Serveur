using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class EndMatchEvent : Event
    {
        public int winningMoney;
        public int losingMoney;

        public int WinningPlayerId { get; set; }
        public int LosingPlayerId { get; set; }

        public EndMatchEvent(Match match, MatchPlayerData winner, MatchPlayerData loser)
        {
            winningMoney = 150;
            losingMoney = 50;

            winner.Player.Money += winningMoney;
            loser.Player.Money += losingMoney;

            winner.Player.Wins += 1;
            loser.Player.Loses += 1;

            match.IsMatchCompleted = true;
        }

        
    }
}
