using System;
using System.Collections.Generic;

namespace Random.PinGenerator.Interfaces
{
    public interface IRandomPinPolicies
    {
        bool HasConsecutiveSequence(string pin);
        bool HasIncrementalSequence(string pin);
        IList<Func<string, bool>> GetPolicies();
        bool Validate(string pin);
    }
}
