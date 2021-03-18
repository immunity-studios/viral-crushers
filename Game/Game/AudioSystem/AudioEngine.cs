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
        /// The default starting volume for the audio engine
        /// </summary>
        private const double STARTING_VOLUME = .6;

        /// <summary>
        /// Audio engine constructor which initializes audio bus volumes
        /// </summary>
        public AudioEngine()
        {
            busVolumes = new Dictionary<AudioBusEnum, double>();
            loopsPlaying = new List<BaseAudioClip>();
            InitBusVolumes();
        }

        /// <summary>
        /// Method which initializes all buses to the default starting volume 
        /// </summary>
        /// <returns></returns>
        private bool InitBusVolumes()
        {
            foreach (AudioBusEnum bus in Enum.GetValues(typeof(AudioBusEnum)))
            {
                busVolumes.Add(bus, STARTING_VOLUME);
            }
            return true;
        }

        /// <summary>
        /// Method which should be called after the Audio Engine has been instantiated.
        /// It loads all audio clips, and sets the volume of those clips based on 
        /// each clip's bus
        /// </summary>
        /// <returns></returns>
        public bool Setup()
        {
            LoadAudio();
            InitClipVolumes();
            return true;
        }

        /// <summary>
        /// Method that calls Load on all audio clips in the AudioResources.Instance.AudioClips list
        /// </summary>
        /// <returns></returns>
        private bool LoadAudio()
        {
            foreach (var audioClip in AudioResources.Instance.AudioClips)
            {
                bool loaded = audioClip.Load();
                Console.WriteLine(loaded? "Loaded" : "Failed to load" + " audio file with path " + audioClip.Filepath);
            }
            return true;
        }

        /// <summary>
        /// Sets the volume of each clip based on its audio bus's current volume
        /// </summary>
        /// <returns></returns>
        private bool InitClipVolumes()
        {
            foreach (var audioClip in AudioResources.Instance.AudioClips)
            {
                audioClip.SetVolume(busVolumes[audioClip.GetAudioBus()]);
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
        /// true is event processing is successfull, false if audioEvent was not processed
        /// </returns>
        public bool ProcessAudioEvent(AudioEventEnum audioEvent)
        {
            switch (audioEvent)
            {
                // UI Menu click events
                case AudioEventEnum.Button_GameStart:
                    AudioResources.Instance.MENU_CLICK_SOUND.Play();
                    break;
                case AudioEventEnum.Button_Default:
                    AudioResources.Instance.MENU_CLICK_SOUND.Play();
                    break;

                // HACKATHON sound effects
                case AudioEventEnum.Player_Attack_Hit:
                    AudioResources.Instance.SFX_BATTLE_PLAYER_ATTACK_HIT.Play();
                    break;
                case AudioEventEnum.Player_Attack_Miss:
                    AudioResources.Instance.SFX_BATTLE_PLAYER_ATTACK_MISS.Play();
                    break;
                case AudioEventEnum.Player_Death:
                    AudioResources.Instance.SFX_BATTLE_PLAYER_DEATH.Play();
                    break;
                // End hackathon sound effects

                // Music implementation
                case AudioEventEnum.MenuStart:
                    StopAllLoops();
                    TryPlayClip(AudioResources.Instance.MX_MENU_P1_4XLOOP_4_4_116BPM);
                    break;
                case AudioEventEnum.GamePageReached:
                    StopAllLoops();
                    TryPlayClip(AudioResources.Instance.MX_MENU_P2_4XLOOP_4_4_116BPM);
                    break;
                case AudioEventEnum.BattleSequenceStarted:
                    StopAllLoops();
                    TryPlayClip(AudioResources.Instance.MX_MENU_P3_4XLOOP_4_4_116BPM);
                    break;
                case AudioEventEnum.BattleStart:
                    StopAllLoops();
                    TryPlayClip(AudioResources.Instance.MX_BATTLE_P1_1XLOOP_4_4_140BPM_LONG);
                    break;

                default:
                    return false; // event was not found, so return false
            }
            return true;
        }

        /// <summary>
        /// Method that stops all loops in the loopsPlaying list, and clears the list
        /// </summary>
        /// <returns>true if successfull</returns>
        private bool StopAllLoops()
        {
            // stop all loops
            foreach (BaseAudioClip clip in loopsPlaying)
                clip.Stop();
            // clear the list
            loopsPlaying.Clear();
            return true;
        }

        /// <summary>
        /// Method that tries to play a clip
        /// If playback succeeds, the clip is added to the loopsPlaying list
        /// </summary>
        /// <param name="clip"></param>
        /// <returns></returns>
        private bool TryPlayClip(BaseAudioClip clip)
        {
            var result = clip.Play();
            
            if(result != null)
            {
                loopsPlaying.Add(clip);
            }

            return true;
        }

        /// <summary>
        /// Method that can be called to set a specified bus' volume.
        /// Sets all clips on the associated bus to the specified volume
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
            busVolumes[bus] = volume;
            foreach (var audioClip in AudioResources.Instance.AudioClips)
            {
                if(audioClip.GetAudioBus() == bus)
                    audioClip.SetVolume(volume);
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

        /// <summary>
        /// List holding references to BaseAudioClip loops that are currently playing
        /// </summary>
        private List<BaseAudioClip> loopsPlaying;
    }
}
