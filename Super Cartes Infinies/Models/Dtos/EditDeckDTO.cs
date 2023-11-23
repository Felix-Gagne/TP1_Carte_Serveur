namespace Super_Cartes_Infinies.Models.Dtos
{
    public class EditDeckDTO
    {
        public string Name { get; set; }

        public List<OwnedCard> Cards { get; set; }
    }
}
