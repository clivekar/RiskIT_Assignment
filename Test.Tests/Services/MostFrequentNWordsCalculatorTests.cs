using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Services;

namespace Test.Tests.Services
{
    [TestClass]
    public class MostFrequentNWordsCalculatorTests
    {
        private MostFrequentNWordsCalculator _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new MostFrequentNWordsCalculator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalculateMostFrequentNWords_InputTextIsEmpty_ThrowsArgumentException()
        {
            var inputText = string.Empty;

            _sut.CalculateMostFrequentNWords(inputText, 3);
        }

        [TestMethod]
        public void TestCalculateMostFrequentNWords_InputNumberIsZero_ReturnsEqual()
        {
            var inputText = "The sun shines over the lake";

            var sut = _sut.CalculateMostFrequentNWords(inputText, 0);

            Assert.AreEqual(0, sut.Count());
        }

        [TestMethod]
        public void TestCalculateMostFrequentNWords_ValidInput_ReturnsEqual()
        {
            var inputText = "The sun shines over the lake";

            var sut = _sut.CalculateMostFrequentNWords(inputText, 3);

            Assert.AreEqual(3, sut.Count());
            Assert.AreEqual("the", sut[0].Word);
            Assert.AreEqual(2, sut[0].Frequency);
            Assert.AreEqual("lake", sut[1].Word);
            Assert.AreEqual(1, sut[1].Frequency);
            Assert.AreEqual("over", sut[2].Word);
            Assert.AreEqual(1, sut[2].Frequency);
        }

        [TestMethod]
        public void TestCalculateMostFrequentNWords_ComprehensiveInput_ReturnsEqual()
        {
            var inputText = "Water and debris was leaking out the hole in the roof. The hole was small and we managed to patch the hole";

            var sut = _sut.CalculateMostFrequentNWords(inputText, 9);

            Assert.AreEqual(9, sut.Count());
            Assert.AreEqual("the", sut[0].Word);
            Assert.AreEqual(4, sut[0].Frequency);
            Assert.AreEqual("hole", sut[1].Word);
            Assert.AreEqual(3, sut[1].Frequency);
            Assert.AreEqual("and", sut[2].Word);
            Assert.AreEqual(2, sut[2].Frequency);
            Assert.AreEqual("was", sut[3].Word);
            Assert.AreEqual(2, sut[3].Frequency);
            Assert.AreEqual("debris", sut[4].Word);
            Assert.AreEqual(1, sut[4].Frequency);
            Assert.AreEqual("in", sut[5].Word);
            Assert.AreEqual(1, sut[5].Frequency);
            Assert.AreEqual("leaking", sut[6].Word);
            Assert.AreEqual(1, sut[6].Frequency);
            Assert.AreEqual("managed", sut[7].Word);
            Assert.AreEqual(1, sut[7].Frequency);
            Assert.AreEqual("out", sut[8].Word);
            Assert.AreEqual(1, sut[8].Frequency);
        }

        [TestMethod]
        public void TestCalculateMostFrequentNWords_InputWithNoDuplicateWords_ReturnsEqual()
        {
            var inputText = "The sun shines over a lake. It looks stunning";

            var sut = _sut.CalculateMostFrequentNWords(inputText, 5);

            Assert.AreEqual(5, sut.Count());
            Assert.AreEqual("a", sut[0].Word);
            Assert.AreEqual(1, sut[0].Frequency);
            Assert.AreEqual("it", sut[1].Word);
            Assert.AreEqual(1, sut[1].Frequency);
            Assert.AreEqual("lake", sut[2].Word);
            Assert.AreEqual(1, sut[2].Frequency);
            Assert.AreEqual("looks", sut[3].Word);
            Assert.AreEqual(1, sut[3].Frequency);
            Assert.AreEqual("over", sut[4].Word);
            Assert.AreEqual(1, sut[4].Frequency);
        }

        [TestMethod]
        public void TestCalculateMostFrequentNWords_InputTextContainsPunctuation_ReturnsEqual()
        {
            var inputText = "The sun shines over a lake. ( | ) ? It looks stunning!!!!";

            var sut = _sut.CalculateMostFrequentNWords(inputText, 5);

            Assert.AreEqual(5, sut.Count());
            Assert.AreEqual("a", sut[0].Word);
            Assert.AreEqual(1, sut[0].Frequency);
            Assert.AreEqual("it", sut[1].Word);
            Assert.AreEqual(1, sut[1].Frequency);
            Assert.AreEqual("lake", sut[2].Word);
            Assert.AreEqual(1, sut[2].Frequency);
            Assert.AreEqual("looks", sut[3].Word);
            Assert.AreEqual(1, sut[3].Frequency);
            Assert.AreEqual("over", sut[4].Word);
            Assert.AreEqual(1, sut[4].Frequency);
        }

        [TestMethod]
        public void TestCalculateMostFrequentNWords_InputTextContainsDifferentLetterCases_ReturnsEqual()
        {
            var inputText = "ThE sun shines over A lake. It looKS stunning";

            var sut = _sut.CalculateMostFrequentNWords(inputText, 5);

            Assert.AreEqual(5, sut.Count());
            Assert.AreEqual("a", sut[0].Word);
            Assert.AreEqual(1, sut[0].Frequency);
            Assert.AreEqual("it", sut[1].Word);
            Assert.AreEqual(1, sut[1].Frequency);
            Assert.AreEqual("lake", sut[2].Word);
            Assert.AreEqual(1, sut[2].Frequency);
            Assert.AreEqual("looks", sut[3].Word);
            Assert.AreEqual(1, sut[3].Frequency);
            Assert.AreEqual("over", sut[4].Word);
            Assert.AreEqual(1, sut[4].Frequency);
        }

        [TestMethod]
        public void TestCalculateMostFrequentNWords_InputTextContainsNumbers_ReturnsEqual()
        {
            var inputText = "The sun shines over a lake 6 times. It looks stunning 44458";

            var sut = _sut.CalculateMostFrequentNWords(inputText, 5);

            Assert.AreEqual(5, sut.Count());
            Assert.AreEqual("a", sut[0].Word);
            Assert.AreEqual(1, sut[0].Frequency);
            Assert.AreEqual("it", sut[1].Word);
            Assert.AreEqual(1, sut[1].Frequency);
            Assert.AreEqual("lake", sut[2].Word);
            Assert.AreEqual(1, sut[2].Frequency);
            Assert.AreEqual("looks", sut[3].Word);
            Assert.AreEqual(1, sut[3].Frequency);
            Assert.AreEqual("over", sut[4].Word);
            Assert.AreEqual(1, sut[4].Frequency);
        }

        [TestMethod]
        public void TestCalculateMostFrequentNWords_InputTextContainsLeadingEndingWhiteSpace_ReturnsEqual()
        {
            var inputText = "    The sun shines over a lake. It looks stunning     ";

            var sut = _sut.CalculateMostFrequentNWords(inputText, 5);

            Assert.AreEqual(5, sut.Count());
            Assert.AreEqual("a", sut[0].Word);
            Assert.AreEqual(1, sut[0].Frequency);
            Assert.AreEqual("it", sut[1].Word);
            Assert.AreEqual(1, sut[1].Frequency);
            Assert.AreEqual("lake", sut[2].Word);
            Assert.AreEqual(1, sut[2].Frequency);
            Assert.AreEqual("looks", sut[3].Word);
            Assert.AreEqual(1, sut[3].Frequency);
            Assert.AreEqual("over", sut[4].Word);
            Assert.AreEqual(1, sut[4].Frequency);
        }
    }
}
