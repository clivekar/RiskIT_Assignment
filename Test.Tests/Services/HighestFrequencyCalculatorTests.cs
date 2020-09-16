using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Services;

namespace Test.Tests.Services
{
    [TestClass]
    public class HighestFrequencyCalculatorTests
    {
        private HighestFrequencyCalculator _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new HighestFrequencyCalculator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalculateHighestFrequency_InputTextIsEmpty_ThrowsArgumentException()
        {
            var inputText = string.Empty;

            _sut.CalculateHighestFrequency(inputText);
        }

        [TestMethod]
        public void TestCalculateHighestFrequency_ValidInput_ReturnsEqual()
        {
            var inputText = "The sun shines over the lake";

            var sut = _sut.CalculateHighestFrequency(inputText);

            Assert.AreEqual(2, sut);
        }

        [TestMethod]
        public void TestCalculateHighestFrequency_NoDuplicateWords_ReturnsEqual()
        {
            var inputText = "The sun shines today";

            var sut = _sut.CalculateHighestFrequency(inputText);

            Assert.AreEqual(1, sut);
        }

        [TestMethod]
        public void TestCalculateHighestFrequency_FourDuplicateWords_ReturnsEqual()
        {
            var inputText = "The sun shines today over the moon. Tonight the moon shines over the ocean.";

            var sut = _sut.CalculateHighestFrequency(inputText);

            Assert.AreEqual(4, sut);
        }

        [TestMethod]
        public void TestCalculateHighestFrequency_InputTextContainsPunctuation_ReturnsEqual()
        {
            var inputText = "The sun shines today over the moon. : ( | ) ? Tonight the moon shines over the ocean!";

            var sut = _sut.CalculateHighestFrequency(inputText);

            Assert.AreEqual(4, sut);
        }

        [TestMethod]
        public void TestCalculateHighestFrequency_InputTextContainsDifferentLetterCases_ReturnsEqual()
        {
            var inputText = "The sun shines today oVEr thE moon. Tonight THE moon shines over the ocean.";

            var sut = _sut.CalculateHighestFrequency(inputText);

            Assert.AreEqual(4, sut);
        }

        [TestMethod]
        public void TestCalculateHighestFrequency_InputTextContainsNumbers_ReturnsEqual()
        {
            var inputText = "The sun 3333 shines today 4458over the moon. Tonight the moon shines 99999over the ocean.";

            var sut = _sut.CalculateHighestFrequency(inputText);

            Assert.AreEqual(4, sut);
        }

        [TestMethod]
        public void TestCalculateHighestFrequency_InputTextContainsLeadingEndingWhiteSpace_ReturnsEqual()
        {
            var inputText = "    The sun shines today over the moon. Tonight the moon shines over the ocean.     ";

            var sut = _sut.CalculateHighestFrequency(inputText);

            Assert.AreEqual(4, sut);
        }
    }
}
