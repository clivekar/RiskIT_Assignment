namespace Test
{
    /// <summary>
    /// The word and Frequency of the supplied word
    /// </summary>
    public interface IWordFrequency
    {
        /// <summary>
        /// The word in the supplied text
        /// </summary>
        string Word { get; }
        /// <summary>
        /// The frequency in the word
        /// </summary>
        int Frequency { get; }
    }
}
