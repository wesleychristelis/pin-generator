using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinGenerator.Service;
using System;

namespace PinService.Tests
{
    [TestClass]
    public class RandomSpinService_Should
    {
        // Chnage to interface
        private RandomPinService _randomPinService;

        [TestInitialize]
        public void TestStartUp()
        {
            _randomPinService = new RandomPinService();
        }

        [DataTestMethod]
        [DataRow("1135")] // first 2 consecutive
        [DataRow("1228")] // middle 2 consecutive
        [DataRow("1399")] // last 2 consecutive
        public void ReturnTrueWithConsecutiveSequencesInPin(string pin)
        {
            // Arrange

            // Act
            var hasConsecutiveDigits = _randomPinService.HasConsecutiveSequence(pin);

            // Assert
            Assert.IsTrue(hasConsecutiveDigits, "Pin has  consecutive values");
        }

        [DataTestMethod]
        [DataRow("1367")] // no consecutive
        [DataRow("6848")] // no consecutive
        [DataRow("9035")] // no consecutive
        public void ReturnFalseWithNoConsecutiveSequencesInPin(string pin)
        {
            // Arrange

            // Act
            var hasConsecutiveDigits = _randomPinService.HasConsecutiveSequence(pin);

            // Assert
            Assert.IsFalse(hasConsecutiveDigits, "Pin has no consecutive values");
        }

        [DataTestMethod]
        [DataRow("1234")] // all increment
        [DataRow("1235")] // first 3 increment
        [DataRow("1285")] // first 2 increment
        [DataRow("1345")] // last 3 increment
        [DataRow("1745")] // last 2 increment
        public void ReturnTrueWithIncrementalSequencesInPin(string pin)
        {
            // Arrange

            // Act
            var hasConsecutiveDigits = _randomPinService.HasIncrementalSequence(pin);

            // Assert
            Assert.IsTrue(hasConsecutiveDigits, "Pin has incremental values");
        }

        [DataTestMethod]
        [DataRow("9740")] // no incremental
        [DataRow("0592")] 
        [DataRow("1058")] 
        [DataRow("2436")] 
        [DataRow("9047")] 
        public void ReturnFalseWithNoIncrementalSequencesInPin(string pin)
        {
            // Arrange

            // Act
            var hasConsecutiveDigits = _randomPinService.HasIncrementalSequence(pin);

            // Assert
            Assert.IsFalse(hasConsecutiveDigits, "Pin has no incremental values");
        }

        [TestMethod]
        public void ReturnValidPin()
        {
            // Arrange
            Func<string, bool> func1 = _randomPinService.HasConsecutiveSequence;
            Func<string, bool> func2 = _randomPinService.HasIncrementalSequence;

            // Act: We can mock the Func<> params
            var result = _randomPinService.GeneratePin(func1, func2);

            // Assert
            Assert.IsNotNull(result, "We must have a pin");
            Assert.IsTrue(result.Length == 4, "Pin must be 4 digits");
        }
    }
}
