using Random.PinGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Random.PinGenerator.Service
{
    public class RandomPinGenerator : IRandomPinGenerator
    {
        private IRandomPinService _randomPinService;

        public RandomPinGenerator()
        {
            _randomPinService = new RandomPinService();
        }

        // I have not bootstrapped a DI framework Yet so I will use the default ctor to bootstrap for now
        public RandomPinGenerator(IRandomPinService randomService )
        {
            _randomPinService = randomService;
        }

        public HashSet<string> GetPins(int batchSize, int pinLength)
        {
            if (batchSize < _randomPinService.MaxPinCombinations(pinLength))
            {
                var pinHashset = new HashSet<string>();

                while (pinHashset.Count() < batchSize)
                {
                    pinHashset.Add(_randomPinService.GeneratePin(pinLength));
                }

                return pinHashset; 
            }

            throw new ArgumentOutOfRangeException("Batch size exceeds max combinations for pin length");
        }
    }
}
