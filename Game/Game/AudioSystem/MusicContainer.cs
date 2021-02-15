using System;
using System.Collections.Generic;
using System.Text;

namespace Game.AudioSystem
{
    /// <summary>
    /// Class which manages playback for a multi-layer, multi-audio file song.
    /// </summary>
    public class MusicContainer
    {
        /// <summary>
        /// Constructor that creates a music containers using provided audio layers.
        /// </summary>
        /// <param name="layers">
        /// A list of looping audio files that should be played in sync.
        /// </param>
        public MusicContainer(List<AudioClip> layers)
        {
            this.layers = layers;
        }

        /// <summary>
        /// Starts playback for the music container.
        /// </summary>
        public void Play()
        {
            foreach (AudioClip clip in layers)
            {
                clip.Play();
            }
        }

        /// <summary>
        /// List of audio clips that play in sync.
        /// </summary>
        private List<AudioClip> layers;

        // TODO
        // public void Stop();
        // public void SetLayerVolume(int layer);
    }
}
