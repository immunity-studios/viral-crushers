using Xamarin.Forms;
using Xamarin.Forms.Mocks;

using NUnit.Framework;

using Game.ViewModels;
using Game.Views;
using Game;

namespace Scenario
{
    [TestFixture]
    public class BattlePageScenarioTests
    {
        App app;
        BattlePage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            // Choose which engine to run
            BattleEngineViewModel.Instance.SetBattleEngineToKoenig();

            page = new BattlePage();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void BattlePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BattlePage_RunBattle_Strong_Monsters_Should_GameOver()
        {
            //Arrange

            // Add Characters

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1,
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });
            EngineViewModel.Engine.EngineSettings.CharacterList.Clear();
            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);


            // Add Monsters
            // Need to set the Monster count to 1, so the battle goes to Next Round Faster
            EngineViewModel.Engine.EngineSettings.MaxNumberPartyMonsters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                            new MonsterModel
                            {
                                Speed = 10,
                                Level = 10,
                                CurrentHealth = 100,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Attack = 100,
                                Name = "Bubble",
                                ListOrder = 1,
                            });
            EngineViewModel.Engine.EngineSettings.MonsterList.Clear();
            EngineViewModel.Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Make the List
            EngineViewModel.Engine.EngineSettings.PlayerList = EngineViewModel.Engine.Round.MakePlayerList();

            // Set currentAttacker and CurrentDefender
            EngineViewModel.Engine.Round.SetCurrentAttacker(EngineViewModel.Engine.EngineSettings.PlayerList.Where(m => m.PlayerType == PlayerTypeEnum.Monster).FirstOrDefault());
            //EngineViewModel.Engine.Round.SetCurrentDefender(EngineViewModel.Engine.EngineSettings.PlayerList.Where(m => m.PlayerType == PlayerTypeEnum.Character).FirstOrDefault());

            //Act
            RoundEnum result;

            // Force a Hit
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // First Monster Hits
            EngineViewModel.Engine.EngineSettings.CurrentAction = ActionEnum.Attack;
            page.NextMonsterAttack();
            result = EngineViewModel.Engine.EngineSettings.RoundStateEnum;

            // Monsters Turn
            page.AttackButton_Clicked(null, null);
            result = EngineViewModel.Engine.EngineSettings.RoundStateEnum;


            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(RoundEnum.GameOver, result);
        }
    }
}