using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Services
{
    public class MostFrequentNWordsCalculator : WordsFrequenciesBase
    {
        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {
            if (IsInputTextNullOrEmpty(text)) throw new ArgumentException();

            if (n < 1) return new List<IWordFrequency>();

            try
            {
                var individualWords = ExtractWordsFromText(text);
                var mostFrequentWords = new List<IWordFrequency>();

                var groupedOrderedWords = individualWords.GroupBy(words => words)
                    .OrderByDescending(wordCount => wordCount.Count())
                    .ThenBy(ordered => ordered.Key);

                foreach (var groupedOrderedWord in groupedOrderedWords.Take(n))
                {
                    mostFrequentWords.Add(new WordFrequency { Word = groupedOrderedWord.Key, Frequency = groupedOrderedWord.Count() });
                }

                return mostFrequentWords;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
