using PinGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PinGenerator.Service
{
    public class RandomPinGenerator : IRandomPinGenerator
    {
        private IRandomPinService _randomService;

        public RandomPinGenerator()
        {
            _randomService = new RandomPinService();
        }

        // I have not bootstrapped a DI framework Yet so I will use the default ctor to bootstrap for now
        public RandomPinGenerator(IRandomPinService randomService )
        {
            _randomService = randomService;
        }

        public HashSet<string> GetPins(int batchSize)
        {
            var pinHashset = new HashSet<string>();

            while (pinHashset.Count() < batchSize)
            {
                pinHashset.Add(_randomService.GeneratePin(_randomService.HasConsecutiveSequence, _randomService.HasIncrementalSequence));
            }

            return pinHashset;
        }
    }
}
