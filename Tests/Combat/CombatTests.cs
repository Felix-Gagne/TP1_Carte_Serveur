using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Tests.Services
{
	[TestClass]
	public class CombatTests
	{


        public CombatTests()
		{
            
        }

		[TestInitialize]
		public void Init()
		{
		}

		[TestCleanup]
		public void Dispose()
		{
		}

		[TestMethod]
		// Une invocation de Carte (NE FAIT PAS DE COMBAT)
		public void CardsDoNotAttackBeforePlayerTurnEvent()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};

			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 2,
				Defense = 3,
				ManaCost = 1
			};

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 5,
				ManaCost = 1
			};

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1
			};
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};

			currentPlayerData.Hand.Add(playableCardA);
			opposingPlayerData.BattleField.Add(playableCardB);

			var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA);

			Assert.AreEqual(currentPlayerData.PlayerId, playCardEvent.PlayerId);

			// Les 2 joueurs ne sont pas blessés
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);

			//Le mana à été utilisé
			Assert.AreEqual(1, currentPlayerData.Mana);

			Assert.AreEqual(3, playableCardA.Health);
			Assert.AreEqual(5, playableCardB.Health);

			// Les 2 cartes sont encore en vie et doivent rester sur le BattleField            
			Assert.AreEqual(1, currentPlayerData.BattleField.Count);
			Assert.AreEqual(0, currentPlayerData.Graveyard.Count);
			Assert.AreEqual(0, currentPlayerData.Hand.Count);
			Assert.AreEqual(1, opposingPlayerData.BattleField.Count);
			Assert.AreEqual(0, opposingPlayerData.Graveyard.Count);
		}

        [TestMethod]
        // Une invocation de Carte (NE FAIT PAS DE COMBAT)
        public void CardsHaveSummoningSickness()
        {
            var currentPlayerData = new MatchPlayerData(1)
            {
                Health = 1,
            };

            var opposingPlayerData = new MatchPlayerData(2)
            {
                Health = 1,
            };

            var match = new Match
            {
                UserAId = "UserAId",
                UserBId = "UserBId",
                PlayerDataA = currentPlayerData,
                PlayerDataB = opposingPlayerData
            };

            var cardA = new Card
            {
                Id = 42,
                Attack = 2,
                Defense = 3,
                ManaCost = 1
            };

            var cardB = new Card
            {
                Id = 43,
                Attack = 1,
                Defense = 5,
                ManaCost = 1
            };

            var playableCardA = new PlayableCard(cardA)
            {
                Id = 1
            };
            var playableCardB = new PlayableCard(cardB)
            {
                Id = 2
            };

            currentPlayerData.Hand.Add(playableCardA);
            opposingPlayerData.BattleField.Add(playableCardB);

            var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA);
            var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

            Assert.AreEqual(currentPlayerData.PlayerId, playCardEvent.PlayerId);
            Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

            // Les 2 joueurs ne sont pas blessés
            Assert.AreEqual(1, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);

            //Le mana à été utilisé
            Assert.AreEqual(1, currentPlayerData.Mana);

            Assert.AreEqual(3, playableCardA.Health);
            Assert.AreEqual(5, playableCardB.Health);

            // Les 2 cartes sont encore en vie et doivent rester sur le BattleField            
            Assert.AreEqual(1, currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, currentPlayerData.Graveyard.Count);
            Assert.AreEqual(0, currentPlayerData.Hand.Count);
            Assert.AreEqual(1, opposingPlayerData.BattleField.Count);
            Assert.AreEqual(0, opposingPlayerData.Graveyard.Count);
        }

        #region CombatSimpleTests

        [TestMethod]
		// Un combat simple entre 2 cartes qui recoivent des dégâts toutes les 2
		public void TurnWithBasicFightTest()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};

			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 2,
				Defense = 3
			};

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 5
			};

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1,
				SummonSickness = false
			};
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};

			currentPlayerData.BattleField.Add(playableCardA);
			opposingPlayerData.BattleField.Add(playableCardB);
			opposingPlayerData.CardsPile.Add(playableCardA);

			var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

			Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

			// Les 2 joueurs ne sont pas blessés
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);

			Assert.AreEqual(2, playableCardA.Health);
			Assert.AreEqual(3, playableCardB.Health);

			// Les 2 cartes sont encore en vie et doivent rester sur le BattleField            
			Assert.AreEqual(1, currentPlayerData.BattleField.Count);
			Assert.AreEqual(0, currentPlayerData.Graveyard.Count);
			Assert.AreEqual(1, opposingPlayerData.BattleField.Count);
			Assert.AreEqual(0, opposingPlayerData.Graveyard.Count);

			//Le joueur opposé pige sa carte.
			Assert.AreEqual(1, opposingPlayerData.Hand.Count);
		}


		[TestMethod]
		// Un combat entre 2 cartes qui recoivent des dégâts toutes les 2 et la carte de l'adversaire qui est tuée 
		public void TurnWithCardDeathTest()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};
			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 2,
				Defense = 3
			};

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 2
			};

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1,
                SummonSickness = false
            };
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};

			currentPlayerData.BattleField.Add(playableCardA);
			opposingPlayerData.BattleField.Add(playableCardB);

			var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

			Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

			// Les 2 joueurs ne sont pas blessés
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);

			Assert.AreEqual(2, playableCardA.Health);
			Assert.AreEqual(0, playableCardB.Health);

			// PlayableCardA est encore en vie et doivent rester sur le BattleField            
			Assert.AreEqual(1, currentPlayerData.BattleField.Count);
			Assert.AreEqual(0, currentPlayerData.Graveyard.Count);

			// Comme playableCardB n'a plus de Health, elle est morte et doit se retrouver dans le Graveyard
			Assert.AreEqual(0, opposingPlayerData.BattleField.Count);
			Assert.AreEqual(1, opposingPlayerData.Graveyard.Count);
		}

		[TestMethod]
		// Le joueur A fini son tour alors que son adversaire a seulement 1 point de vie
		// Lorsque le tour s'effectue, le joueur B perd son dernier point de vie et la victoire va au joueur A
		public void CombatAndKillPlayerTest()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};
			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var card = new Card
			{
				Id = 42,
				Attack = 1,
				Defense = 1
			};

			var playableCard = new PlayableCard(card)
			{
				Id = 1,
                SummonSickness = false
            };

			currentPlayerData.BattleField.Add(playableCard);

			var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

			Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);
			Assert.AreEqual(0, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);
			Assert.AreEqual(true, match.IsMatchCompleted);
			Assert.AreEqual("UserAId", match.WinnerUserId);
		}

		#endregion

		#region PlayingCardsTests

		[TestMethod]
		// Le joueur joue 2 cartes. Cela entraine le fait Qu'il y a 2 cartes sur le Battlefield du joueur A (PAS DE COMBAT)
		public void Plays2CardDuring1Turn()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};

			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 2,
				Defense = 3,
				ManaCost = 1
			};

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 5,
				ManaCost = 1
			};

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1
			};
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};

			currentPlayerData.Hand.Add(playableCardA);
			currentPlayerData.Hand.Add(playableCardB);

			var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA);
			var playCardEvent2 = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardB);

			Assert.AreEqual(currentPlayerData.PlayerId, playCardEvent.PlayerId);
			Assert.AreEqual(currentPlayerData.PlayerId, playCardEvent2.PlayerId);

			//Deux cartes dans le Battlefield du joueur A
			Assert.AreEqual(2, currentPlayerData.BattleField.Count);

			// Les 2 joueurs ne sont pas blessés
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);

			//Le mana à été utilisé
			Assert.AreEqual(0, currentPlayerData.Mana);

			//Aucune créature n'est blessées
			Assert.AreEqual(3, playableCardA.Health);
			Assert.AreEqual(5, playableCardB.Health);
		}

		[TestMethod]
		// Le joueur ne joue pas de cartes durant son tour.
		public void Plays0CardDuringTurn()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};

			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 2,
				Defense = 3,
				ManaCost = 1
			};

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 5,
				ManaCost = 1
			};

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1
			};
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};

			currentPlayerData.Hand.Add(playableCardA);
			currentPlayerData.Hand.Add(playableCardB);

			var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

			Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

			//Pas de carte dans les Battlefields, car personne n'a jouer de cartes.
			Assert.AreEqual(0, currentPlayerData.BattleField.Count);

			// Les 2 joueurs ne sont pas blessés
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);
		}

		[TestMethod]
		// Le joueur ne peut pas jouer de cartes s'il ne possède pas suffisament de Mana.
		public void PlayerCantPlayCardWithoutMana()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};
			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 2,
				Defense = 3,
				ManaCost = 1
			};

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 5,
				ManaCost = 1
			};

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1
			};
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};

			currentPlayerData.Hand.Add(playableCardA);
			opposingPlayerData.Hand.Add(playableCardB);

			var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA);
            var playCardEvent2 = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardB);

            Assert.AreEqual(currentPlayerData.PlayerId, playCardEvent.PlayerId);
            Assert.AreEqual(currentPlayerData.PlayerId, playCardEvent2.PlayerId);

            // Vérification du Mana du joueur A. 
            Assert.AreEqual(0, currentPlayerData.Mana);

			// Les 2 joueurs ne sont pas blessés
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);

			// Aucune Carte sur le BattleField ennemie et 2 monstres sur le currentplayer battlefield            
			Assert.AreEqual(2, currentPlayerData.BattleField.Count);
			Assert.AreEqual(0, opposingPlayerData.BattleField.Count);
		}

		#endregion


		#region PowerTests
		[TestMethod]
		// Test d'un combat de une carte avec First Strike contre une carte normale.
		public void AbilityFirstStrikeTest()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};
			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 18,
				Defense = 1,
				ManaCost = 2,
				cardPowers = new List<CardPower>()
			};

			var FirstStrike = new Power
			{
				Id = Power.FIRSTSTRIKE_ID,
				Name = "First Strike",
				Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
			};


			var cardPower = new CardPower
			{
				Id = 1,
				CardId = 42,
				PowerId = 2,
				value = 0
			};

			cardA.cardPowers.Add(cardPower);

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 1,
				ManaCost = 1
			};

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1,
				SummonSickness = false
			};
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};

			currentPlayerData.BattleField.Add(playableCardA);
			opposingPlayerData.BattleField.Add(playableCardB);

			var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

			Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

			// Test que la carte A possède le power First Strike.
			Assert.IsTrue(playableCardA.Card.HasPower(Power.FIRSTSTRIKE_ID));

			// Les 2 joueurs ne sont pas blessés
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);

			Assert.AreEqual(1, playableCardA.Health);
			Assert.AreEqual(0, playableCardB.Health);

			// PlayableCardA est encore en vie et doivent rester sur le BattleField            
			Assert.AreEqual(1, currentPlayerData.BattleField.Count);
			Assert.AreEqual(0, currentPlayerData.Graveyard.Count);

			// Comme playableCardB n'a plus de Health, elle est morte et doit se retrouver dans le Graveyard
			Assert.AreEqual(0, opposingPlayerData.BattleField.Count);
			Assert.AreEqual(1, opposingPlayerData.Graveyard.Count);
		}




        [TestMethod]
        // Test d'un combat de une carte avec First Strike contre une carte normale.
        public void AbilityFirstStrikeNoKillThenDiesTest()
        {
            var currentPlayerData = new MatchPlayerData(1)
            {
                Health = 1,
            };
            var opposingPlayerData = new MatchPlayerData(2)
            {
                Health = 1,
            };

            var match = new Match
            {
                UserAId = "UserAId",
                UserBId = "UserBId",
                PlayerDataA = currentPlayerData,
                PlayerDataB = opposingPlayerData
            };

            var cardA = new Card
            {
                Id = 42,
                Attack = 2,
                Defense = 1,
                ManaCost = 2,
                cardPowers = new List<CardPower>()
            };

            var FirstStrike = new Power
            {
                Id = Power.FIRSTSTRIKE_ID,
                Name = "First Strike",
                Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
            };


            var cardPower = new CardPower
            {
                Id = 1,
                CardId = 42,
                PowerId = 2,
                value = 0
            };

            cardA.cardPowers.Add(cardPower);

            var cardB = new Card
            {
                Id = 43,
                Attack = 1,
                Defense = 4,
                ManaCost = 1
            };

            var playableCardA = new PlayableCard(cardA)
            {
                Id = 1,
                SummonSickness = false
            };
            var playableCardB = new PlayableCard(cardB)
            {
                Id = 2
            };

            currentPlayerData.BattleField.Add(playableCardA);
            opposingPlayerData.BattleField.Add(playableCardB);

            var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

            Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

            // Test que la carte A possède le power First Strike.
            Assert.IsTrue(playableCardA.Card.HasPower(Power.FIRSTSTRIKE_ID));

            // Les 2 joueurs ne sont pas blessés
            Assert.AreEqual(1, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);

            Assert.AreEqual(0, playableCardA.Health);
            Assert.AreEqual(2, playableCardB.Health);

            // PlayableCardA est encore en vie et doivent rester sur le BattleField            
            Assert.AreEqual(0, currentPlayerData.BattleField.Count);
            Assert.AreEqual(1, currentPlayerData.Graveyard.Count);

            // Comme playableCardB n'a plus de Health, elle est morte et doit se retrouver dans le Graveyard
            Assert.AreEqual(1, opposingPlayerData.BattleField.Count);
            Assert.AreEqual(0, opposingPlayerData.Graveyard.Count);
        }

        [TestMethod]
		// Test d'un combat de une carte avec Charge contre une carte normale.
		public void AbilityChargeTest()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};

			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 5,
				Defense = 5,
				ManaCost = 1,
				cardPowers = new List<CardPower>()
			};

			var Charge = new Power
			{
				Id = Power.CHARGE_ID,
				Name = "Charge",
				Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
			};


			var cardPower = new CardPower
			{
				Id = 1,
				CardId = 42,
				PowerId = 1,
				value = 0
			};

			cardA.cardPowers.Add(cardPower);

			var cardB = new Card
			{
				Id = 43,
				Attack = 3,
				Defense = 5,
				ManaCost = 1
			};

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1,
				SummonSickness = true
			};
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};

			currentPlayerData.Hand.Add(playableCardA);
			opposingPlayerData.BattleField.Add(playableCardB);

			var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA);
			var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

			Assert.AreEqual(currentPlayerData.PlayerId, playCardEvent.PlayerId);
			Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

			// Test que la carte A possède le power Charge.
			Assert.IsTrue(playableCardA.Card.HasPower(Power.CHARGE_ID));

			// Les 2 joueurs ne sont pas blessés
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);

			//Le mana à été utilisé
			Assert.AreEqual(1, currentPlayerData.Mana);

			Assert.AreEqual(2, playableCardA.Health);
			Assert.AreEqual(0, playableCardB.Health);

			// La carte ennemi est morte et doit aller au Graveyard            
			Assert.AreEqual(1, currentPlayerData.BattleField.Count);
			Assert.AreEqual(0, currentPlayerData.Graveyard.Count);
			Assert.AreEqual(0, currentPlayerData.Hand.Count);
			Assert.AreEqual(0, opposingPlayerData.BattleField.Count);
			Assert.AreEqual(1, opposingPlayerData.Graveyard.Count);
		}
        #endregion

        #region ThornTests

        [TestMethod]
		//Test d'un combat de une carte avec Thorns 1 contre une carte normale
		public void AbilityThorn1Test()
		{

			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};

			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 5,
				Defense = 1,
				ManaCost = 2
			};

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 1,
				ManaCost = 1,
				cardPowers = new List<CardPower>()
			};

			var Thorns = new Power
			{
				Id = Power.THORNS_ID,
				Name = "Thorns 1",
				Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
			};


			var cardPower = new CardPower
			{
				Id = 1,
				CardId = 43,
				PowerId = 3,
				value = 1
			};

			cardB.cardPowers.Add(cardPower);

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1,
                SummonSickness = false
            };
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};

			currentPlayerData.BattleField.Add(playableCardA);
			opposingPlayerData.BattleField.Add(playableCardB);

			var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

			Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

			// Test que la carte A possède le power Thorns.
			Assert.IsTrue(playableCardB.Card.HasPower(Power.THORNS_ID));
			// Vérifie si la value du power est de 1.
			Assert.AreEqual(1, playableCardB.Card.GetPowerValue(Power.THORNS_ID));

			// Les 2 joueurs ne sont pas blessés
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);


			// La carte B n'a pas recu de dommages.
			Assert.AreEqual(1, playableCardB.Health);

			// La carte du currentplayer est morte et doit aller au Graveyard            
			Assert.AreEqual(0, currentPlayerData.BattleField.Count);
			Assert.AreEqual(1, currentPlayerData.Graveyard.Count);
			Assert.AreEqual(1, opposingPlayerData.BattleField.Count);
			Assert.AreEqual(0, opposingPlayerData.Graveyard.Count);
		}

		[TestMethod]
		//Test d'un combat de une carte avec Thorns 5 contre une carte normale
		public void AbilityThorn5Test()
		{

			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};

			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 9,
				Defense = 6,
				ManaCost = 5
			};

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 1,
				ManaCost = 4,
				cardPowers = new List<CardPower>()
			};

			var Thorns = new Power
			{
				Id = Power.THORNS_ID,
				Name = "Thorns 5",
				Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
			};


			var cardPower = new CardPower
			{
				Id = 1,
				CardId = 43,
				PowerId = 3,
				value = 5
			};

			cardB.cardPowers.Add(cardPower);

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1,
                SummonSickness = false
            };
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};

			currentPlayerData.BattleField.Add(playableCardA);
			opposingPlayerData.BattleField.Add(playableCardB);

			var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

			Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

			// Test que la carte A possède le power Thorns.
			Assert.IsTrue(playableCardB.Card.HasPower(Power.THORNS_ID));
			// Vérifie si la value du power est de 5.
			Assert.AreEqual(5, playableCardB.Card.GetPowerValue(Power.THORNS_ID));

			// Les 2 joueurs ne sont pas blessés
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);

			//La carte qui attaque a 1 health
			Assert.AreEqual(1, playableCardA.Health);

			// La carte ennemi est morte et doit aller au Graveyard            
			Assert.AreEqual(1, currentPlayerData.BattleField.Count);
			Assert.AreEqual(0, currentPlayerData.Graveyard.Count);
			Assert.AreEqual(0, opposingPlayerData.BattleField.Count);
			Assert.AreEqual(1, opposingPlayerData.Graveyard.Count);
		}
		#endregion

		#region HealTests

		[TestMethod]
		public void AbilityHeal1Test()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};

			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 2,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 5,
				Defense = 2,
				ManaCost = 2,
				cardPowers = new List<CardPower>()
			};

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 9,
				ManaCost = 1
			};

			var cardC = new Card
			{
				Id = 44,
				Attack = 1,
				Defense = 7,
				ManaCost = 1
			};

			var Heal = new Power
			{
				Id = Power.HEAL_ID,
				Name = "Heal 1",
				Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
			};


			var cardPower = new CardPower
			{
				Id = 1,
				CardId = 42,
				PowerId = 4,
				value = 1
			};

			cardA.cardPowers.Add(cardPower);

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1,
                SummonSickness = false
            };
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2,
            };
			var playableCardC = new PlayableCard(cardC)
			{
				Id = 2,
				Health = 5,
                SummonSickness = false
            };

			currentPlayerData.BattleField.Add(playableCardA);
			opposingPlayerData.BattleField.Add(playableCardB);
			currentPlayerData.BattleField.Add(playableCardC);

			var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

			Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

			// Test que la carte A possède le power Heal.
			Assert.IsTrue(playableCardA.Card.HasPower(Power.HEAL_ID));
			// Vérifie si la value du power est de 1.
			Assert.AreEqual(1, playableCardA.Card.GetPowerValue(Power.HEAL_ID));

			// Le joueur ennemie a recu un dommage
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);


			// La carte ennemie ne se fait pas Heal.
			Assert.AreEqual(4, playableCardB.Health);

			// La carte A c'est Heal de 1, Mais a reçu 1 damage après son Heal.
			Assert.AreEqual(1, playableCardA.Health);

			// La carte C c'est Heal de 1.
			Assert.AreEqual(6, playableCardC.Health);

			// Rien meurt.           
			Assert.AreEqual(2, currentPlayerData.BattleField.Count);
			Assert.AreEqual(0, currentPlayerData.Graveyard.Count);
			Assert.AreEqual(1, opposingPlayerData.BattleField.Count);
			Assert.AreEqual(0, opposingPlayerData.Graveyard.Count);
		}


		[TestMethod]
		public void AbilityHeal2Test()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};

			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 2,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 5,
				Defense = 2,
				ManaCost = 2,
				cardPowers = new List<CardPower>()
			};

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 9,
				ManaCost = 1
			};

			var cardC = new Card
			{
				Id = 44,
				Attack = 1,
				Defense = 7,
				ManaCost = 1
			};

			var Heal = new Power
			{
				Id = Power.HEAL_ID,
				Name = "Heal 2",
				Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
			};


			var cardPower = new CardPower
			{
				Id = 1,
				CardId = 42,
				PowerId = 4,
				value = 2
			};

			cardA.cardPowers.Add(cardPower);

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1,
                SummonSickness = false
            };
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};
			var playableCardC = new PlayableCard(cardC)
			{
				Id = 2,
				Health = 6,
                SummonSickness = false
            };

			currentPlayerData.BattleField.Add(playableCardA);
			opposingPlayerData.BattleField.Add(playableCardB);
			currentPlayerData.BattleField.Add(playableCardC);

			var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

			Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

			// Test que la carte A possède le power Heal.
			Assert.IsTrue(playableCardA.Card.HasPower(Power.HEAL_ID));
			// Vérifie si la value du power est de 2.
			Assert.AreEqual(2, playableCardA.Card.GetPowerValue(Power.HEAL_ID));

            // Le joueur ennemie a recu un dommage
            Assert.AreEqual(1, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);


            // Les cartes se sont fait Heal.
            Assert.AreEqual(4, playableCardB.Health);

			// La carte A c'est Heal de 2, Mais a reçu 1 damage après son Heal.
			Assert.AreEqual(1, playableCardA.Health);

			// La carte C c'est Heal de 2. laissant sa vie au maximum qui est 7.
			Assert.AreEqual(7, playableCardC.Health);

			// Rien meurt.           
			Assert.AreEqual(2, currentPlayerData.BattleField.Count);
			Assert.AreEqual(0, currentPlayerData.Graveyard.Count);
			Assert.AreEqual(1, opposingPlayerData.BattleField.Count);
			Assert.AreEqual(0, opposingPlayerData.Graveyard.Count);
		}

        #endregion

        #region ExplosionTest
        [TestMethod]
        public void AbilityExplosionTest()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};
			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 2,
				Defense = 3,
				ManaCost = 1
			};

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 3,
				ManaCost = 1
			};

			var cardC = new Card
			{
				Id = 44,
				Attack = 7,
				Defense = 7,
				ManaCost = 1
			};

			var cardD = new Card
			{
				Id = 45,
				Attack = 1,
				Defense = 6,
				ManaCost = 1,
                cardPowers = new List<CardPower>()
            };

			var Explosion = new Power
			{
				Id = Power.EXPLOSION_ID,
				Name = "Explosion",
				Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
			};


			var cardPower = new CardPower
			{
				Id = 1,
				CardId = 45,
				PowerId = Power.EXPLOSION_ID,
				value = 0
			};

			cardD.cardPowers.Add(cardPower);

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1,
                SummonSickness = false
            };
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};
			var playableCardC = new PlayableCard(cardC)
			{
				Id = 3,
                SummonSickness = false
            };
			var playableCardD = new PlayableCard(cardD)
			{
				Id = 4
			};

			currentPlayerData.BattleField.Add(playableCardA);
			opposingPlayerData.BattleField.Add(playableCardB);
			currentPlayerData.BattleField.Add(playableCardC);
			opposingPlayerData.BattleField.Add(playableCardD);

			var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

			Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

			// Test que la carte A possède le power Charge.
			Assert.IsTrue(playableCardD.Card.HasPower(Power.EXPLOSION_ID));

			// Les 2 joueurs ne sont pas blessés
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);

			Assert.AreEqual(0, playableCardA.Health);
			Assert.AreEqual(0, playableCardB.Health);
            Assert.AreEqual(1, playableCardC.Health);
            Assert.AreEqual(0, playableCardD.Health);

            // Explosion fait 5 damage a tout les monstres donc un monstre de currentPlayer est mort.           
            Assert.AreEqual(1, currentPlayerData.BattleField.Count);
			Assert.AreEqual(1, currentPlayerData.Graveyard.Count);

			// Comme playableCardB n'a plus de Health, elle est morte et doit se retrouver dans le Graveyard (Activant son ability)
			// Cela tue tout les monstres de opposingPlayer
			Assert.AreEqual(0, opposingPlayerData.BattleField.Count);
			Assert.AreEqual(2, opposingPlayerData.Graveyard.Count);
		}

        [TestMethod]
        public void AbilityDoubleExplosionTest()
        {
            var currentPlayerData = new MatchPlayerData(1)
            {
                Health = 1,
            };
            var opposingPlayerData = new MatchPlayerData(2)
            {
                Health = 1,
            };

            var match = new Match
            {
                UserAId = "UserAId",
                UserBId = "UserBId",
                PlayerDataA = currentPlayerData,
                PlayerDataB = opposingPlayerData
            };

            var cardA = new Card
            {
                Id = 42,
                Attack = 2,
                Defense = 7,
                ManaCost = 1
            };

            var cardB = new Card
            {
                Id = 43,
                Attack = 1,
                Defense = 4,
                ManaCost = 1,
                cardPowers = new List<CardPower>()
            };

            var cardC = new Card
            {
                Id = 44,
                Attack = 7,
                Defense = 10,
                ManaCost = 1
            };

            var cardD = new Card
            {
                Id = 45,
                Attack = 1,
                Defense = 6,
                ManaCost = 1,
                cardPowers = new List<CardPower>()
            };

            var cardE = new Card
            {
                Id = 44,
                Attack = 1,
                Defense = 1,
                ManaCost = 1
            };

            var Explosion = new Power
            {
                Id = Power.EXPLOSION_ID,
                Name = "Explosion",
                Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
            };


            var cardPower = new CardPower
            {
                Id = 1,
                CardId = 45,
                PowerId = Power.EXPLOSION_ID,
                value = 0
            };

            var cardPower2 = new CardPower
            {
                Id = 2,
                CardId = 43,
                PowerId = Power.EXPLOSION_ID,
                value = 0
            };

            cardD.cardPowers.Add(cardPower);
			cardB.cardPowers.Add(cardPower2);

            var playableCardA = new PlayableCard(cardA)
            {
                Id = 1,
                SummonSickness = false
            };
            var playableCardB = new PlayableCard(cardB)
            {
                Id = 2
            };
            var playableCardC = new PlayableCard(cardC)
            {
                Id = 3,
                SummonSickness = false
            };
            var playableCardD = new PlayableCard(cardD)
            {
                Id = 4
            };
			var playableCardE = new PlayableCard(cardE)
			{
				Id = 5,
			};

            currentPlayerData.BattleField.Add(playableCardA);
            opposingPlayerData.BattleField.Add(playableCardB);
            currentPlayerData.BattleField.Add(playableCardC);
            opposingPlayerData.BattleField.Add(playableCardD);
            opposingPlayerData.BattleField.Add(playableCardE);
            currentPlayerData.BattleField.Add(playableCardE);


            var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

            Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

            // Test que la carte D possède le power Explosion.
            Assert.IsTrue(playableCardD.Card.HasPower(Power.EXPLOSION_ID));

            // Test que la carte B possède le power Explosion.
            Assert.IsTrue(playableCardB.Card.HasPower(Power.EXPLOSION_ID));

            // Les 2 joueurs ne sont pas blessés
            Assert.AreEqual(1, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);

			// Tout les monstres sont morts
            Assert.AreEqual(0, playableCardA.Health);
            Assert.AreEqual(0, playableCardB.Health);
            Assert.AreEqual(0, playableCardC.Health);
            Assert.AreEqual(0, playableCardD.Health);

            // Explosion fait 5 damage a tout les monstres donc ils sont tous morts. Car il y a eu 2 EXPLOSION      
            Assert.AreEqual(0, currentPlayerData.BattleField.Count);
            Assert.AreEqual(3, currentPlayerData.Graveyard.Count);

            // Comme playableCardB n'a plus de Health, elle est morte et doit se retrouver dans le Graveyard (Activant son ability)
            // Cela tue tout les monstres de opposingPlayer
            Assert.AreEqual(0, opposingPlayerData.BattleField.Count);
            Assert.AreEqual(3, opposingPlayerData.Graveyard.Count);
        }

        #endregion

        #region GreedTest
        [TestMethod]
        public void AbilityGreedTest()
		{
			var currentPlayerData = new MatchPlayerData(1)
			{
				Health = 1,
			};

			var opposingPlayerData = new MatchPlayerData(2)
			{
				Health = 1,
			};

			var match = new Match
			{
				UserAId = "UserAId",
				UserBId = "UserBId",
				PlayerDataA = currentPlayerData,
				PlayerDataB = opposingPlayerData
			};

			var cardA = new Card
			{
				Id = 42,
				Attack = 2,
				Defense = 3,
				ManaCost = 2,
				cardPowers = new List<CardPower>()
			};

			var cardB = new Card
			{
				Id = 43,
				Attack = 1,
				Defense = 5,
				ManaCost = 1
			};

			var Greed = new Power
			{
				Id = Power.GREED_ID,
				Name = "Greed",
				Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
			};


			var cardPower = new CardPower
			{
				Id = 1,
				CardId = 42,
				PowerId = Power.GREED_ID,
				value = 0
			};

			cardA.cardPowers.Add(cardPower);

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1
			};
			var playableCardB = new PlayableCard(cardB)
			{
				Id = 2
			};

			currentPlayerData.Hand.Add(playableCardA);
			opposingPlayerData.BattleField.Add(playableCardB);
            currentPlayerData.CardsPile.Add(playableCardB);
            currentPlayerData.CardsPile.Add(playableCardA);

            var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA);

			Assert.AreEqual(currentPlayerData.PlayerId, playCardEvent.PlayerId);

			// Test que la carte A possède le power Greed.
			Assert.IsTrue(playableCardA.Card.HasPower(Power.GREED_ID));

			// Les 2 joueurs ne sont pas blessés
			Assert.AreEqual(1, opposingPlayerData.Health);
			Assert.AreEqual(1, currentPlayerData.Health);

			//Le mana à été utilisé et reobtenu avec le ability Greed
			Assert.AreEqual(3, currentPlayerData.Mana);

			Assert.AreEqual(3, playableCardA.Health);
			Assert.AreEqual(5, playableCardB.Health);

			// Les 2 cartes sont encore en vie et doivent rester sur le BattleField
			// En plus le currentPlayer doit avoir recu 2 cartes de plus a sa main grace a Greed
			Assert.AreEqual(1, currentPlayerData.BattleField.Count);
			Assert.AreEqual(2, currentPlayerData.Hand.Count);
			Assert.AreEqual(0, currentPlayerData.CardsPile.Count);
			Assert.AreEqual(1, opposingPlayerData.BattleField.Count);
		}

		#endregion

		#region PoisonTest
		[TestMethod]
        public void PoisonTest()
        {
            var currentPlayerData = new MatchPlayerData(1)
            {
                Health = 1,
            };

            var opposingPlayerData = new MatchPlayerData(2)
            {
                Health = 1,
            };

            var match = new Match
            {
                UserAId = "UserAId",
                UserBId = "UserBId",
                PlayerDataA = currentPlayerData,
                PlayerDataB = opposingPlayerData
            };

            var cardA = new Card
            {
                Id = 42,
                Attack = 5,
                Defense = 5,
                ManaCost = 1,
                cardPowers = new List<CardPower>()
            };

            var poison = new Power
            {
                Id = Power.POISON_ID,
                Name = "Poison",
                Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
            };


            var poisonedPower = new CardPower
            {
                Id = 1,
                CardId = 42,
                PowerId = poison.Id,
                value = 1
            };

            cardA.cardPowers.Add(poisonedPower);

            var cardB = new Card
            {
                Id = 43,
                Attack = 3,
                Defense = 20,
                ManaCost = 1
            };

            var playableCardA = new PlayableCard(cardA)
            {
                Id = 1,
                SummonSickness = false
            };
            var playableCardB = new PlayableCard(cardB)
            {
                Id = 2
            };

            currentPlayerData.BattleField.Add(playableCardA);
            opposingPlayerData.BattleField.Add(playableCardB);

            var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

            Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

			Assert.IsTrue(playableCardA.Card.HasPower(Power.POISON_ID));
			Assert.IsTrue(playableCardB.Poisoned);

			Assert.AreEqual(playableCardB.Health, 14);

			match.IsPlayerATurn = true;
            var EndTurnEvent2 = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

            Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent2.PlayerId);
            Assert.IsTrue(playableCardB.Poisoned);
            Assert.AreEqual(playableCardB.Health, 7);

        }
        #endregion

        #region Stunned

        [TestMethod]
        public void StunTest()
        {
            var currentPlayerData = new MatchPlayerData(1)
            {
                Health = 1,
            };

            var opposingPlayerData = new MatchPlayerData(2)
            {
                Health = 1,
            };

            var match = new Match
            {
                UserAId = "UserAId",
                UserBId = "UserBId",
                PlayerDataA = currentPlayerData,
                PlayerDataB = opposingPlayerData
            };

            var cardA = new Card
            {
                Id = 42,
                Attack = 5,
                Defense = 5,
                ManaCost = 1,
                cardPowers = new List<CardPower>()
            };

            var stun = new Power
            {
                Id = Power.STUN_ID,
                Name = "Stun",
                Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
            };


            var stunedPower = new CardPower
            {
                Id = 1,
                CardId = 42,
                PowerId = stun.Id,
                value = 2
            };

            cardA.cardPowers.Add(stunedPower);

            var cardB = new Card
            {
                Id = 43,
                Attack = 3,
                Defense = 20,
                ManaCost = 1
            };

			var playableCardA = new PlayableCard(cardA)
			{
				Id = 1,
				SummonSickness = false,
				
            };
            var playableCardB = new PlayableCard(cardB)
            {
                Id = 2,
				SummonSickness = false,
                Poisoned = true,
                PoisonedLevel = 1,
            };

            currentPlayerData.BattleField.Add(playableCardA);
            opposingPlayerData.BattleField.Add(playableCardB);

            var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

            Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

            Assert.IsTrue(playableCardA.Card.HasPower(Power.STUN_ID));
			//L'effet stun s'applique
            Assert.IsTrue(playableCardB.Stuned);
			//La carte ce fait bien attaquer et perds hp de l attaque et du poison
            Assert.AreEqual(playableCardB.Health, 14);
            //Verification que la carte a prend des degats
            Assert.AreEqual(playableCardA.Health, 2);

            var EndTurnEvent2 = new PlayerTurnEvent(match, opposingPlayerData, currentPlayerData);

			Assert.AreEqual(opposingPlayerData.PlayerId, EndTurnEvent2.PlayerId);
			//Carte toujours stun
			Assert.IsTrue(playableCardB.Stuned);
			//Compteur Carte B qui descend
			Assert.AreEqual(playableCardB.StunTurnLeft, 1);
            //Verification que la carte a possede encore les meme hp
            Assert.AreEqual(playableCardA.Health, 2);
			//Hp carte B apres effet poison
            Assert.AreEqual(playableCardB.Health, 13);
        }

        #endregion

        #region EarthQuake

        [TestMethod]
        public void EarthQuakeTest()
        {
            var currentPlayerData = new MatchPlayerData(1)
            {
                Health = 1,
            };
            var opposingPlayerData = new MatchPlayerData(2)
            {
                Health = 1,
            };

            var match = new Match
            {
                UserAId = "UserAId",
                UserBId = "UserBId",
                PlayerDataA = currentPlayerData,
                PlayerDataB = opposingPlayerData
            };

            var cardA = new Card
            {
                Id = 42,
                Attack = 2,
                Defense = 3,
                ManaCost = 1
            };

            var cardB = new Card
            {
                Id = 43,
                Attack = 1,
                Defense = 3,
                ManaCost = 1
            };

            var cardC = new Card
            {
                Id = 44,
                Attack = 7,
                Defense = 7,
                ManaCost = 1
            };

            var cardD = new Card
            {
                Id = 45,
                Attack = 1,
                Defense = 6,
                ManaCost = 1,
                cardPowers = new List<CardPower>()
            };

            var EarthQuake = new Power
            {
                Id = Power.EARTHQUAKE_ID,
                Name = "EarthQuake",
                Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
            };


            var cardPower = new CardPower
            {
                Id = 1,
                CardId = 45,
                PowerId = Power.EARTHQUAKE_ID,
                value = 5
            };

            cardD.cardPowers.Add(cardPower);

            var playableCardA = new PlayableCard(cardA)
            {
                Id = 1,
                SummonSickness = false
            };
            var playableCardB = new PlayableCard(cardB)
            {
                Id = 2
            };
            var playableCardC = new PlayableCard(cardC)
            {
                Id = 3,
                SummonSickness = false
            };
            var playableCardD = new PlayableCard(cardD)
            {
                Id = 4,
            };

            currentPlayerData.BattleField.Add(playableCardA);
            opposingPlayerData.BattleField.Add(playableCardB);
            currentPlayerData.BattleField.Add(playableCardC);
			opposingPlayerData.Hand.Add(playableCardD);
			var playCard = new PlayCardEvent(match, opposingPlayerData, currentPlayerData, playableCardD);
            var palyCardEvent = new PlayerTurnEvent(match, opposingPlayerData, currentPlayerData);

            Assert.AreEqual(opposingPlayerData.PlayerId, palyCardEvent.PlayerId);

            // Test que la carte A possède le power Charge.
            Assert.IsTrue(playableCardD.Card.HasPower(Power.EARTHQUAKE_ID));
			//S'assurer que la carte a bien ete jouer
            Assert.IsTrue(playableCardD.QuickPlayCard);
            // Les 2 joueurs ne sont pas blessés
            Assert.AreEqual(1, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);

            Assert.AreEqual(0, playableCardA.Health);
            Assert.AreEqual(0, playableCardB.Health);
            Assert.AreEqual(2, playableCardC.Health);
            Assert.AreEqual(0, playableCardD.Health);

            // Explosion fait 5 damage a tout les monstres donc un monstre de currentPlayer est mort.           
            Assert.AreEqual(1, currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, opposingPlayerData.BattleField.Count);
            Assert.AreEqual(1, currentPlayerData.Graveyard.Count);
            Assert.AreEqual(2, opposingPlayerData.Graveyard.Count);
        }

        #endregion

        #region LightingAttack

        [TestMethod]
        public void LightingAttackTest()
        {
            var currentPlayerData = new MatchPlayerData(1)
            {
                Health = 1,
            };
            var opposingPlayerData = new MatchPlayerData(2)
            {
                Health = 1,
            };

			

            var match = new Match
            {
                UserAId = "UserAId",
                UserBId = "UserBId",
                PlayerDataA = currentPlayerData,
                PlayerDataB = opposingPlayerData
            };


			Player player1 = new Player() { IdentityUserId = match.UserAId };
			Player player2 = new Player() { IdentityUserId = match.UserBId };



            var cardA = new Card
            {
                Id = 42,
                Attack = 2,
                Defense = 3,
                ManaCost = 1,
				cardPowers = new List<CardPower>()
            };

            var cardB = new Card
            {
                Id = 43,
                Attack = 1,
                Defense = 3,
                ManaCost = 1
            };

           

            var LightingStrike = new Power
            {
                Id = Power.LIGHTINGSTRIKE_ID,
                Name = "EarthQuake",
                Icon = "https://static.vecteezy.com/system/resources/previews/005/455/799/original/casual-game-power-icon-isolated-golden-symbol-gui-ui-for-web-or-app-interface-element-vector.jpg"
            };


            var cardPower = new CardPower
            {
                Id = 1,
                CardId = 42,
                PowerId = Power.LIGHTINGSTRIKE_ID,
                value = 5
            };

            cardA.cardPowers.Add(cardPower);

            var playableCardA = new PlayableCard(cardA)
            {
                Id = 1,
                SummonSickness = false
            };
            var playableCardB = new PlayableCard(cardB)
            {
                Id = 2
            };


			currentPlayerData.Player = player1;
            opposingPlayerData.Player = player2;


            opposingPlayerData.BattleField.Add(playableCardB);
			currentPlayerData.Hand.Add(playableCardA);

            var playCard = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA);
            var palyCardEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

            Assert.AreEqual(currentPlayerData.PlayerId, palyCardEvent.PlayerId);
            Assert.AreEqual(0, currentPlayerData.Hand.Count);
            Assert.IsTrue(playableCardA.QuickPlayCard);

			Assert.AreEqual(0, playableCardA.Health);
			Assert.AreEqual(3, playableCardB.Health);

			Assert.AreEqual(0, currentPlayerData.BattleField.Count);
			Assert.AreEqual(1, currentPlayerData.Graveyard.Count);

			Assert.AreEqual(1, opposingPlayerData.BattleField.Count);

			Assert.AreEqual(0, opposingPlayerData.Health);
			Assert.AreEqual(match.WinnerUserId, match.UserAId);

			Assert.IsTrue(match.IsMatchCompleted);
        }

        #endregion
    }
}