using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Super_Cartes_Infinies.Models
{
    public class CardPower
    {
        public int Id { get; set; }

        //La carte en question
        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }
        public virtual Card Card { get; set; }

        //Le power qui lui est donné
        [ForeignKey(nameof(Power))]
        public int PowerId { get; set; }
        public virtual Power Power { get; set; }


        //Valeur du power EX: Thorn 2 <-le numéro 
        public int value { get; set; }
    }
}
