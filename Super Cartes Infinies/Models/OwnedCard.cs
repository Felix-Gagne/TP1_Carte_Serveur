namespace Super_Cartes_Infinies.Models
{
    public class OwnedCard
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public int CardId { get; set; }

        public virtual Card Card { get; set; }
    }
}
