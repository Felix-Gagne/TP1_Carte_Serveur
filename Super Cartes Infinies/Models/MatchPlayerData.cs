using Super_Cartes_Infinies.Services.Interfaces;

namespace Super_Cartes_Infinies.Models
{
	public class MatchPlayerData
    {
		private const int STARTING_HEALTH = 20;
        private const int STARTING_MANA = 2;
        private const int GAINING_MANA = 3;

        public MatchPlayerData()
        {
        }

        // Utilisé par les tests
        public MatchPlayerData(int playerId)
		{
            PlayerId = playerId;
            Health = STARTING_HEALTH;
            Mana = STARTING_MANA;
            CardsPile = new List<PlayableCard>();
            Hand = new List<PlayableCard>();
            BattleField = new List<PlayableCard>();
            Graveyard = new List<PlayableCard>();
        }

        // Utilisé lors de la création d'un nouveau Match
        public MatchPlayerData(Player p) : this(p.Id)
        {
            // TODO: Ajouter les PlayableCards dans CardsPile à partir des cartes du joueur
            //foreach(Card card in p.DeckCard)
            //{
            //    PlayableCard playable = new PlayableCard(card);
            //    CardsPile.Add(playable);
            //}
            
        }

        public int Id { get; set; }
		public int Health { get; set; }
        public int Mana { get; set; }

        public virtual Player Player { get; set; }
        public int PlayerId { get; set; }

        public virtual List<PlayableCard> CardsPile { get; set; }
        public virtual List<PlayableCard> Hand { get; set; }

        public virtual List<PlayableCard> BattleField { get; set; }
        public virtual List<PlayableCard> Graveyard { get; set; }
    }
}

