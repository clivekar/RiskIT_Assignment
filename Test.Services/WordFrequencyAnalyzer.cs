using System.Collections.Generic;

namespace Test.Services
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {
        public int CalculateHighestFrequency(string text)
        {
            return new HighestFrequencyCalculator().CalculateHighestFrequency(text);
        }

        public int CalculateFrequencyForWord(string text, string word)
        {
            return new WordFrequencyCalculator().CalculateFrequencyForWord(text, word);
        }

        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {
            return new MostFrequentNWordsCalculator().CalculateMostFrequentNWords(text, n);
        }
    }
}
