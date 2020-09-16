using System;
using System.Linq;

namespace Test.Services
{
    public class HighestFrequencyCalculator : WordsFrequenciesBase
    {
        public int CalculateHighestFrequency(string text)
        {
            if (IsInputTextNullOrEmpty(text)) throw new ArgumentException();

            try
            {
                var individualWords = ExtractWordsFromText(text);

                return individualWords.GroupBy(words => words).FirstOrDefault().Count();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}