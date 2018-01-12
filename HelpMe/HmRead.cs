using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchrijvenOpAfbeelding.HelpMe
{
    public class HmRead
    {
        private static HmRead single;

        public static HmRead Single => single ?? (single = new HmRead());

        private HmRead() { }

        /// <summary>
        /// Reads the contents of a given file.
        /// </summary>
        /// <param name="filePath">The fully qualified filename (absolute path)</param>
        /// <returns></returns>
        public string TextFromFile(string filePath) {
            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Splits the given text into chunks delimited by the given delimiter.
        /// </summary>
        /// <param name="text">The text to split</param>
        /// <param name="delimiter">The delimiter by which the chunks are delimited</param>
        /// <returns></returns>
        public List<string> DelimitedText(string text, string delimiter) {
            return text.Split(delimiter.ToCharArray()).ToList();
        }
    }
}