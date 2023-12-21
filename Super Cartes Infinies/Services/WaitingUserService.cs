namespace Super_Cartes_Infinies.Services
{
	public class UsersReadyForAMatch
	{
		public UsersReadyForAMatch(string userAId, string userBId)
		{
			this.UserAId = userAId;
			this.UserBId = userBId;
		}

		public string UserAId { get; set; }
		public string UserBId { get; set; }
	}

	public class WaitingUserService
	{
		private string? _waitingUserId = null;
		
		public WaitingUserService()
		{
		}

		// Retourne null si il n'y a pas déjà un user qui attend pour jouer
		// Si non, on retourne la paire de Users
		public UsersReadyForAMatch? LookForWaitingUser(string userId)
		{
			// Si c'est encore le même player qui attendait déjà, on retourne null
			if (_waitingUserId == userId)
				return null;

			// Aucun match en attente
			if (_waitingUserId == null)
			{
				_waitingUserId = userId;
				return null;
			}
			else
			{
				var matchCreationResult = new UsersReadyForAMatch(_waitingUserId, userId);
				_waitingUserId = null;
				return matchCreationResult;
			}
		}

		public void CancelQueue()
		{
			_waitingUserId = null;
		}
	}
}

