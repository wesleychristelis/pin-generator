using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random.PinGenerator.Interfaces;
using Random.PinGenerator.Service;
using System;

namespace RandomPinServiceUnitTests
{
    [TestClass]
    public class RandomSpinService_Should
    {
        // Change to interface
        private IRandomPinService _randomPinService;

        [TestInitialize]
        public void TestStartUp()
        {
            _randomPinService = new RandomPinService();
        }

        [TestMethod]
        public void ReturnValidPin()
        {
            // Arrange
            var pinLength = 4;

            // Act: We can mock the Func<> params
            var result = _randomPinService.GeneratePin(pinLength);

            // Assert
            Assert.IsNotNull(result, "We must have a pin");
            Assert.IsTrue(result.Length == 4, "Pin must be 4 digits");
        }

        [TestMethod]
        public void ReturnMaxCombinationForAPinsLength()
        {
            // Arrange
            var pinLength = 4;

            // Act: We can mock the Func<> params
            var result = _randomPinService.MaxPinCombinations(pinLength);

            // Assert
            Assert.AreEqual(10000, result, "Max combinations for 4 digit pin is 10 000");
        }
    }
}
