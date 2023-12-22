namespace Super_Cartes_Infinies.Models
{
    public class Probability
    {
        public int Id { get; set; }
        public double value { get; set; }
        public Rarity rarity { get; set; }
        public int baseQty { get; set; }


        public int PackId { get; set; }
        public virtual Pack Pack {  get; set; } 
    }
}
