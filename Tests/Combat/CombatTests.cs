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

            var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA.Id);
            var playCardEvent2 = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardB.Id);

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

            var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA.Id);

            Assert.AreEqual(currentPlayerData.PlayerId, playCardEvent.PlayerId);

            // Vérification du Mana du joueur A. 
            Assert.AreEqual(0, currentPlayerData.Mana);

            // Les 2 joueurs ne sont pas blessés
            Assert.AreEqual(1, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);

            // Aucune Carte sur le BattleField            
            Assert.AreEqual(0, currentPlayerData.BattleField.Count);
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
                ManaCost = 1
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
                Id = 1
            };
            var playableCardB = new PlayableCard(cardB)
            {
                Id = 2
            };

            currentPlayerData.Hand.Add(playableCardA);
            opposingPlayerData.BattleField.Add(playableCardB);

            var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA.Id);
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

            Assert.AreEqual(3, playableCardA.Health);
            Assert.AreEqual(5, playableCardB.Health);

            // La carte ennemi est morte et doit aller au Graveyard            
            Assert.AreEqual(1, currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, currentPlayerData.Graveyard.Count);
            Assert.AreEqual(0, currentPlayerData.Hand.Count);
            Assert.AreEqual(0, opposingPlayerData.BattleField.Count);
            Assert.AreEqual(1, opposingPlayerData.Graveyard.Count);
        }

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
                ManaCost = 1
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

            // Test que la carte A possède le power Thorns.
            Assert.IsTrue(playableCardB.Card.HasPower(Power.THORNS_ID));
            // Vérifie si la value du power est de 1.
            Assert.AreEqual(1, playableCardB.Card.GetPowerValue(Power.THORNS_ID));

            // Les 2 joueurs ne sont pas blessés
            Assert.AreEqual(1, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);


            // La carte B n'a pas recu de dommages.
            Assert.AreEqual(1, playableCardB.Health);

            // La carte ennemi est morte et doit aller au Graveyard            
            Assert.AreEqual(1, currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, currentPlayerData.Graveyard.Count);
            Assert.AreEqual(0, opposingPlayerData.BattleField.Count);
            Assert.AreEqual(1, opposingPlayerData.Graveyard.Count);
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
                Defense = 5,
                ManaCost = 5
            };

            var cardB = new Card
            {
                Id = 43,
                Attack = 1,
                Defense = 1,
                ManaCost = 4
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

            // Test que la carte A possède le power Thorns.
            Assert.IsTrue(playableCardB.Card.HasPower(Power.THORNS_ID));
            // Vérifie si la value du power est de 5.
            Assert.AreEqual(5, playableCardB.Card.GetPowerValue(Power.THORNS_ID));

            // Les 2 joueurs ne sont pas blessés
            Assert.AreEqual(1, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);


            // La carte B n'a pas recu de dommages.
            Assert.AreEqual(1, playableCardB.Health);

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
                Defense = 2,
                ManaCost = 2
            };

            var cardB = new Card
            {
                Id = 43,
                Attack = 1,
                Defense = 99,
                ManaCost = 1
            };

            var cardC = new Card
            {
                Id = 43,
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
                CardId = 43,
                PowerId = 4,
                value = 1
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
            var playableCardC = new PlayableCard(cardC)
            {
                Id = 2,
                Health = 5
            };

            currentPlayerData.BattleField.Add(playableCardA);
            opposingPlayerData.BattleField.Add(playableCardB);
            currentPlayerData.BattleField.Add(playableCardC);

            var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA.Id);
            var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

            Assert.AreEqual(currentPlayerData.PlayerId, playCardEvent.PlayerId);
            Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

            // Test que la carte A possède le power Heal.
            Assert.IsTrue(playableCardB.Card.HasPower(Power.HEAL_ID));
            // Vérifie si la value du power est de 1.
            Assert.AreEqual(1, playableCardB.Card.GetPowerValue(Power.HEAL_ID));

            // Les 2 joueurs ne sont pas blessés
            Assert.AreEqual(1, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);


            // Les cartes se sont fait Heal.
            Assert.AreEqual(99, playableCardB.Health);

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
                Defense = 2,
                ManaCost = 2
            };

            var cardB = new Card
            {
                Id = 43,
                Attack = 1,
                Defense = 99,
                ManaCost = 1
            };

            var cardC = new Card
            {
                Id = 43,
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
                CardId = 43,
                PowerId = 4,
                value = 2
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
            var playableCardC = new PlayableCard(cardC)
            {
                Id = 2,
                Health = 5
            };

            currentPlayerData.BattleField.Add(playableCardA);
            opposingPlayerData.BattleField.Add(playableCardB);
            currentPlayerData.BattleField.Add(playableCardC);

            var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA.Id);
            var EndTurnEvent = new PlayerTurnEvent(match, currentPlayerData, opposingPlayerData);

            Assert.AreEqual(currentPlayerData.PlayerId, playCardEvent.PlayerId);
            Assert.AreEqual(currentPlayerData.PlayerId, EndTurnEvent.PlayerId);

            // Test que la carte A possède le power Heal.
            Assert.IsTrue(playableCardB.Card.HasPower(Power.HEAL_ID));
            // Vérifie si la value du power est de 2.
            Assert.AreEqual(1, playableCardB.Card.GetPowerValue(Power.HEAL_ID));

            // Les 2 joueurs ne sont pas blessés
            Assert.AreEqual(1, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);


            // Les cartes se sont fait Heal.
            Assert.AreEqual(99, playableCardB.Health);

            // La carte A c'est Heal de 1, Mais a reçu 1 damage après son Heal.
            Assert.AreEqual(1, playableCardA.Health);

            // La carte C c'est Heal de 1.
            Assert.AreEqual(7, playableCardC.Health);

            // Rien meurt.           
            Assert.AreEqual(2, currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, currentPlayerData.Graveyard.Count);
            Assert.AreEqual(1, opposingPlayerData.BattleField.Count);
            Assert.AreEqual(0, opposingPlayerData.Graveyard.Count);
        }

        #endregion

        #region ExplosionTest

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
                Defense = 2,
                ManaCost = 1
            };

            var cardC = new Card
            {
                Id = 44,
                Attack = 2,
                Defense = 5,
                ManaCost = 1
            };

            var cardD = new Card
            {
                Id = 45,
                Attack = 1,
                Defense = 6,
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
                CardId = 43,
                PowerId = Power.EXPLOSION_ID,
                value = 0
            };

            cardB.cardPowers.Add(cardPower);

            var playableCardA = new PlayableCard(cardA)
            {
                Id = 1
            };
            var playableCardB = new PlayableCard(cardB)
            {
                Id = 2
            };
            var playableCardC = new PlayableCard(cardC)
            {
                Id = 3
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
            Assert.IsTrue(playableCardB.Card.HasPower(Power.EXPLOSION_ID));

            // Les 2 joueurs ne sont pas blessés
            Assert.AreEqual(1, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);

            Assert.AreEqual(2, playableCardA.Health);
            Assert.AreEqual(0, playableCardB.Health);

            // Explosion fait 5 damage a tout les monstres donc les deux monstres de currentPlayer sont morts.           
            Assert.AreEqual(0, currentPlayerData.BattleField.Count);
            Assert.AreEqual(2, currentPlayerData.Graveyard.Count);

            // Comme playableCardB n'a plus de Health, elle est morte et doit se retrouver dans le Graveyard (Activant son ability)
            // Vu que playableCardD a plus que 5 points de vie elle ne meurt pas.
            Assert.AreEqual(1, opposingPlayerData.BattleField.Count);
            Assert.AreEqual(1, opposingPlayerData.Graveyard.Count);
        }

        #endregion

        #region GreedTest

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
                ManaCost = 2
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

            var playCardEvent = new PlayCardEvent(match, currentPlayerData, opposingPlayerData, playableCardA.Id);

            currentPlayerData.Hand.Add(playableCardB);
            currentPlayerData.Hand.Add(playableCardA);

            Assert.AreEqual(currentPlayerData.PlayerId, playCardEvent.PlayerId);

            // Test que la carte A possède le power Greed.
            Assert.IsTrue(playableCardA.Card.HasPower(Power.GREED_ID));

            // Les 2 joueurs ne sont pas blessés
            Assert.AreEqual(1, opposingPlayerData.Health);
            Assert.AreEqual(1, currentPlayerData.Health);

            //Le mana à été utilisé
            Assert.AreEqual(0, currentPlayerData.Mana);

            Assert.AreEqual(3, playableCardA.Health);
            Assert.AreEqual(5, playableCardB.Health);

            // Les 2 cartes sont encore en vie et doivent rester sur le BattleField
            // En plus le currentPlayer doit avoir recu 2 cartes de plus a sa main grace a Greed
            Assert.AreEqual(1, currentPlayerData.BattleField.Count);
            Assert.AreEqual(2, currentPlayerData.Hand.Count);
            Assert.AreEqual(1, opposingPlayerData.BattleField.Count);
        }

        #endregion

        #endregion
    }
}

