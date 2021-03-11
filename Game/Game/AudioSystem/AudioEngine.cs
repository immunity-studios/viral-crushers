using System;
using System.Collections.Generic;


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
        /// Audio engine constructor which initializes AudioResources
        /// </summary>
        public AudioEngine()
        {
            busVolumes = new Dictionary<AudioBusEnum, double>();
            // Set starting volume of all audio buses to 0
            double startingVolume = 0;
            foreach(AudioBusEnum bus in Enum.GetValues(typeof(AudioBusEnum)))
            {
                busVolumes.Add(bus, startingVolume);
            }
        }

        public bool Setup()
        {
            //CrossMediaManager.Current.Init();
            LoadAudio();
            return true;

        }

        public bool LoadAudio()
        {
            foreach (var audioClip in AudioResources.Instance.AudioClips)
            {
                bool loaded = audioClip.Load();
                Console.WriteLine(loaded? "Loaded" : "Failed to load" + " audio file with path " + audioClip.Filepath);
            }
            SetBusVolume(AudioBusEnum.Master, 0);
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
                    AudioResources.Instance.MENU_CLICK_SOUND.Play();
                    break;

                case AudioEventEnum.MenuStart: 
                    //AudioResources.Instance.MX_MENU_FULL.Play(); 
                    AudioResources.Instance.MX_MENU_SONG1_FULL_LOOP.Play();
                    break;
                
                case AudioEventEnum.BattleStart:
                    AudioResources.Instance.MX_MENU_FULL.Stop();
                    AudioResources.Instance.MX_BATTLE_FULL.Play();
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
                    foreach(var audioClip in AudioResources.Instance.AudioClips)
                    {
                        audioClip.SetVolume(volume);
                    }
                    break;
            }
            return true;
        }

        /// <summary>
        /// Method that Returns the current volume of an audio bus
        /// </summary>
        /// <param name="bus">
        /// The bus to get the volume of
        /// </param>
        /// <returns>
        /// The current volume of the specified audio bus
        /// </returns>
        public double GetBusVolume(AudioBusEnum bus)
        {
            return busVolumes[bus];
        }

        /// <summary>
        /// Dictionary containing the volumes of the audio buses.
        /// Is set-up in the AudioEngine constructor
        /// </summary>
        private Dictionary<AudioBusEnum, double> busVolumes;
    }
}
