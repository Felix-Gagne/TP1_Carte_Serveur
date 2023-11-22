using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Super_Cartes_Infinies.Models
{
    public class Deck
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public string Name { get; set; }

        [ValidateNever]
        public virtual List<OwnedCard> Cards { get; set; }
    }
}
