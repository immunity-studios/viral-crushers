using System;
using System.Collections.Generic;
using System.Text;

namespace Game.AudioEngine
{
    public class MusicContainer
    {
        public MusicContainer(List<AudioClip> layers)
        {
            this.layers = layers;
        }

        public void Play()
        {
            foreach (AudioClip clip in layers)
            {
                clip.Play();
            }
        }

        private List<AudioClip> layers;
    }
}
