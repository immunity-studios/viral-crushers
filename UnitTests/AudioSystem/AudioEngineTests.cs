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

        public void AudioEngine_GetBusVolume_Default_Should_Pass()
        {
            // arrange
            var result = audioEngine;
            
            AudioBusEnum bus = AudioBusEnum.Master;

            // act
            var volume = result.GetBusVolume(bus);

            // assert

            // This is comparing doubles, could add a delta value as 3rd parameter if failures occur due to double precision error
            Assert.AreEqual(.6, volume);
        }
        
        [Test]
        public void AudioEngine_SetBusVolume_Should_Return_Same_Volume()
        {
            
            var result = audioEngine;

            AudioBusEnum bus = AudioBusEnum.Music;

            var volume = .3;


            // act
            result.SetBusVolume(bus, volume);

            // assert
            Assert.AreEqual(volume, audioEngine.GetBusVolume(bus));

        }

        [Test]
        public void AudioEngine_ProcessAudioEvent_GameStart_ShouldPass()
        {
            // arrange
            var result = audioEngine;

            // act
            var success = audioEngine.ProcessAudioEvent(AudioEventEnum.MenuStart);

            //     Assert
            Assert.True(success);
        
        }
    }
}
