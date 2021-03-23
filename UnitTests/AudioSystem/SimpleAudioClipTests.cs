using NUnit.Framework;
using Game.AudioSystem;

namespace UnitTests.AudioSystem
{
    [TestFixture]
    public class SimpleAudioClipTests
    {
        //
        const string FAKE_FILE_PATH = "file/path/fake.wav";

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
            clip = new SimpleAudioClip(FAKE_FILE_PATH);
            // Reset

            // Assert
            Assert.IsNotNull(clip);
        }

        [Test]
        public void SimpleAudioClip_Constructor_SetFilepath_Should_Pass()
        {
            // Arrange
            clip = new SimpleAudioClip(FAKE_FILE_PATH);

            // Assert
            Assert.AreEqual(FAKE_FILE_PATH, clip.Filepath);
        }

    }
}
