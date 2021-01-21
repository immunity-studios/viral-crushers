﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game.AudioEngine
{
    /// <summary>
    /// Collection of game sounds that are loaded at compilation time.
    /// TODO trigger menu click sounds via an inherited menu class
    /// with preset button handlers (get rid of globals)
    /// </summary>
    public class AudioResources
    {
        /// <summary>
        /// Default menu click sound
        /// </summary>
        public static AudioClip MENU_CLICK_SOUND = new AudioClip(
            filepath: "Game.AudioFiles.Music.Menu.TestMX1_Stinger_Bells.wav",
            startingVolume: .5
        );

        public static AudioClip MENU_MUSIC2_LOOP = new AudioClip(
            filepath: "Game.AudioFiles.Music.Menu.TestMX2_Loop_Full.wav",
            startingVolume: .8,
            loop: true
        );

    
        private static AudioClip MENU_MUSIC1_LOOP_LAYER1 = new AudioClip(
            filepath: "Game.AudioFiles.Music.Menu.TestMX1_Loop_Layer1.wav",
            startingVolume: .8,
            loop: true
        );

        public static AudioClip MENU_MUSIC1_LOOP_LAYER2 = new AudioClip(
            filepath: "Game.AudioFiles.Music.Menu.TestMX1_Loop_Layer2.wav",
            startingVolume: .8,
            loop: true
        );

        public static AudioClip MENU_MUSIC1_LOOP_LAYER3 = new AudioClip(
            filepath: "Game.AudioFiles.Music.Menu.TestMX1_Loop_Layer3.wav",
            startingVolume: .8,
            loop: true
        );

        public static MusicContainer MENU_MUSIC1 = new MusicContainer(new List<AudioClip>(){
            MENU_MUSIC1_LOOP_LAYER1,
            MENU_MUSIC1_LOOP_LAYER2,
            MENU_MUSIC1_LOOP_LAYER3
        });

    }
}
