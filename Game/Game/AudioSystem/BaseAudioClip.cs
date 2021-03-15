using System.Diagnostics;

namespace Game.AudioSystem
{
    /// <summary>
    /// An abstract implementation of an audio clip, this is 
    /// the base audio API used by AudioEngine to play audio.
    /// 
    /// Inheriting class should accept a parameter of bool for Loop property
    /// in the constructor, in addition to params passed to BaseAudioClip
    /// 
    /// TODO (backlog) allow different Audio-Engine minimum/maximum 
    ///                volumes to be used, instead of just 0 - 1.
    /// </summary>
    public abstract class BaseAudioClip
    {
        #region Constructor
        /// <summary>
        /// Base constructor that must be called by the inheriting class
        /// Calls the Setup() method in the sealed inheriting class, 
        /// then sets the value of class members filepath and maxVolume
        /// </summary>
        /// <param name="filepath">
        /// string of relative filepath to the sound file.
        /// Path should be relative from the solution root, 
        /// and should have '/' replaced with  '.' for directories, e.g. 
        /// "Game.AudioFiles.SFX.Menu.ButtonClickTest.wav"
        /// </param>
        /// <param name="maxVolume">
        /// floating point value between 0 and 1 that scales down the volume of the audio clip
        /// Default value: 1 (No volume scaling)
        /// NOTE: for debug purposes only
        /// </param>
        protected BaseAudioClip(string filepath, double maxVolume = 1.0, bool loop = false)
        {
            System.Console.WriteLine("In BaseAudioClip()");
            // Set fields not dependant on implementation first
            MaxVolume = maxVolume;
            Filepath = filepath;
            IsLoop = loop;
            // call inheriting class' implementation
            

        }
        #endregion Constructor

        #region Setup

        /// <summary>
        /// Abstract method that is called in the first line of the BaseAudioClip constructor.
        /// REQUIRED: Implementation must try to initialize the underlying audio API
        /// REQUIRED: Implementation must set the IsSetup bool flag to 'true' if initialization is successful
        /// </summary>
        /// <returns>
        /// true, or false if setup fails
        /// </returns>
        protected abstract bool Setup();

        /// <summary>
        /// Bool flag that represents whether the inheriting class' Setup() method
        /// implementation executed successfully.
        /// Default value = false
        /// REQUIRED: Must be set to 'true' in the inheriting class' Setup method
        /// implementation, if Setup() succeeds.
        /// </summary>
        public bool IsSetup { get; protected set; } = false;

        #endregion Setup

        #region Load

        /// <summary>
        /// Abstract method that loads the audio file. Must be called before playback
        /// </summary>
        /// <returns>
        /// True, or false if fails
        /// </returns>
        public bool Load()
        {
            System.Console.WriteLine("In BaseAudioClip.Load()" );
            if (!IsSetup)
            {
                return false;
            }

            if (!IsLoaded)
            {
                return _Load();
            }
            return true;
        }

        /// <summary>
        /// Abstract method that must load the file in the underlying audio api.
        /// </summary>
        /// <returns></returns>
        protected abstract bool _Load();


        protected bool IsLoaded = false;

        #endregion Load

        #region Play
        /// <summary>
        /// Abstract method which starts playback of the audio asset 
        /// if it is setup and loaded
        /// TODO could add 'fade length' parameter to this method for fade in
        /// </summary>
        /// <returns>
        /// This BaseAudioClip object, or null if it is not setup or not loaded
        /// </returns>
        public BaseAudioClip Play()
        {
            if (!IsSetup || !IsLoaded)
            {
                return null;
            }
            LastPlaybackTimestamp = Stopwatch.GetTimestamp();
            System.Console.WriteLine("Stored playback time of ", LastPlaybackTimestamp);
            _Play();
            return this;
        }


        protected abstract bool _Play();

        #endregion Play

        #region Stop

        /// <summary>
        /// Abstract method which should stop playback of the audio asset
        /// TODO Add 'fade length' parameter to this method for fade out
        /// </summary>
        /// <returns>
        /// true, or false if playback stoppage fails
        /// </returns>
        public bool Stop()
        {
            if (!IsSetup || !IsLoaded)
            {
                return false;
            }

            return _Stop();
        }

        protected abstract bool _Stop();

        #endregion Stop

        #region Volume
        /// <summary>
        /// The current volume of the base audio clip
        /// </summary>
        private double volume = 0;

        /// <summary>
        /// Abstract method that must set the playback volume of the audio asset
        /// Implementation must multiply the passed-parameter volume by the maxVolume
        /// before setting the clip volume.
        /// </summary>
        /// <param name="volume">
        /// Double between 0 and 1 representing the current volume
        /// </param>
        /// <returns>
        /// True, or false if set volume fails
        /// </returns>
        public bool SetVolume(double volume)
        {
            if (!IsSetup || !IsLoaded)
            {
                return false;
            }
            // set the volume field
            this.volume = volume;
            // set the underlying audio API clip's volume
            return _SetVolume(volume);
        }

        /// <summary>
        /// Abstract method that must set the playback volume of the audio asset
        /// Implementation must multiply the passed-parameter volume by the maxVolume
        /// before setting the clip volume.
        /// </summary>
        /// <param name="volume">
        /// Double between 0 and 1 representing the current volume
        /// </param>
        /// <returns>
        /// True, or false if set volume fails
        /// </returns>
        protected abstract bool _SetVolume(double volume);


        /// <summary>
        /// Abstract method that gets the current volume of the underlying audio clip
        /// </summary>
        /// <returns>
        /// Double between 0 and 1 representing the current volume
        /// </returns>
        public double GetVolume()
        {
            if (!IsSetup || !IsLoaded)
            {
                return 0;
            }
            return volume;
        }
        #endregion Volume

        #region Loop

        /// <summary>
        /// Abstract method that must set the clip's playback setting to loop (repeating playback)
        /// </summary>
        /// <param name="loop">
        /// True if audio clip should loop, false if it should only play once
        /// </param>
        /// <returns>
        /// True, or false if set loop fails
        /// </returns>
        public bool SetLoop(bool loop)
        {
            if (!IsSetup)
            {
                return false;
            }
            
            this.IsLoop = loop;
            return _SetLoop(loop);
        }


        protected abstract bool _SetLoop(bool loop);

        /// <summary>
        /// Abstract method that must get the clip's playback setting for loop (repeating playback)
        /// </summary>
        /// <returns>
        /// True if this is a looping audio clip
        /// </returns>
        public bool GetLoop()
        {
            return this.IsLoop;
        }

        // TODO create bool flag for looping, separate from implementation
        protected bool IsLoop = false;



        #endregion Loop

        #region Playback

        /// <summary>
        /// Date/Timestamp formatted long that is set to the current Date/Time
        /// when method Play() is called and the clip has already been setup.
        /// Default value is -1, which means the BaseAudioClip has not yet been set
        /// </summary>
        public long LastPlaybackTimestamp { get; private set; } = -1;

        #endregion Playback


        //#region Rhythmn
        //protected bool IsTempoSynced = false;
        //protected double BPM = 0;
        //#endregion Rhythmn

        #region MaxVolume

        /// <summary>
        /// The max volume of the AudioClip.
        /// Set in the BaseAudioClip constructor
        /// </summary>
        protected double MaxVolume { get; private set; } = 1.0;

        #endregion MaxVolume

        #region Filepath
        /// <summary>
        /// The filepath of the audio clip 
        /// Set in BaseAudioClip constructor
        /// Relative path in form 'Game.AudioFiles.Example.mp3"
        /// </summary>
        public string Filepath { get; }

        #endregion Filepath

    }
}
