﻿using Random.PinGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Random.PinGenerator.Service
{
    public class RandomPinService : IRandomPinService
    {
        private readonly System.Random _random = new System.Random();
        private IPinPolicies _policies;

        public RandomPinService()
        {
            _policies = new PinPolicies();
        }

        // No DI bootstrapped as yet
        public RandomPinService(IPinPolicies policies)
        {
            _policies = policies;
        }

        // We could possible add arrays of func to run against
        public string GeneratePin(int pinLength)
        {
            var pin = _random.Next(0, GetMaxRangeForRandom(pinLength)).ToString($"D{pinLength}");

            if (_policies.Validate(pin))
            {
                // Risk of Recursiveness, the larger the batch size the longer it can take as more unique pins will be present as the set grows, 
                // as a result we will be recursing more often
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

       private int GetMaxRangeForRandom(int pinLength)
        {
            var maxRangeString = new StringBuilder();

            for (int i = 0; i < pinLength; i++)
            {
                maxRangeString.Append("9");
            }

            var maxRange = Convert.ToInt32(maxRangeString.ToString());

            return maxRange;
        }

    }
}
