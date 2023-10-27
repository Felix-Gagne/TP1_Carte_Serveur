using Super_Cartes_Infinies.Models;
using System.Text.Json.Serialization;

namespace Super_Cartes_Infinies.Combat
{
    [JsonDerivedType(typeof(CardActivationEvent), typeDiscriminator: "CardActivation")]
    [JsonDerivedType(typeof(CombatEvent), typeDiscriminator: "Combat")]
    [JsonDerivedType(typeof(DrawCardEvent), typeDiscriminator: "DrawCard")]
    [JsonDerivedType(typeof(PlayCardEvent), typeDiscriminator: "PlayCard")]
    [JsonDerivedType(typeof(PlayerTurnEvent), typeDiscriminator: "PlayerTurn")]
    [JsonDerivedType(typeof(StartMatchEvent), typeDiscriminator: "StartMatch")]
    [JsonDerivedType(typeof(CardDamageEvent), typeDiscriminator: "CardDamage")]
    [JsonDerivedType(typeof(CardDeathEvent), typeDiscriminator: "CardDeath")]
    [JsonDerivedType(typeof(PlayerDamageEvent), typeDiscriminator: "PlayerDamage")]
    [JsonDerivedType(typeof(PlayerDeathEvent), typeDiscriminator: "PlayerDeath")]
    [JsonDerivedType(typeof(EndMatchEvent), typeDiscriminator: "EndMatch")]
    public abstract class Event
    {
        public Event()
        {
        }

        public List<Event>? Events { get; set; }
    }
}
