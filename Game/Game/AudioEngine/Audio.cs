using System.IO;
using System.Reflection;
using Plugin.SimpleAudioPlayer;

namespace Game
{
    /// <summary>
    /// Collection of game sounds that are loaded at compilation time.
    /// TODO trigger menu click sounds via an inherited menu class
    /// with preset button handlers (get rid of globals)
    /// </summary>
    class AudioConstants
    {   
        /// <summary>
        /// Default menu click sound
        /// </summary>
        public static AudioClip MENU_CLICK_SOUND = new AudioClip("Game.AudioFiles.SFX.Menu.ButtonClickTest.wav");
    }


    /// <summary>
    /// Class which manages loading, setup, 
    /// playback, and sound settings for an audio file player
    /// </summary>
    public class AudioClip //: AudioBus // TODO implement AudioBus
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
        public AudioClip(string filepath, bool loop = false, double startingVolume = 1.0)
        {
            // Set class fields
            this.filepath = filepath;
            // Setup sound player
            player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            player.Loop = loop;
            player.Volume = startingVolume;
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
        /// The audio file player
        /// </summary>
        private ISimpleAudioPlayer player;

        /// <summary>
        /// The audio file's relative path from the solution folder
        /// </summary>
        private string filepath;

       
        
    }
}
