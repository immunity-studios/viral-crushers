using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.SimpleAudioPlayer;
using Xamarin.Forms;

namespace Game.AudioSystem
{
    /// <summary>
    /// Sealed implementation of BaseAudioClip class.
    /// Uses the SimpleAudioPlayer Nuget Package for Xamarin Forms. 
    /// <see href="https://www.nuget.org/packages/Xam.Plugin.SimpleAudioPlayer">Link to NuGet package repo</see>
    /// </summary>
    /// <inheritdoc cref="BaseAudioClip"/>
    public sealed class SimpleAudioClip : BaseAudioClip
    {
        /// <summary>
        /// The underlying audio file player
        /// </summary>
        private ISimpleAudioPlayer simpleAudioPlayer;


        /// <inheritdoc cref="BaseAudioClip"/>
        public SimpleAudioClip(string filePath, double volumeMax = 1.0, bool loop = false, int numberOfLoopsContained = 0)
            : base(filePath, volumeMax, loop, numberOfLoopsContained)
        {
           System.Console.WriteLine("In SimpleAudioClip()");
           if (Setup())
            {
                _SetLoop(IsLoop);
                _SetVolume(MaxVolume);
            }
        }

        /// <inheritdoc cref="BaseAudioClip.Setup"/>
        protected override bool Setup()
        {
            Console.WriteLine("SimpleAudioClip.Setup() with file: " + Filepath + "...");
            // Create sound player
            simpleAudioPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            if (simpleAudioPlayer == null)
            {
                // initialization of SimpleAudioPlayer failed, set IsSetup flag and return false
                IsSetup = false;
                Console.WriteLine("Setup Failed!");
                return false;
            }
            // Audio api initialization successful - set IsSetup flag and return true
            IsSetup = true;
            Console.WriteLine("Setup Succeeded!");

            simpleAudioPlayer.PlaybackEnded += _PlaybackEnded;

            return true;
        }


        protected override double _SetTimeLengthSeconds()
        {
            return simpleAudioPlayer.Duration;
        }


        /// <inheritdoc cref="BaseAudioClip.Load"/>
        protected override bool _Load()
        {
            Console.WriteLine("In SimpleAudioClip.Load() for file " + Filepath);
            bool success = false;
            try
            {
                // Load the audio file as a stream, then load it into the audio player.
                success = simpleAudioPlayer.Load(Helpers.ResourceFileHelpers.GetStreamFromFile(Filepath));
            }
            catch (Exception e)
            {
                // Load failed
                Debug.WriteLine(e);
                return false;
            }
            // Load succeeded
            IsLoaded = success;
            return true;
        }

        /// <inheritdoc cref="BaseAudioClip.Play"/>
        protected override bool _Play()
        {
            //Console.WriteLine("Playing " + Filepath);
           
            simpleAudioPlayer.Play();
            return true;
        }

        /// <summary>
        /// Callback for when audio clips end.
        /// Used by android build to 'loop' audio playback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _PlaybackEnded(object sender, EventArgs e)
        {
            // if we're on android and this clip is a loop, we'll need to play again
            if (PlatformIsAndroid() && IsLoop)
            {
                Play();
            }
        }

        private bool PlatformIsAndroid()
        {
            return Device.RuntimePlatform == Device.Android;
        }



        private bool PlayLoopAndroid(int initialLoopId)
        {
            //Device.StartTimer(System.TimeSpan.FromMilliseconds(2000), () => { System.Console.WriteLine("This fired after 2 seconds"); return true; });
            return true;

        }

        /// <inheritdoc cref="BaseAudioClip.SetLoop"/>
        protected override bool _SetLoop(bool loop)
        {
            simpleAudioPlayer.Loop = loop;
            return true;
        }

        /// <inheritdoc cref="BaseAudioClip.SetVolume"/>
        protected override bool _SetVolume(double volume)
        {
            simpleAudioPlayer.Volume = volume;
            return true;
        }

        /// <inheritdoc cref="BaseAudioClip.Stop"/>
        protected override bool _Stop()
        {
            // check if clip is currently playing
            if (!simpleAudioPlayer.IsPlaying)
            {
                return false;
            }

            simpleAudioPlayer.Stop();

            return true;
        }
        
    }
}
