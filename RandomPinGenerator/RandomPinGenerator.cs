using PinGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PinGenerator.Service
{
    public class RandomPinGenerator : IRandomPinGenerator
    {
        private IRandomPinService _randomService;

        private Func<string, bool> _hasConsecutiveSequence;
        private Func<string, bool> _hasIncrementalSequence;

        public RandomPinGenerator()
        {
            _randomService = new RandomPinService();
            _hasConsecutiveSequence = _randomService.HasConsecutiveSequence;
            _hasIncrementalSequence = _randomService.HasIncrementalSequence;
        }


        // I have not bootstrapped a DI framework Yet so I will use the default ctor to bootstrap for now
        public RandomPinGenerator(IRandomPinService randomService )
        {
            _randomService = randomService;
            _hasConsecutiveSequence = _randomService.HasConsecutiveSequence;
            _hasIncrementalSequence = _randomService.HasIncrementalSequence;
        }

        public HashSet<string> GetPins(int batchSize)
        {
            var pinHashset = new HashSet<string>();

            while (pinHashset.Count() < batchSize)
            {
                pinHashset.Add(_randomService.GeneratePin(_hasConsecutiveSequence, _hasIncrementalSequence));
            }

            return pinHashset;
        }
    }
}
