using System;
using System.Collections.Generic;
using System.Text;

namespace Game.AudioSystem
{
    /// <summary>
    /// Partial implementation of the AudioClip interface
    /// TODO use as parent class for AudioClip implementations.
    /// 
    /// TODO (backlog) allow different Audio-Engine minimum/maximum volumes to be used, instead of just 0 - 1.
    /// </summary>
    public abstract class BaseAudioClip
    {
        /// <summary>
        /// Constructor that can only be called in inheriting implementation class
        /// </summary>
        /// <param name="filepath">
        /// String filepath for the sound file.
        /// Path should be relative from the solution root, and should 
        /// have '/' replaced with  '.' for directories, 
        /// e.g. "Game.AudioFiles.SFX.Menu.ButtonClickTest.wav"
        /// </param>
        /// <param name="maxVolume">
        /// Floating point value between 0 and 1 which scales the volume of the audio clip. 
        /// Default = 1 (No volume scaling)
        /// NOTE: Should only be used for debugging - final audio assets should 
        /// be mixed and scaled, with balanced volumes across all assets
        /// </param>
        protected BaseAudioClip(string filepath, double maxVolume = 1.0)
        {
            MaxVolume = maxVolume;
            Filepath = filepath;
        }

        /// <summary>
        /// Abstract method which should start playback of the audio asset 
        /// TODO add 'fade length' parameter to this method for fade in
        /// </summary>
        /// <returns>
        /// true on successfull playback
        /// </returns>
        public abstract bool Play();


        /// <summary>
        /// Abstract method which should stop playback of the audio asset
        /// TODO add 'fade length' parameter to this method for fade out
        /// </summary>
        /// <returns>
        /// true if playback stoppage successfull
        /// </returns>
        public abstract bool Stop();

        /// <summary>
        /// Abstract method that must set the playback volume of the audio asset
        /// Implementation must multiply the passed-parameter volume by the maxVolume
        /// before setting the clip volume.
        /// </summary>
        /// <param name="volume">
        /// Double between 0 and 1 representing the current volume
        /// </param>
        /// <returns>
        /// true if volume sets correctly
        /// </returns>
        public abstract bool SetVolume(double volume);

        /// <summary>
        /// Abstract method that gets the current volume of the underlying audio clip
        /// </summary>
        /// <returns>
        /// Double between 0 and 1 representing the current volume
        /// </returns>
        public abstract double GetVolume();

        /// <summary>
        /// Loads the audio file. Must be called before playback
        /// </summary>
        /// <returns>
        /// True if successful load
        /// </returns>
        public abstract bool Load();

        /// <summary>
        /// The max volume of the AudioClip.
        /// Set in the BaseAudioClip constructor
        /// </summary>
        public double MaxVolume { get; private set; } = 1.0;

        /// <summary>
        /// The filepath of the audio clip 
        /// Set in BaseAudioClip constructor
        /// Relative path in form 'Game.AudioFiles.Example.mp3"
        /// </summary>
        public string Filepath { get; private set; }

        /// <summary>
        /// Flag which must be internally set to true if implementation of Load() succeeds when called
        /// </summary>
        public bool IsLoaded { get; private set; } = false;

    }
}
