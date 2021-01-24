using System;
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

        public static AudioClip MX_MENU_SONG1_FULL_LOOP = new AudioClip(
           filepath: "Game.AudioFiles.Music.Menu.VC-OST_Song1_Full_Loop.mp3",
           startingVolume: .8,
           loop: true
       );
    }
}
