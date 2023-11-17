using System.Text.Json;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Services.Interfaces;

namespace Super_Cartes_Infinies.Models
{
	public class Match
    {
		public Match()
		{
		}

        // Pour créer un nouveau match pour 2 players
        public Match(Player playerA, Player playerB)
        {
            Id = 0;
            IsMatchCompleted = false;
            UserAId = playerA.IdentityUserId;
            PlayerDataA = new MatchPlayerData(playerA);
            UserBId = playerB.IdentityUserId;
            PlayerDataB = new MatchPlayerData(playerB);
            SerializedEvents = new List<SerializedMatchEvent>();
        }

        public int Id { get; set; }
        
        public bool IsPlayerATurn { get; set; } = false;
        public int EventIndex { get; set; } = 0;

        public bool IsMatchCompleted { get; set; } = false;
        public string? WinnerUserId { get; set; }

        public string UserAId { get; set; }
        public string UserBId { get; set; }
        public virtual MatchPlayerData PlayerDataA { get; set; }
        public virtual MatchPlayerData PlayerDataB { get; set; }

        public virtual List<SerializedMatchEvent> SerializedEvents { get; set; }


        //Ajouter un event dans la liste d'event du match
        public string AddEvent(Event e)
        {
            string serializedEvent = JsonSerializer.Serialize(e);

            SerializedEvents.Add(new SerializedMatchEvent
            {
                SerializedEvent = serializedEvent,
                Index = EventIndex++
            });

            return serializedEvent;
        }
    }
}

