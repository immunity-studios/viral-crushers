using NUnit.Framework;
using Game.AudioSystem;

namespace UnitTests.AudioSystem
{
    [TestFixture]
    public class AudioEngineTests
    {
        AudioEngine audioEngine;

        [SetUp]
        public void Setup()
        {
            audioEngine = AudioEngine.Instance;
        }

        [Test]
        public void AudioEngine_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = audioEngine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
