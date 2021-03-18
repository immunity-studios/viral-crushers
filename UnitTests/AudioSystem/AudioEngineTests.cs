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
            audioEngine = new AudioEngine();
        }
    }
}
