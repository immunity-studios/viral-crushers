using System;
using System.Collections.Generic;
using System.Text;

namespace Game.AudioSystem
{
    /// <summary>
    /// Enum describing the audio summation busses used by sounds in the project.
    /// </summary>
    public enum AudioBusEnum
    {
        
        Unknown = 0,

        /// <summary>
        /// The main output bus which all audio goes through
        /// </summary>
        Master = 1,

        /// <summary>
        /// Bus for all music 
        /// </summary>
        Music = 5,

        /// <summary>
        /// Bus for all sound effects
        /// </summary>
        SFX = 10
    }
}
