
 using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Super_Cartes_Infinies.Services.Interfaces;

namespace Super_Cartes_Infinies.Models
{
	public class Player
    {
		public Player()
		{
			
		}

		public int Id { get; set; }
		public string Name { get; set; } = "";
		public int Money { get; set; }
		public int? SelectedDeckId { get; set; }
		public required string IdentityUserId { get; set; }
		[JsonIgnore]
		public virtual IdentityUser? IdentityUser { get; set; }
		// TODO: Ajouter les cartes du joueur	
		public virtual List<Deck> DeckCard { get; set; }
		public virtual List<OwnedCard> OwnedCard { get; set;}
	}
}

