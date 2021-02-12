using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Game.AudioSystem
{
    public class AudioEngine
    {
        #region Singleton

        // Make the AudioEngine a singleton so it only exists one time.
        private static volatile AudioEngine instance;
        private static readonly object syncRoot = new Object();

        public static AudioEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new AudioEngine();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        public AudioEngine()
        {

        }

        public bool ProcessAudioEvent(AudioEngineEventEnum audioEvent)
        {
            switch (audioEvent)
            {
                case AudioEngineEventEnum.Button_GameStart:
                    AudioResources.MENU_CLICK_SOUND.Play();
                    break;

                default: break;
            }
            return true;
        }
    }
}
