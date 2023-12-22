using System.Text.Json.Serialization;

namespace Super_Cartes_Infinies.Models
{
    public class Pack
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public int Price { get; set; }
        public string ImageURL { get; set; }
        public int NbCards { get; set; }
        public Rarity BaseRarity { get; set; }

        [JsonIgnore]
        public virtual List<Probability> Probabilities { get; set; }
    }
}
