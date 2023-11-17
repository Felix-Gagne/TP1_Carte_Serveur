using Microsoft.AspNetCore.Razor.Language;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services.Interfaces;

namespace Super_Cartes_Infinies.Services
{
	public class MatchesService
	{
		private WaitingUserService _waitingUserService;
		private IPlayersService _playersService;
		private ApplicationDbContext _context;

		public MatchesService(ApplicationDbContext context, WaitingUserService waitingUserService, IPlayersService playersService)
		{
			_context = context;
			_waitingUserService = waitingUserService;
			_playersService = playersService;
		}

		// Cette fonction est assez flexible car elle peut simplement être appeler lorsqu'un user veut jouer un match
		// Si le user a déjà un match en cours (Un match qui n'est pas terminé), on lui retourne l'information pour ce match
		// Sinon on utilise le WaitingUserService pour essayer de trouver un autre user ou nous mettre en attente
		public async Task<JoiningMatchData?> JoinMatch(string userId)
		{
			// Vérifier si le match n'a pas déjà été démarré (de façon plus générale, retourner un match courrant si le joueur y participe)
			IEnumerable<Match> matches = _context.Matches.Where(m => m.IsMatchCompleted == false && (m.UserAId == userId || m.UserBId == userId));

			if(matches.Count() > 1)
			{
				throw new Exception("A player should never be playing 2 matches at the same time!");
			}

			Match? match = null;
			Player? playerA = null;
			Player? playerB = null;

			// Le joueur est dans un match en cours
			if (matches.Count() == 1)
			{
				match = matches.First();
				playerA = _playersService.GetPlayerFromUserId(match.UserAId);
				playerB = _playersService.GetPlayerFromUserId(match.UserBId);
			}
			else
			{
				UsersReadyForAMatch? pairOfUsers = _waitingUserService.LookForWaitingUser(userId);

				if (pairOfUsers != null)
				{
					playerA = _playersService.GetPlayerFromUserId(pairOfUsers.UserAId);
					playerB = _playersService.GetPlayerFromUserId(pairOfUsers.UserBId);

					// Création d'un nouveau match
					match = new Match(playerA, playerB);

					_context.Add(match);
					await _context.SaveChangesAsync();
				}
			}

			if(match != null) {
				return new JoiningMatchData
				{
					Match = match,
					PlayerA = playerA!,
					PlayerB = playerB!,
				};
			}

			return null;
		}

		// Le user qui est le premier joueur d'un match doit appeler cette fonction pour démarrer le match
		// L'action retourne le json de l'event de création de match (StartMatchEvent)
		// (N'oubliez pas de mettre le eventIndex du match sur le CLIENT à jour après avoir appelé cette méthode)
		public async Task<string> StartMatch(string userId, int matchId)
		{
			Match? match = await _context.Matches.FindAsync(matchId);

			if (match == null)
				throw new Exception("Impossible de trouver le match");

			if (match.IsMatchCompleted)
				throw new Exception("Le match est déjà terminé");

			if (match.UserAId != userId && match.UserBId != userId)
				throw new Exception("Le joueur n'est pas dans ce match");

			if ((match.UserAId == userId) != match.IsPlayerATurn)
				throw new Exception("Ce n'est pas le tour de ce joueur");

			if (match.EventIndex != 0)
				throw new Exception("On peut seulement démarrer un match lorsqu'aucun évènement a eu lieu");

			MatchPlayerData currentPlayerData;
			MatchPlayerData opposingPlayerData;

			if (match.UserAId == userId)
			{
				currentPlayerData = match.PlayerDataA;
				opposingPlayerData = match.PlayerDataB;
			}
			else
			{
				currentPlayerData = match.PlayerDataB;
				opposingPlayerData = match.PlayerDataA;
			}

			var startMatchEvent = new StartMatchEvent(currentPlayerData, opposingPlayerData);
			string serializedEvent = match.AddEvent(startMatchEvent);
			
			await _context.SaveChangesAsync();

			return serializedEvent;
		}

