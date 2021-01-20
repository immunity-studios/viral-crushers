using Plugin.SimpleAudioPlayer;

namespace Game.AudioEngine
{
    /// <summary>
    /// Class which manages loading and settings, and
    /// gives playback facilities for an audio file player.
    /// </summary>
    public class AudioClip
    {
        /// <summary>
        /// Constructs an Audio Clip for a specified sound file with provided settings
        /// </summary>
        /// <param name="filepath">
        /// Relative filepath of the sound file from the solution root.
        /// String provided should have '/' replaced with  '.' for directories, 
        /// e.g. "Game.AudioFiles.SFX.Menu.ButtonClickTest.wav"
        /// </param>
        /// <param name="loop">
        /// (Default = false) Boolean value for whether this is a looping (repeating) audio clip
        /// If false, it is a 'one-shot'
        /// </param>
        /// <param name="startingVolume">
        /// (Default = 1.0) Floating point volume for the audio clip (range: 0.0 - 1.0)
        /// </param>
        /// TODO decide if AudioClip object should be valid if problem happens when loading file
        /// TODO document types of audio files supported (.WAV, .MP3, etc)
        public AudioClip(string filepath, bool loop = false, double startingVolume = 1.0)
        {
            // Set class fields
            this.filepath = filepath;
            // Setup sound player
            player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            // Settings
            SetLoop(loop);
            SetVolume(startingVolume);
            // Load the audio file as a stream, then load it into the audio player.
            player.Load(Helpers.ResourceFileHelpers.GetStreamFromFile(filepath));
        }
        
        /// <summary>
        /// Plays the audio clip
        /// </summary>
        public void Play()
        {
            player.Play();
        }
     
        /// <summary>
        /// Stops the audio clip
        /// </summary>
        public void Stop()
        {
            player.Stop();
        }

        /// <summary>
        /// Sets the volume of the audio clip
        /// </summary>
        /// <param name="vol">
        /// (Default = 1.0) Floating point volume for the audio clip (range: 0.0 - 1.0)
        /// </param>
        public void SetVolume(double vol)
        {
            player.Volume = vol;
        }

        /// <summary>
        /// Returns the current volume of the audio clip
        /// </summary>
        /// <returns>
        /// Floating point volume of the audio clip (range: 0.0 - 1.0)
        /// </returns>
        public double GetVolume()
        {
            return player.Volume;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// True if the audio clip repeats during playback, false if not
        /// </returns>
        public bool IsLoop()
        {
            return player.Loop;
        }

        /// <summary>
        /// Sets if the audio file should repeat during playback ("loop").
        /// Private access because this setting can only be set during loading.
        /// </summary>
        /// <param name="loop">
        /// True if audio file should continue playback, 
        /// False if audio file should play once.
        /// </param>
        private void SetLoop(bool loop)
        {
            player.Loop = loop;
        }

        /// <summary>
        /// The audio file player
        /// </summary>
        private ISimpleAudioPlayer player;

        /// <summary>
        /// The audio file's relative path from the solution folder
        /// </summary>
        private string filepath;

    }
}
