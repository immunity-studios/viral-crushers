using System;
using System.Collections.Generic;
using System.Text;

namespace Game.AudioSystem
{   
    /// <summary>
    /// Partial implementation of the AudioClip interface contract
    /// </summary>
    public abstract class BaseAudioClip
    {
        public abstract bool Load();

        public abstract bool Play();

        /// <summary>
        /// Flag which must be internally set to true if implementation of Load() succeeds when called
        /// </summary>
        public bool IsLoaded { get; private set; } = false;

    }
}