		// Une fonction que le joueur qui attend son tour doit appeler fréquemment pour obtenir les json des évênements déclenchés par le joueur actif.
		// eventIndex doit être égal au eventIndex du match sur le client
		// (N'oubliez pas de mettre l'eventIndex à jour sur le client lorsque cette méthode retourne des évênements)
		public async Task<List<string>?> UpdateMatch(string userId, int matchId, int eventIndex)
		{
			Match? match = await _context.Matches.FindAsync(matchId);

			if (match == null)
				throw new Exception("Impossible de trouver le match");

			if (match.UserAId != userId && match.UserBId != userId)
				throw new Exception("Le joueur n'est pas dans ce match");

			if (match.EventIndex < eventIndex)
				throw new Exception("Le client a un eventIndex dans le future...");

			// Pas de nouveaux évènements, le client est déjà à jour
			if (match.EventIndex == eventIndex)
				return null;

			IEnumerable<SerializedMatchEvent> events = match.SerializedEvents.Where(e => e.Index >= eventIndex).OrderBy(e => e.Index);
			List<string> serializedEvents = new();
			foreach (SerializedMatchEvent e in events)
			{
				serializedEvents.Add(e.SerializedEvent);
			}

			return serializedEvents;
		}

			// Si l'id est zéro, le joueur passe simplement son tour
			// (N'oubliez pas de mettre le eventIndex du match sur le CLIENT à jour après avoir appelé cette méthode)
			public async Task<string> PlayCard(string userId, int matchId, int cardId)
		{
			// TODO: Implémenter la logique pour jouer une carte
			// N'oubliez pas de (entre autres):
			//   - Faire toutes les vérifications (Est-ce que ce user peut jouer cette carte)
			//   - Créer un PlayCardEvent pour déclencher la création de tous les évênements
			Match? match = await _context.Matches.FindAsync(matchId);
			Card card = await _context.Cards.FindAsync(cardId);
			PlayableCard playableCard = new PlayableCard(card);
			MatchPlayerData currentPlayerData;
			MatchPlayerData opposingPlayerData;

		   


			if (match == null)
			{
				throw new Exception("Aucun match n'est en cours donc impossible de jouer une carte");
			}

			if(match.IsMatchCompleted == true)
			{
				throw new Exception("Le match est terminer il est impossible de jouer une carte");
			}

			if (match.UserAId == userId)
			{
				currentPlayerData = match.PlayerDataA;
				opposingPlayerData = match.PlayerDataB;
			}
			else
			{
				currentPlayerData = match.PlayerDataB;
				opposingPlayerData = match.PlayerDataA;
			}

			if (currentPlayerData == null)
			{
				throw new Exception("L'utilisateur qui veut jouer n'est plus la");
			}

			if (currentPlayerData.Health == 0)
			{
				throw new Exception("Il n'y a acune carte a jouer");
			}

			if (currentPlayerData.Hand.Count == 0)
			{
				throw new Exception("Il n'y a acune carte a jouer");
			}

			if(playableCard == null)
			{
				throw new Exception("Aucune carte ne fut selectioner");
			}

			if(opposingPlayerData == null)
			{
				throw new Exception("Le jouer adverse n'est plus la");
			}
			if(currentPlayerData.Mana < card.ManaCost)
			{
				throw new Exception("Vous n'avez pas assez de mana pour joué cette carte.");
			}
			var playCardEvent = new PlayCardEvent(match, opposingPlayerData, currentPlayerData, playableCard);
			string serializedEvent = match.AddEvent(playCardEvent);

			await _context.SaveChangesAsync();

			return serializedEvent;
		}

		public async Task<string> EndTurn(string userId, int matchId)
		{
			Match? match = await _context.Matches.FindAsync(matchId);
			MatchPlayerData currentPlayerData;
			MatchPlayerData opposingPlayerData;

			if (match == null)
			{
				throw new Exception("Aucun match n'est en cours donc impossible de finir le tour.");
			}

			if (match.IsMatchCompleted == true)
			{
				throw new Exception("Le match est terminer il est impossible de finir le tour.");
			}

			if (match.UserAId == userId)
			{
				currentPlayerData = match.PlayerDataA;
				opposingPlayerData = match.PlayerDataB;
			}
			else
			{
				currentPlayerData = match.PlayerDataB;
				opposingPlayerData = match.PlayerDataA;
			}

			var EndturnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

			string serializedEvent = match.AddEvent(EndturnEvent);

			await _context.SaveChangesAsync();

			return serializedEvent;
		}

		public async Task<string> EndMatch(int matchId)
		{
			Match? match = await _context.Matches.FindAsync(matchId);
			match.IsMatchCompleted = true;
			_context.SaveChangesAsync();

			return "match finito";
		}
	}
}

