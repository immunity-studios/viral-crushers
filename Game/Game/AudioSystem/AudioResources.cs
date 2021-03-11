using System;
using System.Collections.Generic;
using System.Text;

namespace Game.AudioSystem
{
    /// <summary>
    /// Class that manages the game sounds that are used by the AudioEngine
    /// </summary>
    public class AudioResources
    {

        #region Singleton

        // Make AudioResources a singleton so it only exists one time.
        private static volatile AudioResources instance;
        private static readonly object syncRoot = new Object();

        /// <summary>
        /// Returns the singleton instance of the audio resources
        /// </summary>
        public static AudioResources Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new AudioResources();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        /// <summary>
        /// Constructor which adds all BaseAudioClip members to the AudioClips list
        /// </summary>
        private AudioResources()
        {
            AudioClips = new List<BaseAudioClip>() {
                MENU_CLICK_SOUND,
                MX_MENU_SONG1_FULL_LOOP,
                MX_BATTLE_LOOP,
                MX_MENU_FULL,
                MX_BATTLE_FULL,
                SFX_BATTLE_PLAYER_ATTACK_HIT,
                SFX_BATTLE_PLAYER_ATTACK_MISS,
                SFX_BATTLE_PLAYER_DEATH
            };
        }

        /// <summary>
        /// Default menu click sound
        /// </summary>
        public BaseAudioClip MENU_CLICK_SOUND = new SimpleAudioClip(
            filePath: "Game.AudioFiles.SFX.Menu.UI_CLICK_1.wav",
            //volumeMax: 1,
            loop: false
        );

        /// <summary>
        /// Main menu music loop
        /// </summary>
        public BaseAudioClip MX_MENU_SONG1_FULL_LOOP = new SimpleAudioClip(
           filePath: "Game.AudioFiles.Music.Menu.MENU_116-BPM-LOOP.wav",
           loop: true
        );

        /// <summary>
        /// Long version of the Main Menu Loop
        /// </summary>
        public BaseAudioClip MX_MENU_FULL= new SimpleAudioClip(
           filePath: "Game.AudioFiles.Music.Menu.MENU_116-BPM-FULL.ogg",
           loop: true
        );


        /// <summary>
        /// Main battle music loop
        /// </summary>
        public BaseAudioClip MX_BATTLE_LOOP = new SimpleAudioClip(
           filePath: "Game.AudioFiles.Music.Battle.BATTLE_142-BPM-LOOP.wav",
           loop: true
        );

        /// <summary>
        /// Long version of the Battle music loop
        /// </summary>
        public BaseAudioClip MX_BATTLE_FULL = new SimpleAudioClip(
           filePath: "Game.AudioFiles.Music.Battle.BATTLE_142-BPM-FULL.ogg",
           loop: true
        );

        public BaseAudioClip SFX_BATTLE_PLAYER_ATTACK_HIT = new SimpleAudioClip(
            filePath: "Game.AudioFiles.SFX.Battle.General.Player_Attack_Hit.wav",
            loop: false
        );

        public BaseAudioClip SFX_BATTLE_PLAYER_ATTACK_MISS = new SimpleAudioClip(
            filePath: "Game.AudioFiles.SFX.Battle.General.Player_Attack_Miss.wav",
            loop: false
        );
        public BaseAudioClip SFX_BATTLE_PLAYER_DEATH = new SimpleAudioClip(
            filePath: "Game.AudioFiles.SFX.Battle.General.Player_Death.wav",
            loop: false
        );

        /// <summary>
        /// All AudioClips are added to this list for use in loading
        /// and setting up volume busses
        /// </summary>
        public List<BaseAudioClip> AudioClips;

    }
}