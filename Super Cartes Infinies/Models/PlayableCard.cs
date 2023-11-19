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
        }

        public int Id { get; set; }
		public virtual Card Card { get; set; }
		public int Health { get; set; }
        public bool SummonSickness { get; set; }

        public int Attack { get { return Card.Attack; } }
    }
}

