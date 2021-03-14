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
        /// Newly added Base Audio Clips must also be added to the AudioClips list
        /// in order to be loaded.
        /// </summary>
        private AudioResources()
        {
            AudioClips = new List<BaseAudioClip>() {
                // new music
                MX_MENU_P1_4XLOOP_4_4_116BPM,
                MX_MENU_P2_4XLOOP_4_4_116BPM,
                MX_MENU_P3_4XLOOP_4_4_116BPM,
                MX_BATTLE_P1_1XLOOP_4_4_140BPM_LONG,
                // end new music

                MENU_CLICK_SOUND,
                MX_MENU_SONG1_FULL_LOOP,
                MX_BATTLE_LOOP,
                MX_MENU_FULL,
                MX_BATTLE_FULL,

                // hackathon SFX
                SFX_BATTLE_PLAYER_ATTACK_HIT,
                SFX_BATTLE_PLAYER_ATTACK_MISS,
                SFX_BATTLE_PLAYER_DEATH
                // end hackathon SFX
            };
        }

        /// <summary>
        /// NEW Intro music
        /// </summary>
        public BaseAudioClip MX_MENU_P1_4XLOOP_4_4_116BPM = new SimpleAudioClip(
            filePath: "Game.AudioFiles.Music.Menu.MX_MENU_P1_4XLOOP_4_4_116BPM.wav",
            loop: true
        );

        /// <summary>
        /// NEW Main part of the menu music. Played when user gets to game page
        /// </summary>
        public BaseAudioClip MX_MENU_P2_4XLOOP_4_4_116BPM = new SimpleAudioClip(
            filePath: "Game.AudioFiles.Music.Menu.MX_MENU_P2_4XLOOP_4_4_116BPM.wav",
            loop: true
        );

        /// <summary>
        /// NEW Escalation of the menu music. Played when user goes to battle page
        /// </summary>
        public BaseAudioClip MX_MENU_P3_4XLOOP_4_4_116BPM = new SimpleAudioClip(
            filePath: "Game.AudioFiles.Music.Menu.MX_MENU_P3_4XLOOP_4_4_116BPM.wav",
            loop: true
        );

        /// <summary>
        /// NEW Battle music that starts when the Battle Map page is reached
        /// </summary>
        public BaseAudioClip MX_BATTLE_P1_1XLOOP_4_4_140BPM_LONG = new SimpleAudioClip(
            filePath: "Game.AudioFiles.Music.Battle.MX_BATTLE_P1_1XLOOP_4_4_140BPM_LONG.wav",
            loop: true
        );



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
        public BaseAudioClip MX_MENU_FULL = new SimpleAudioClip(
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

        /// <summary>
        /// Hackathon SFX #1
        /// </summary>
        public BaseAudioClip SFX_BATTLE_PLAYER_ATTACK_HIT = new SimpleAudioClip(
            filePath: "Game.AudioFiles.SFX.Battle.General.Player_Attack_Hit.wav",
            loop: false
        );

        /// <summary>
        /// Hackathon SFX #2
        /// </summary>
        public BaseAudioClip SFX_BATTLE_PLAYER_ATTACK_MISS = new SimpleAudioClip(
            filePath: "Game.AudioFiles.SFX.Battle.General.Player_Attack_Miss.wav",
            loop: false
        );

        /// <summary>
        /// Hackathon SFX #3
        /// </summary>
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