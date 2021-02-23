using NUnit.Framework;

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
    }
}
