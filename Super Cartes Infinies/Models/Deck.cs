namespace Super_Cartes_Infinies.Models
{
    public class Deck
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public string Name { get; set; }

        public virtual List<OwnedCard> Cards { get; set; }
    }
}
