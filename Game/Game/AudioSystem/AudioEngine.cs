using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Game.AudioSystem
{
    /// <summary>
    /// Singleton class which gives the application access to the platform audio system
    /// The audio engine instance can be notified of events to trigger sound playback and volume changes
    /// </summary>
    public class AudioEngine
    {
        #region Singleton

        // Make the AudioEngine a singleton so it only exists one time.
        private static volatile AudioEngine instance;
        private static readonly object syncRoot = new Object();

        /// <summary>
        /// Returns the singleton instance of the audio engine
        /// </summary>
        public static AudioEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new AudioEngine();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        /// <summary>
        /// Audio engine constructor
        /// </summary>
        public AudioEngine()
        {

        }

        public bool LoadAudio()
        {
            foreach (var audioClip in AudioResources.AudioClips)
            {
                bool loaded = audioClip.Load();
            }

            return true;
        }

        /// <summary>
        /// Method that should be called when an audio event happens in the application.
        /// The audio event enum is processed and audio is played/stopped/managed in this method
        /// </summary>
        /// <param name="audioEvent">
        /// Enum representing the specific audio event that has occured
        /// </param>
        /// <returns>
        /// true is event processing is successfull
        /// </returns>
        public bool ProcessAudioEvent(AudioEventEnum audioEvent)
        {
            switch (audioEvent)
            {
                case AudioEventEnum.Button_GameStart:
                    AudioResources.MENU_CLICK_SOUND.Play();
                    break;
                case AudioEventEnum.MenuStart:
                    AudioResources.MX_MENU_SONG1_FULL_LOOP.Play();
                    break;
                case AudioEventEnum.BattleStart:
                    AudioResources.MX_MENU_SONG1_FULL_LOOP.Stop();
                    AudioResources.MX_BATTLE_LOOP.Play();
                    break;
                default:
                    return false; // event was not found, so return false
            }
            return true;
        }

        /// <summary>
        /// Method that can be called to set a specified bus' volume
        /// </summary>
        /// <param name="bus"> 
        /// The volume bus to set
        /// </param>
        /// <param name="volume"> 
        /// The value to set volume to. Must be between 0 and 1 (inclusive)
        /// </param>
        /// <returns></returns>
        public bool SetBusVolume(AudioBusEnum bus, double volume)
        {
            switch (bus)
            {
                case AudioBusEnum.Master:
                    // loop through each audio clip and scale its volume based on provided value
                    foreach(var audioClip in AudioResources.AudioClips)
                    {
                        audioClip.SetVolume(volume);
                    }
                    break;
            }
            return true;
        }
    }
}
