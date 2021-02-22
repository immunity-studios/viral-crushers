﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game.AudioSystem
{
    /// <summary>
    /// Class that manages the game sounds that are used by the AudioEngine 
    /// </summary>
    public class AudioResources
    {
        /// <summary>
        /// Constructor which adds all BaseAudioClip members to the AudioClips list
        /// </summary>
        public AudioResources()
        {
            AudioClips = new List<BaseAudioClip>() {
                MENU_CLICK_SOUND,
                MX_MENU_SONG1_FULL_LOOP,
                MX_BATTLE_LOOP,
                MX_MENU_FULL,
                MX_BATTLE_FULL
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

        /// <summary>
        /// All AudioClips are added to this list for use in loading
        /// and setting up volume busses
        /// </summary>
        public List<BaseAudioClip> AudioClips;

    }
}