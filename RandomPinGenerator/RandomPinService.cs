using PinGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PinGenerator.Service
{
    public class RandomPinService : IRandomPinService
    {
        private Random _random;

        public RandomPinService()
        {
            _random = new Random();
        }

        public string GeneratePin(Func<string, bool> hasConsecutiveSequence, Func<string, bool> hasIncrementalSequence)
        {
            var pin = _random.Next(0000, 9999).ToString("D4");

            if (hasConsecutiveSequence(pin) || hasIncrementalSequence(pin))
            {
                return GeneratePin(hasConsecutiveSequence, hasIncrementalSequence);
            }
            else
            {
                return pin;
            }
        }

        public bool HasConsecutiveSequence(string pin)
        {
            for (int i = 0; i < pin.Length; i++)
            {
                // If current character matches with next 
                if (i < pin.Length - 1 && pin[i] == pin[i + 1])
                    return true;
            }
            return false;
        }

        public bool HasIncrementalSequence(string pin)
        {
            for (int i = 0; i < pin.Length; i++)
            {
                if (i < pin.Length - 1)
                {
                    // We trust the random pin generator to always give a value numeric
                    // Convert char to int
                    int currentIndexvalue = (int)Char.GetNumericValue(pin[i]);
                    int nextIndexValue = (int)Char.GetNumericValue(pin[i + 1]);

                    // If current character + 1 matches with next 
                    if ((currentIndexvalue + 1) == (nextIndexValue))
                        return true;
                }
            }
            return false;
        }
    }
}
