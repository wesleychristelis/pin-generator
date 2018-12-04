using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random.PinGenerator.Interfaces;
using Random.PinPolicies;

namespace PinPoliciesUnitTests
{
    [TestClass]
    public class PinPolicies_Should
    {
        private IRandomPinPolicies _pinPolicies;

        [TestInitialize]
        public void TestStartUp()
        {
            _pinPolicies = new RandomPinPolicies();
        }

        [DataTestMethod]
        [DataRow("1135")] // first 2 consecutive
        [DataRow("1228")] // middle 2 consecutive
        [DataRow("1399")] // last 2 consecutive
        public void ReturnTrueWithConsecutiveSequencesInPin(string pin)
        {
            // Arrange

            // Act
            var hasConsecutiveDigits = _pinPolicies.HasConsecutiveSequence(pin);

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
            var hasConsecutiveDigits = _pinPolicies.HasConsecutiveSequence(pin);

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
            var hasConsecutiveDigits = _pinPolicies.HasIncrementalSequence(pin);

            // Assert
            Assert.IsTrue(hasConsecutiveDigits, "Pin has incremental values");
        }

        [DataTestMethod]
        [DataRow("4321")] // all increment
        [DataRow("5321")] // first 3 decrement
        [DataRow("5821")] // first 2 decrement
        [DataRow("5431")] // last 3 decrement
        [DataRow("5471")] // last 2 decrement
        public void ReturnTrueWithDecrementalSequencesInPin(string pin)
        {
            // Arrange

            // Act
            var hasConsecutiveDigits = _pinPolicies.HasDecrementalSequence(pin);

            // Assert
            Assert.IsTrue(hasConsecutiveDigits, "Pin has decremental values");
        }

        [DataTestMethod]
        [DataRow("9740")] // no incremental
        [DataRow("0592")]
        [DataRow("1958")]
        [DataRow("2409")]
        [DataRow("9047")]
        public void ReturnFalseWithNoIncrementalSequencesInPin(string pin)
        {
            // Arrange

            // Act
            var hasConsecutiveDigits = _pinPolicies.HasIncrementalSequence(pin);

            // Assert
            Assert.IsFalse(hasConsecutiveDigits, "Pin has no incremental values");
        }

        [TestMethod]
        public void ReturnListOfValidationPolicies()
        {
            // Arrange

            // Act
            var policies = _pinPolicies.GetPolicies();

            // Assert
            Assert.AreEqual(2, policies.Count, "We currenlty have 2 policies");
        }

    }
}
