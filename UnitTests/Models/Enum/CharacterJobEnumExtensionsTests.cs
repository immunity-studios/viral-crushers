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
        public void CharacterJobEnumExtensionsTests_Cleric_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Cleric.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Cleric", result);
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

        [Test]
        public void CharacterJobEnumExtensionsTests_Doctor_ToImageFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Doctor.ToImageFile();

            // Reset

            // Assert
            Assert.AreEqual("icon_doctor.png", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Teacher_ToImageFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Teacher.ToImageFile();

            // Reset

            // Assert
            Assert.AreEqual("icon_teacher.png", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Doctor_ToGifFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Doctor.ToGifFile();

            // Reset

            // Assert
            Assert.AreEqual("docgif.gif", result);
        }


        [Test]
        public void CharacterJobEnumExtensionsTests_Teacher_ToGifFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Teacher.ToGifFile();

            // Reset

            // Assert
            Assert.AreEqual("teachergif.gif", result);
        }


        [Test]
        public void CharacterJobEnumExtensionsTests_PoliceOfficer_ToGifFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.PoliceOfficer.ToGifFile();

            // Reset

            // Assert
            Assert.AreEqual("police.gif", result);
        }


        [Test]
        public void CharacterJobEnumExtensionsTests_CollegeStudent_ToGifFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.CollegeStudent.ToGifFile();

            // Reset

            // Assert
            Assert.AreEqual("studentgif.gif", result);
        }


        [Test]
        public void CharacterJobEnumExtensionsTests_Firefighter_ToGifFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Firefighter.ToGifFile();

            // Reset

            // Assert
            Assert.AreEqual("firefightergif.gif", result);
        }


        [Test]
        public void CharacterJobEnumExtensionsTests_Unknown_ToGifFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Unknown.ToGifFile();

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }



        [Test]
        public void CharacterJobEnumExtensionsTests_Athlete_ToImageFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Athlete.ToImageFile();

            // Reset

            // Assert
            Assert.AreEqual("icon_athlete.png", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_PoliceOfficer_ToImageFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.PoliceOfficer.ToImageFile();

            // Reset

            // Assert
            Assert.AreEqual("icon_officer.png", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Student_ToImageFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.CollegeStudent.ToImageFile();

            // Reset

            // Assert
            Assert.AreEqual("icon_student.png", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Firefighter_ToImageFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Firefighter.ToImageFile();

            // Reset

            // Assert
            Assert.AreEqual("icon_firefighter.png", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Unknown_ToImageFile_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Unknown.ToImageFile();

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}
