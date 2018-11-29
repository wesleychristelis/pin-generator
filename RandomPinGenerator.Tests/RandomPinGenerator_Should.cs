using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinGenerator.Service;
using System.Collections.Generic;
using System.Linq;

namespace RandomPinGeneratorUnitTests
{
    [TestClass]
    public class RandomPinGenerator_Should
    {
        private RandomPinGenerator _randomPinGenerator;

        [TestInitialize]
        public void TestStartUp()
        {
            _randomPinGenerator = new RandomPinGenerator();
        }

        [TestMethod]
        public void ReturnBatchSizeOfPins()
        {
            // Arrange
            var batchSize = 1000;

            // Act
            var pinHash = _randomPinGenerator.GetPins(batchSize);

            // Assert
            Assert.AreEqual(batchSize, pinHash.Count());
            Assert.IsInstanceOfType(pinHash, typeof(HashSet<string>));
        }
    }
}
