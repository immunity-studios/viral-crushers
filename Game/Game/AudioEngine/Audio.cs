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
    /// Class that provides playback controls for a specified audio file
    /// 
    /// TODO add proper C# getter/setter syntax
    /// see https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
    /// </summary>
    class AudioClip
    {

        /// <summary>
        /// Constructs an Audio Clip for a specified sound file with provided settings
        ///
        /// </summary>
        /// <param name="filepath">
        /// Relative filepath of the sound file from the solution root.
        /// String provided should have '/' replaced with  '.' for directories
        /// </param>
        /// <param name="loop"></param>
        public AudioClip(string filepath, bool loop = false)
        {
            this.filepath = filepath;
            player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            player.Loop = loop;
            Load();
        }
        
        public void Play()
        {
            player.Play();
        }
     
        public void Stop()
        {
            player.Stop();
        }
        private void Load()
        {
            player.Load(GetStreamFromFile(filepath));
        }


        /// <summary>
        /// Gets a stream for a resource file 
        /// The file must have been added to visual studio and 
        /// file properties set to resource file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(filename);
            return stream;
        }

        /// <summary>
        /// the audio file path
        /// </summary>
        private string filepath;

        /// <summary>
        /// the audio file's player
        /// </summary>
        private ISimpleAudioPlayer player;
        
    }

}
