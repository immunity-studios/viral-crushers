using NUnit.Framework;
using Game.AudioSystem;

namespace UnitTests.AudioSystem
{
    [TestFixture]
    public class SimpleAudioClipTests
    {
        SimpleAudioClip clip;

        [TearDown]
        public void TearDown()
        {
            clip = null;
        }

        [Test]
        public void SimpleAudioClip_Constructor_Default_Should_Pass()
        {
            // Arrange
            clip = new SimpleAudioClip("fake/file/path");
            // Reset

            // Assert
            Assert.IsNotNull(clip);
        }


    }
}
