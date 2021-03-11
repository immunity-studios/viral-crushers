using NUnit.Framework;

using Game.Models;
using System.Threading.Tasks;
using Xamarin.Forms.Mocks;
using Game.ViewModels;

namespace Hackathon
{
    [TestFixture]
    public class HackathonScenarioTests
    {
        #region TestSetup
        readonly BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            // Choose which engine to run
            EngineViewModel.SetBattleEngineToGame();

            // Put seed data into the system for all tests
            EngineViewModel.Engine.Round.ClearLists();

            //Start the Engine in AutoBattle Mode
            EngineViewModel.Engine.StartBattle(false);

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum= HitStatusEnum.Default;

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = false;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss = false;
        }

        [TearDown]
        public void TearDown()
        {
            EngineViewModel.Engine.EndBattle();
        }
        #endregion TestSetup

        #region Scenario0
        [Test]
        public void HakathonScenario_Scenario_0_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      #
            *      
            * Description: 
            *      <Describe the scenario>
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      <List Files Changed>
            *      <List Classes Changed>
            *      <List Methods Changed>
            * 
            * Test Algrorithm:
            *      <Step by step how to validate this change>
            * 
            * Test Conditions:
            *      <List the different test conditions to make>
            * 
            * Validation:
            *      <List how to validate this change>
            *  
            */

            // Arrange

            // Act

            // Assert
           

            // Act
            var result = EngineViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Scenario0

        #region Scenario1
        [Test]
        public async Task HackathonScenario_Scenario_1_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      1
            *      
            * Description: 
            *      Make a Character called Mike, who dies in the first round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create Character named Mike
            *      Set speed to -1 so he is really slow
            *      Set Max health to 1 so he is weak
            *      Set Current Health to 1 so he is weak
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Mike is not in the Player List
            *      Verify Round Count is 1
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1, // Will go last...
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            //Act
            var result = await EngineViewModel.AutoBattleEngine.RunAutoBattle();

            //Reset
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, EngineViewModel.Engine.EngineSettings.PlayerList.Find(m => m.Name.Equals("Mike")));
            //Assert.AreEqual(2, EngineViewModel.Engine.EngineSettings.BattleScore.RoundCount);
        }
        #endregion Scenario1

        #region Scenario2
        [Test]
        public async Task HackathonScenario_Scenario_2_Valid_Attack_Should_Miss()
        {
            /* 
            * Scenario Number:  
            *      2
            *      
            * Description: 
            *      Make a Character called Bob, who always miss but can do other action such as move or use abilities
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Changed Method CalculateAttackStatus in TurnEngine.cs 
            * 
            * Test Algrorithm:
            *      Create Character named Bob
            *      Set Bob as Current Attacker
            *      
            *      Create Monster named Bubble
            *      Set Bubble as Current Defender
            *      Run Attack Turn
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Turn Returned Miss
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerBob = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 8, 
                                Level = 1,
                                CurrentHealth = 5,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Bob",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Clear();
            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerBob);

            // Set Monsters Conditions

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyMonsters = 1;

            var MonsterPlayerBubble = new PlayerInfoModel(
                            new MonsterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 3,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Bubble",
                            });

            EngineViewModel.Engine.EngineSettings.MonsterList.Clear();
            EngineViewModel.Engine.EngineSettings.MonsterList.Add(MonsterPlayerBubble);

            //Act
            var result = EngineViewModel.Engine.Round.Turn.CalculateAttackStatus(CharacterPlayerBob, MonsterPlayerBubble);

            //Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        [Test]
        public async Task HackathonScenario_Scenario_2_Valid_Ability_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      2
            *      
            * Description: 
            *      Make a Character called Bob, who always miss but can do other action such as use abilities
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Changed Method CalculateAttackStatus in TurnEngine.cs 
            * 
            * Test Algrorithm:
            *      Create Character named Bob
            *      Set Bob as Current Attacker
            *      Set Current Action is Ability
            *      Set Current Action Ability is Bandage
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Returned True
            *  
            */

            //Arrange

            EngineViewModel.Engine.EngineSettings.CurrentAction = ActionEnum.Ability;
            EngineViewModel.Engine.EngineSettings.CurrentActionAbility = AbilityEnum.Bandage;

            // Set Character Conditions

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerBob = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 8,
                                Level = 1,
                                CurrentHealth = 5,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Bob",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Clear();
            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerBob);

            //Act
            var result = EngineViewModel.Engine.Round.Turn.TakeTurn(CharacterPlayerBob);

            //Assert
            Assert.AreEqual(true, result);
        }
        #endregion Scenario2


        
    }
}