using System;
using Plugin.SimpleAudioPlayer;

namespace Game.AudioSystem
{
    /// <summary>
    /// Implementation of BaseAudioClip class that uses the SimpleAudioPlayer Nuget Package for Xamarin Forms. 
    /// <see href="https://www.nuget.org/packages/Xam.Plugin.SimpleAudioPlayer">Link to NuGet package repo</see>
    /// </summary>
    public sealed class SimpleAudioClip : BaseAudioClip
    {
        public SimpleAudioClip(string filePath, double volumeMax = 1.0, bool loop = false)
            : base(filePath, volumeMax)
        {
            // Set audio player settings
            SetLoop(loop);
            // To initialize the volume, we'll multiply the preset volume (1) by MaxVolume 
            SetVolume(GetVolume() * MaxVolume);
        }

        protected override bool Setup()
        {
            // Create sound player
            simpleAudioPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            if (simpleAudioPlayer == null)
            {
                // initialization of SimpleAudioPlayer failed, set IsSetup flag and return false
                IsSetup = false;
                return false;
            }
            // Audio api initialization successful - set IsSetup flag and return true
            IsSetup = true;
            return true;
        }

        public override bool GetLoop()
        {
            if (!IsSetup)
            {
                return false;
            } 
            return simpleAudioPlayer.Loop;
        }

        public override double GetVolume()
        {
            if (!IsSetup)
            {
                return 0;
            }
            return simpleAudioPlayer.Volume;
        }

        public override bool Load()
        {
            
            if (!IsSetup)
            {
                return false;
            }

            if (!IsLoaded)
            {
                try
                {
                    // Load the audio file as a stream, then load it into the audio player.
                    simpleAudioPlayer.Load(Helpers.ResourceFileHelpers.GetStreamFromFile(Filepath));
                }
                catch (Exception e)
                {
                    // Load failed
                    return false;
                }
            }
            // Load succeeded
            return true;
        }

        public override bool Play()
        {
            if (!IsSetup)
            {
                return false;
            }

            simpleAudioPlayer.Play();
            return true;
        }

        public override bool SetLoop(bool loop)
        {
            if (!IsSetup)
            {
                return false;
            }

            simpleAudioPlayer.Loop = loop;
            return true;
        }

        public override bool SetVolume(double volume)
        {
            if (!IsSetup)
            {
                return false;
            }
            simpleAudioPlayer.Volume = volume;
            return true;
        }

        public override bool Stop()
        {
            if (!IsSetup)
            {
                return false;
            }
            simpleAudioPlayer.Stop();
            return true;
        }

        /// <summary>
        /// The underlying audio file player
        /// </summary>
        private ISimpleAudioPlayer simpleAudioPlayer;
    }
}
