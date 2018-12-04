using Random.PinGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Random.PinGenerator
{
    public class PinPolicies : IPinPolicies
    {
        private IList<Func<string, bool>> GetPolicies()
        {
            return  new List<Func<string, bool>>
            {
                HasIncrementalSequence,
                HasConsecutiveSequence,
                // We can add policies here
            };
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

        // DRY Issues here "HasDecrementalSequence" and "HasIncrementalSequence", maybe refactor 
        public bool HasDecrementalSequence(string pin)
        {
            for (int i = 0; i < pin.Length; i++)
            {
                if (i < pin.Length - 1)
                {
                    // We trust the random pin generator to always give a value numeric
                    // Convert char to int
                    int currentIndexvalue = (int)Char.GetNumericValue(pin[i]);
                    int nextIndexValue = (int)Char.GetNumericValue(pin[i + 1]);

                    // Decrements: If current character - 1 matches with next 
                    if ((currentIndexvalue - 1) == (nextIndexValue))
                        return true;
                }
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
                    // Increments
                    if ((currentIndexvalue + 1) == (nextIndexValue))
                        return true;
                }
            }
            return false;
        }

        public bool Validate(string pin)
        {
            var policies = GetPolicies();

            // if we have no policies to assert , then truen true
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

        IList<Func<string, bool>> IPinPolicies.GetPolicies()
        {
            return new List<Func<string, bool>>
            {
                HasConsecutiveSequence,
                HasIncrementalSequence
            };
        }
    }
}
