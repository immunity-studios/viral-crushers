using System;
using System.Collections.Generic;
using System.Text;

namespace Game.AudioSystem
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
        public static BaseAudioClip MENU_CLICK_SOUND = new SimpleAudioClip(
            filePath: "Game.AudioFiles.SFX.Menu.UI_CLICK_1.wav",
            //volumeMax: 1,
            loop: false
        );

        /// <summary>
        /// Main menu music loop
        /// </summary>
        public static BaseAudioClip MX_MENU_SONG1_FULL_LOOP = new SimpleAudioClip(
           filePath: "Game.AudioFiles.Music.Menu.MENU_116-BPM-LOOP.wav",
           loop: true
        );

        /// <summary>
        /// All AudioClips should be added to this list for use in loading
        /// and setting up volume busses
        /// </summary>
        public static List<BaseAudioClip> AudioClips = new List<BaseAudioClip>() {
            MENU_CLICK_SOUND,
            MX_MENU_SONG1_FULL_LOOP
        };

    }
}