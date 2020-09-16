using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Test.Services;

namespace Test.Tests.Services
{
    [TestClass]
    public class WordFrequencyCalculatorTests
    {
        private WordFrequencyCalculator _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new WordFrequencyCalculator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalculateFrequencyForWord_InputTextIsEmpty_ThrowsArgumentException()
        {
            var inputText = string.Empty;
            var inputWord = "The";

            _sut.CalculateFrequencyForWord(inputText, inputWord);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalculateFrequencyForWord_WordIsEmpty_ThrowsArgumentExceptionException()
        {
            var inputText = "The sun shines over the lake";
            var inputWord = string.Empty;

            _sut.CalculateFrequencyForWord(inputText, inputWord);
        }

        [TestMethod]
        public void TestCalculateFrequencyForWord_ValidArguments_ReturnsEqual()
        {
            var inputText = "The sun shines over the lake";
            var inputWord = "The";

            var sut = _sut.CalculateFrequencyForWord(inputText, inputWord);

            Assert.AreEqual(2, sut);
        }

        [TestMethod]
        public void TestCalculateFrequencyForWord_InputTextContainsPunctuation_ReturnsEqual()
        {
            var inputText = "The sun shines over the lake. The effect it has on me I can't explain!";
            var inputWord = "The";

            var sut = _sut.CalculateFrequencyForWord(inputText, inputWord);

            Assert.AreEqual(3, sut);
        }

        [TestMethod]
        public void TestCalculateFrequencyForWord_InputTextContainsDifferentLetterCases_ReturnsEqual()
        {
            var inputText = "The sun shines over thE lake. THE effect it has on me I can't explain!";
            var inputWord = "THe";

            var sut = _sut.CalculateFrequencyForWord(inputText, inputWord);

            Assert.AreEqual(3, sut);
        }

        [TestMethod]
        public void TestCalculateFrequencyForWord_InputTextContainsNumbers_ReturnsEqual()
        {
            var inputText = "The sun shines over the 3334 lake. THE effect it has on me I can't explain!";
            var inputWord = "THe";

            var sut = _sut.CalculateFrequencyForWord(inputText, inputWord);

            Assert.AreEqual(3, sut);
        }

        [TestMethod]
        public void TestCalculateFrequencyForWord_InputTextContainsLeadingEndingWhiteSpace_ReturnsEqual()
        {
            var inputText = "    The sun shines over the 3334 lake. THE effect it has on me I can't explain!     ";
            var inputWord = "THe";

            var sut = _sut.CalculateFrequencyForWord(inputText, inputWord);

            Assert.AreEqual(3, sut);
        }
    }
}
