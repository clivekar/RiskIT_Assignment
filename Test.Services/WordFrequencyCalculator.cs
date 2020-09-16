using System;
using System.Linq;

namespace Test.Services
{
    public class WordFrequencyCalculator : WordsFrequenciesBase
    {
        public int CalculateFrequencyForWord(string text, string word)
        {
            if (IsInputTextNullOrEmpty(text)) throw new ArgumentException();

            if (IsInputTextNullOrEmpty(word)) throw new ArgumentException();

            try
            {
                var individualWords = ExtractWordsFromText(text);

                return individualWords.Where(words => words == word.ToLowerInvariant()).Count();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}