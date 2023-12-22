using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardActivationEvent : Event
    {
        public PlayableCard PlayableCard { get; set; }
        public int PlayerId { get; set; }
        
        // C'est important d'avir un CardActivationEvent pour permettre de jouer une animation sur la carte quand elle s'active
        public CardActivationEvent(Match match, PlayableCard playableCard, PlayableCard? opposingCard, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            Events = new List<Event>();

            PlayableCard = playableCard;
            PlayerId = currentPlayerData.PlayerId;

            // TODO: Implémenter la logique de combat du jeu (Il faut créer de nombreux énênements comme CardDamageEvent, PlayerDamageEvent, etc...)

            if (opposingCard == null)
            {
                Events.Add(new PlayerDamageEvent(match, playableCard,currentPlayerData, opposingPlayerData));
            }
            else
            
                if(playableCard.Stuned == false)
                {
                if (playableCard.Card.HasPower(Power.FIRSTSTRIKE_ID))
                {

                    Events.Add(new CardDamageEvent(playableCard, opposingCard, opposingPlayerData, currentPlayerData));
                    if (opposingCard.Health > 0)
                    {
                        Events.Add(new CardDamageEvent(opposingCard, playableCard, currentPlayerData, opposingPlayerData));
                    }
                }
                else if (playableCard.Card.HasPower(Power.LIGHTINGSTRIKE_ID))
                {
                    Events.Add(new PlayerDamageEvent(match, playableCard, currentPlayerData, opposingPlayerData));
                }
                else
                {
                    if (opposingCard.Card.HasPower(Power.THORNS_ID))
                    {
                        Events.Add(new CardDamageEvent(playableCard, opposingCard, opposingPlayerData, currentPlayerData));
                    }
                    else
                    {
                        if (playableCard.Card.HasPower(Power.HEAL_ID))
                        {
                            Events.Add(new CardDamageEvent(playableCard, opposingCard, opposingPlayerData, currentPlayerData));
                            Events.Add(new CardDamageEvent(opposingCard, playableCard, currentPlayerData, opposingPlayerData));
                        }
                        else if (playableCard.Card.HasPower(Power.POISON_ID))
                        {
                            Events.Add(new CardDamageEvent(playableCard, opposingCard, opposingPlayerData, currentPlayerData));
                            Events.Add(new CardDamageEvent(opposingCard, playableCard, currentPlayerData, opposingPlayerData));
                        }
                        else if (playableCard.Card.HasPower(Power.STUN_ID) && opposingCard.Stuned != false)
                        {
                            Events.Add(new CardDamageEvent(playableCard, opposingCard, opposingPlayerData, currentPlayerData));
                            Events.Add(new CardDamageEvent(opposingCard, playableCard, currentPlayerData, opposingPlayerData));
                        }
                        else if (playableCard.Card.HasPower(Power.EARTHQUAKE_ID))
                        {
                            Events.Add(new CardDamageEvent(playableCard, opposingCard, opposingPlayerData, currentPlayerData));
                        }
                        else
                        {
                            Events.Add(new CardDamageEvent(opposingCard, playableCard, currentPlayerData, opposingPlayerData));
                            Events.Add(new CardDamageEvent(playableCard, opposingCard, opposingPlayerData, currentPlayerData));
                        }
                    }
                }
            }
        }
    }
}
