using System.IO;
using System.Reflection;

namespace Game.Helpers
{
    class ResourceFileHelpers
    {
        /// <summary>
        /// Gets a stream for a resource file 
        /// The file must have been added to visual studio, and 
        /// the file's "build action" property should be "resource file"
        /// </summary>
        /// <param name="filename">
        /// Relative filepath of the sound file from the solution root.
        /// String provided should have '/' replaced with  '.' for directories, 
        /// e.g. Game/Files/Beep.wav, pass in "Game.AudioFiles.ButtonClickTest.wav
        /// </param>
        /// <returns>
        /// A System.IO.Stream object, if file is found and loaded
        /// </returns>
        /// TODO add error handling or document exceptions thrown
        public static Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(filename);
            return stream;
        }
    }
}
