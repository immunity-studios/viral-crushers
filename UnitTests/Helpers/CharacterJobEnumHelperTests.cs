using System.Linq;

using NUnit.Framework;

using Game.Models;

namespace UnitTests.Helpers
{
    [TestFixture]
    class CharacterJobEnumHelperTests
    {
        [Test]
        public void CharacterJobEnumHelper_GetJobList_Should_Pass()
        {
            // Arrange

            // Act
            //var result = CharacterJobEnumHelper.GetJobList;
            var result = CharacterJobEnumHelper.GetListItem;

            // Assert
            Assert.AreEqual(6,result.Count());

            // Assert
        }
    }
}