using System.Collections.Generic;

namespace Test
{
    /// <summary>
    /// Functionality to supply words and frequecies of words given a sentence
    /// </summary>
    public interface IWordFrequencyAnalyzer
    {
        /// <summary>
        /// For the supplied text returns the most frequent word 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        int CalculateHighestFrequency(string text);

        /// <summary>
        /// For the supplied text returns the number of occurrences for a specified word
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        int CalculateFrequencyForWord(string text, string word);

        /// <summary>
        /// For the supplied text returns a list of most frequent words up to a specified number
        /// </summary>
        /// <param name="text"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n);
    }
}
