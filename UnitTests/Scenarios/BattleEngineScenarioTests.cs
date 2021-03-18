using System.Threading.Tasks;
using System.Linq;

using NUnit.Framework;

using Game.Engine.EngineGame;
using Game.Models;
using Game.Helpers;
using Game.ViewModels;

namespace Scenario
{
    [TestFixture]
    public class BattleEngineScenarioTests
    {
        BattleEngine Battle;

        [SetUp]
        public void Setup()
        {
            Battle = new BattleEngine();

            Battle.EngineSettings.MaxNumberPartyCharacters = 6;
            Battle.EngineSettings.MaxNumberPartyMonsters = 6;

            Battle.EngineSettings.CharacterList.Clear();
            Battle.EngineSettings.MonsterList.Clear();

            Battle.EngineSettings.CurrentDefender = null;
            Battle.EngineSettings.CurrentAttacker = null;

            Battle.StartBattle(true);   // Clear the Engine
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void BattleEngine_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Battle;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
    }
}