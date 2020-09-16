using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Test.Services
{
    public class WordsFrequenciesBase
    {
        protected bool IsInputTextNullOrEmpty(string inputText)
        {
            return string.IsNullOrEmpty(inputText);
        }

        /// <summary>
        /// Returns a list of words given a sentence. Ignoring punctuation and non-characters
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        protected IEnumerable<string> ExtractWordsFromText(string inputText)
        {
            try
            {
                return Regex.Matches(inputText.ToLowerInvariant(), @"([a-zA-Z]+)").Cast<Match>().Select(match => match.Value).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
