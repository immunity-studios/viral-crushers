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

        [TearDown]
        public void TearDown()
        {
            audioEngine = null;
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

        //[Test]
        //public void AudioEngine_ProcessAudioEvent_GameStart_ShouldPass()
        //{
        //     Act
        //    var result = audioEngine; 
        //     Reset
        //     Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
