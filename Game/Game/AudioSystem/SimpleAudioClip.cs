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
        public SimpleAudioClip(string filePath, double volumeMax = 1.0, bool loop = false)
            : base(filePath, volumeMax)
        {
            //LoopIds = new Stack<int>(3);
            // Set audio player settings
            if(!PlatformIsAndroid())
                SetLoop(loop);

            // To initialize the volume, we'll multiply the preset volume (1) by MaxVolume 
            SetVolume(GetVolume() * MaxVolume);
        }

        /// <inheritdoc cref="BaseAudioClip.Setup"/>
        protected override bool Setup()
        {
            Console.WriteLine("Setting up SimpleAudioClip with file: " + Filepath + "...");
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
            return true;
        }
        
        

        /// <inheritdoc cref="BaseAudioClip.Load"/>
        protected override bool _Load()
        {
            Console.WriteLine("Loading file " + Filepath);
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
                    Debug.WriteLine(e);
                    return false;
                }
            }
            // Load succeeded
            IsLoaded = true;
            return true;
        }

        /// <inheritdoc cref="BaseAudioClip.Play"/>
        protected override bool _Play()
        {
            Console.WriteLine("Playing " + Filepath);
            // Check if we are on android and loop is set (TODO have IsLoop flag separate from implementation's flag (player.Loop)
            if (PlatformIsAndroid() && GetLoop())
            {
                // start the initial play
                return PlayLoopAndroid(currentLoopID);
                
            }
            simpleAudioPlayer.Play();
            return true;
        }

        private bool PlatformIsAndroid()
        {
            return Device.RuntimePlatform == Device.Android;
        }

        //private int loopCount = 0;
        private int currentLoopID = 0;
        private Stack<int> LoopIds;


        private bool PlayLoopAndroid(int initialLoopId)
        {
            // compare current ID of playback when the loop
            // call was initiated to the current loop id


            TimeSpan timeSpan = TimeSpan.FromSeconds(simpleAudioPlayer.Duration);//simpleAudioPlayer.Duration);
            Console.WriteLine("Loop timer length = " + timeSpan);
            
            if (initialLoopId != currentLoopID)
            {
                Console.WriteLine("Initial Loop ID was not current Loop ID, stopping the requested loop playback");
                return false;
            }

            if (simpleAudioPlayer.IsPlaying)
                simpleAudioPlayer.Stop();
            Console.WriteLine("Starting Playback");
            simpleAudioPlayer.Play();
            Console.WriteLine("Starting Timer");
            Device.StartTimer(
                timeSpan,
                () => PlayLoopAndroid(initialLoopId: currentLoopID));

            return true;
        }

        /// <inheritdoc cref="BaseAudioClip.SetLoop"/>
        protected override bool _SetLoop(bool loop)
        {
            if (!IsSetup)
            {
                return false;
            }
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
            simpleAudioPlayer.Stop();

            if (PlatformIsAndroid())
                currentLoopID++;

            return true;
        }

        //private bool StopAndroid()
        //{
        //    simpleAudioPlayer.Stop();
        //    currentLoopID++;
        //    return true;
        //}

        
    }
}
