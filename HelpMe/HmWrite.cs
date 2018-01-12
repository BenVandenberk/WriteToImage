using System.IO;

namespace SchrijvenOpAfbeelding.HelpMe
{
    public class HmWrite
    {
        private static HmWrite single;

        public static HmWrite Single => single ?? (single = new HmWrite());
        private HmWrite() { }

        /// <summary>
        /// Writes a given text to a given file. Overwrites any content that is already present. 
        /// Creates the file if the file does not yet exist.
        /// </summary>
        /// <param name="filePath">The fully qualified filename (absolute path)</param>
        /// <param name="text">The text with which to overwrite the contents of the file</param>
        public void ToFile(string filePath, string text) {
            using (StreamWriter outputFile = new StreamWriter($@"{filePath}")) {
                outputFile.Write(text);
            }
        }
    }
}