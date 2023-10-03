using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Super_Cartes_Infinies.Models
{
    public class StartingCards
    {
        public int Id { get; set; }

        public int CardId { get; set; }

        [ValidateNever]
        public virtual Card Card { get; set; }

    }
}
