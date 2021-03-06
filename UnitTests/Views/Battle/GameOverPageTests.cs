﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.Models;
using Game.ViewModels;

namespace UnitTests.Views
{
    [TestFixture]
    public class GameOverPageTests
    {
        App app;
        GameOverPage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            // For now, set the engine to the Koenig Engine, change when ready 
            BattleEngineViewModel.Instance.SetBattleEngineToKoenig();

            page = new GameOverPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void GameOverPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GameOverPage_CloseButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.CloseButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GameOverPage_CreateCharacterBox_Default_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel());

            // Act
            page.CreateCharacterDisplayBox(data);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GameOverPage_CreateCharacterBox_Null_Should_Pass()
        {
            // Arrange

            // Act
            page.CreateCharacterDisplayBox(null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GameOverPage_CreateMonsterBox_Default_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new MonsterModel());

            // Act
            page.CreateMonsterDisplayBox(data);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GameOverPage_CreateMonsterBox_Null_Should_Pass()
        {
            // Arrange

            // Act
            page.CreateMonsterDisplayBox(null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GameOverPage_CreateItemBox_Default_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();

            // Act
            page.CreateItemDisplayBox(data);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GameOverPage_CreateItemBox_Null_Should_Pass()
        {
            // Arrange

            // Act
            page.CreateItemDisplayBox(null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GameOverPage__Default_Should_Pass()
        {
            // Arrange

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.CharacterModelDeathList.Add(new PlayerInfoModel(new CharacterModel()));

            // Draw the Monsters
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.MonsterModelDeathList.Add(new PlayerInfoModel(new CharacterModel()));

            // Draw the Items
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel());
    
            // Act
            page.DrawOutput();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}