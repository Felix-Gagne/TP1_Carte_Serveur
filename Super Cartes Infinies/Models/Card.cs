using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Super_Cartes_Infinies.Services.Interfaces;

namespace Super_Cartes_Infinies.Models
{
	public class Card
	{
		public int Id { get; set; }
		public string Name { get; set; } = "";
		public int Attack { get; set; }
		public int Defense { get; set; }
		public string ImageUrl { get; set; } = "";

		public override bool Equals(object other)
		{
			return other is Card c &&
				(c.Id, c.Name, c.Attack, c.Defense, c.ImageUrl)
					.Equals((Id, Name, Attack, Defense, ImageUrl));
		}

		//Cherche la valeur du power de la carte EX:(Thorn 2)
        public int GetPowerValue(int powerId)
        {
            return cardPowers.Single(c => c.PowerId == powerId && c.CardId == Id).value;
        }


		//Verification si la carte contient le power demander
        public bool HasPower(int powerId)
		{
			return cardPowers.Any(c => c.PowerId == powerId && c.CardId == Id);
		}


		[JsonIgnore]
		[ValidateNever]
		public virtual List<Player> Players { get; set; }

		[ValidateNever]
		public List<CardPower> cardPowers { get; set; }
	}
			
}

