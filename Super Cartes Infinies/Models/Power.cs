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

        // Explosion fait 5 damage a tout les monstres lorsque le monstre (qui possede l'ability) meurt.
        public const int EXPLOSION_ID = 5;
        // Lorsque le monstre est joué. Le joueur peut piger 2 cartes depuis son deck et obtient 3 mana.
        public const int GREED_ID = 6;

        [ValidateNever]
        public virtual List<CardPower> cardPowers { get; set; }
    }
}
