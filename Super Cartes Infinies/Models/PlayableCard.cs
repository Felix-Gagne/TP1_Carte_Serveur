using System;
using System.ComponentModel.DataAnnotations;
using Super_Cartes_Infinies.Services.Interfaces;

namespace Super_Cartes_Infinies.Models
{
	public class PlayableCard
    {
		public PlayableCard()
		{
        }

        public PlayableCard(Card c)
        {
			Card = c;
            Health = c.Defense;
            SummonSickness = true;
            Poisoned = false;
        }

        public int Id { get; set; }
		public virtual Card Card { get; set; }
		public int Health { get; set; }
        public bool SummonSickness { get; set; }
        public bool Poisoned { get; set; }
        public int PoisonedLevel { get; set; }
        public bool Stuned { get; set; }
        public int StunTurnLeft { get; set; }
        public bool QuickPlayCard { get; set; }

        public int Attack { get { return Card.Attack; } }
    }
}

