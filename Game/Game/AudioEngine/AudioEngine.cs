using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Game.AudioEngine
{
    public class AudioEngine
    {
        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
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
              
    }
}
