using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Super_Cartes_Infinies.Models
{
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }


        //Voici les ids des différents power.
        public const int CHARGE_ID = 1;
        public const int FIRSTSTRIKE_ID = 2;
        public const int THORNS_ID = 3;
        public const int HEAL_ID = 4;

        //Voici les ids pour les power que nous on décide
        //Les noms sont à changer (on choisi les powers et leurs effets)
        public const int CUSTOMPOWER1_ID = 5;
        public const int CUSTOMPOWER2_ID = 6;

        [ValidateNever]
        public virtual List<CardPower> cardPowers { get; set; }
    }
}
