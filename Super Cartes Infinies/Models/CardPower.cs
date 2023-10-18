using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Super_Cartes_Infinies.Models
{
    public class CardPower
    {
        public int Id { get; set; }

        public int CardId { get; set; }
        public virtual Card Card { get; set; }

        public int PowerId { get; set; }
        public virtual Power Power { get; set; }


        //Valeur du power EX: Thorn 2 <-le numéro 
        public int value { get; set; }
    }
}
