namespace Super_Cartes_Infinies.Models
{
    public class StoreCard
    {
        public int Id { get; set; }
        public int BuyAmount { get; set; }
        public int SellAmount { get; set; }

        public int CardId { get; set; }
        public virtual Card? Card { get; set; } 
    }
}
