using Super_Cartes_Infinies.Combat;
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

            var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA.Id);

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
                Id = 1
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
            Assert.AreEqual(3, playableCardB.Health);

            // Les 2 cartes sont encore en vie et doivent rester sur le BattleField            
            Assert.AreEqual(1, currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, currentPlayerData.Graveyard.Count);
            Assert.AreEqual(1, opposingPlayerData.BattleField.Count);
            Assert.AreEqual(0, opposingPlayerData.Graveyard.Count);
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
                Id = 1
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
                Id = 1
            };

            currentPlayerData.BattleField.Add(playableCard);

            var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

            Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);
            Assert.AreEqual(0, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);
            Assert.AreEqual(true, match.IsMatchCompleted);
            Assert.AreEqual("UserAId", match.WinnerUserId);
        }
    }
}

