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
        public static AudioClip MENU_CLICK_SOUND = new AudioClip(
            filepath: "Game.AudioFiles.SFX.Menu.UI_CLICK_1.wav",
            startingVolume: .5
        );

        public static AudioClip MX_MENU_SONG1_FULL_LOOP = new AudioClip(
           filepath: "Game.AudioFiles.Music.Menu.VC-OST_Song1_Full_Loop.mp3",
           startingVolume: .8,
           loop: true
        );

        /// <summary>
        /// All AudioClips should be added to this list for use in loading
        /// and setting up volume busses
        /// </summary>
        public static List<AudioClip> AudioClips = new List<AudioClip>() { 
            MENU_CLICK_SOUND, 
            MX_MENU_SONG1_FULL_LOOP
        };
      
    }
}