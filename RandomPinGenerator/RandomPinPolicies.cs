using Random.PinGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Random.PinGenenrator.Policies
{
    public class RandomPinPolicies : IRandomPinPolicies
    {
        public IList<Func<string, bool>> GetPolicies()
        {
            return new List<Func<string, bool>>
            {
                HasIncrementalSequence,
                HasConsecutiveSequence,
                // We can add policies here
            };
        }

        /// <summary>
        /// Return true if pin has consecutive values
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public bool HasConsecutiveSequence(string pin)
        {
            for (int i = 0; i < pin.Length; i++)
            {
                // If current character matches with next 
                // the pin increments
                if (i < pin.Length - 1 && pin[i] == pin[i + 1])
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Return true if pin has inremental values
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
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
                    // the number Increments
                    if ((currentIndexvalue + 1) == (nextIndexValue))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// We return true if any policies have been met
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public bool Validate(string pin)
        {
            var policies = GetPolicies();

            // If we have no policies to assert , then return false.
            // We have no contraints on the numbers generated
            if (policies == null || !policies.Any())
            {
                return false;
            }

            foreach (var policy in policies)
            {
                var result = policy.Invoke(pin);

                if (result)
                    return true;
            }

            return false;
        }
    }
}
