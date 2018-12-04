using Random.PinGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Random.PinGenerator.Service
{
    public class RandomPinService : IRandomPinService
    {
        private System.Random _random;
        private IPinPolicies _policies;

        public RandomPinService()
        {
            _random = new System.Random();
            _policies = new PinPolicies();
        }

        // No DI bootstrapped as yet
        public RandomPinService(IPinPolicies policies)
        {
            _random = new System.Random();
            _policies = policies;
        }

        // We could possible add arrays of func to run against
        public string GeneratePin(int pinLength)
        {
            //TODO: Customise pin lentgh
            var pin = _random.Next(0000, 9999).ToString($"D{pinLength}"); // we can make this configurable TODO: Investigate another approach

            if (_policies.Validate(pin))
            {
                return GeneratePin(pinLength);
            }
            else
            {
                return pin;
            }
        }

        // Add max pin combinations
        public int MaxPinCombinations(int pinLength)
        {
            if (pinLength <= 0)
                throw new ArgumentOutOfRangeException(nameof(pinLength));

            var x = (int)Math.Pow(10, pinLength);

            return (int)Math.Pow(10, pinLength);
        }
    }
}
