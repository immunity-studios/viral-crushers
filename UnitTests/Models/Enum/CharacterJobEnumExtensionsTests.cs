﻿using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class CharacterJobEnumExtensionsTests
    {
        [Test]
        public void CharacterJobEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Character", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Fighter_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Fighter.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Fighter", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Firefighter_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Firefighter.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Firefighter", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Teacher_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Teacher.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Teacher", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Doctor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Doctor.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Doctor", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Athlete_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Athlete.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Athlete", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_PoliceOfficer_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.PoliceOfficer.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Police Officer", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_CollegeStudent_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.CollegeStudent.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("College Student", result);
        }
    }
}
