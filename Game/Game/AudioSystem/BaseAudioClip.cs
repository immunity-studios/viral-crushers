using System;
using System.Collections.Generic;
using System.Text;

namespace Game.AudioSystem
{
    /// <summary>
    /// An abstract implementation of an audio clip, this is 
    /// the base audio API used by AudioEngine to play audio.
    /// 
    /// Inheriting class should accept a parameter of bool for Loop property
    /// in the constructor, in addition to params passed to BaseAudioClip
    /// 
    /// TODO (backlog) allow different Audio-Engine minimum/maximum 
    ///                volumes to be used, instead of just 0 - 1.
    /// </summary>
    public abstract class BaseAudioClip
    {
        /// <summary>
        /// Abstract method that must setup the audio clip within 
        /// the user's chosen audio API implementation.
        /// Called in the first line of the BaseAudioClip constructor,
        /// before other properties of the audio clip are set.
        /// </summary>
        /// <returns>
        /// true, or false if setup fails
        /// </returns>
        protected abstract bool Setup();

        /// <summary>
        /// Abstract method which should start playback of the audio asset 
        /// TODO Add 'fade length' parameter to this method for fade in
        /// </summary>
        /// <returns>
        /// true, or false if playback fails
        /// </returns>
        public abstract bool Play();

        /// <summary>
        /// Abstract method which should stop playback of the audio asset
        /// TODO Add 'fade length' parameter to this method for fade out
        /// </summary>
        /// <returns>
        /// true, or false if playback stoppage fails
        /// </returns>
        public abstract bool Stop();

        /// <summary>
        /// Abstrat method that loads the audio file. Must be called before playback
        /// </summary>
        /// <returns>
        /// True, or false if fails
        /// </returns>
        public abstract bool Load();

        /// <summary>
        /// Abstract method that must set the playback volume of the audio asset
        /// Implementation must multiply the passed-parameter volume by the maxVolume
        /// before setting the clip volume.
        /// </summary>
        /// <param name="volume">
        /// Double between 0 and 1 representing the current volume
        /// </param>
        /// <returns>
        /// True, or false if set volume fails
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
        /// Abstract method that must set the clip's playback setting to loop (repeating playback)
        /// </summary>
        /// <param name="loop">
        /// True if audio clip should loop, false if it should only play once
        /// </param>
        /// <returns>
        /// True, or false if set loop fails
        /// </returns>
        public abstract bool SetLoop(bool loop);

        /// <summary>
        /// Abstract method that must get the clip's playback setting for loop (repeating playback)
        /// </summary>
        /// <returns>
        /// True if this is a looping audio clip
        /// </returns>
        public abstract bool GetLoop();

        /// <summary>
        /// The max volume of the AudioClip.
        /// Set in the BaseAudioClip constructor
        /// </summary>
        protected double MaxVolume { get; private set; } = 1.0;

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

        /// <summary>
        /// Base constructor that must be called by the inheriting class
        /// Calls Setup() method in the inheriting class, then sets 
        /// the value of class members filepath and maxVolume
        /// </summary>
        /// <param name="filepath">
        /// String filepath for the sound file.
        /// Path should be relative from the solution root, and should 
        /// have '/' replaced with  '.' for directories, 
        /// e.g. "Game.AudioFiles.SFX.Menu.ButtonClickTest.wav"
        /// </param>
        /// <param name="maxVolume">
        /// Floating point value between 0 and 1 (Scales the volume of the audio clip)
        /// Default value: 1 (No volume scaling)
        /// </param>
        protected BaseAudioClip(string filepath, double maxVolume = 1.0)
        {
            Setup();
            MaxVolume = maxVolume;
            Filepath = filepath;
        }

    }
}
