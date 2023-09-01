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
    public abstract class Event
    {
        public Event()
        {
        }

        public List<Event>? Events { get; set; }
    }
}
