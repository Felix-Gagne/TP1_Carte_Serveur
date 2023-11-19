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
		//Coût en mana de la carte
		public int ManaCost { get; set; }
		public int Attack { get; set; }
		public int Defense { get; set; }
		public string ImageUrl { get; set; } = "";

		public override bool Equals(object other)
		{
			return other is Card c &&
				(c.Id, c.Name, c.Attack, c.Defense, c.ImageUrl)
					.Equals((Id, Name, Attack, Defense, ImageUrl));
		}

		//Cherche la valeur du power de la carte EX:(Thorn 2) dans ce cas si la méthode retuorne 2
		public int GetPowerValue(int powerId)
		{
			var power = cardPowers?.SingleOrDefault(c => c.PowerId == powerId && c.CardId == Id);
			if (power != null)
			{
				int powervalue = power.value;
				return powervalue;
			}
			return 0;
		}


		//Verification si la carte contient le power demandé. Si on veut voir si la carte a charge il faut juste entrer Power.CHARGE.ID
		public bool HasPower(int powerId)
		{
			//return cardPowers.Any(c => c.PowerId == powerId && c.CardId == this.Id);
			var result = cardPowers?.SingleOrDefault(c => c.PowerId == powerId && c.CardId == this.Id);
			if (result == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}


		[JsonIgnore]
		[ValidateNever]
		public virtual List<Player> Players { get; set; }

		[ValidateNever]
		public virtual List<CardPower> cardPowers { get; set; }
	}
			
}

