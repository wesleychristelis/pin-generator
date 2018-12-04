using System;
using System.Collections.Generic;
using System.Text;

namespace Random.PinGenerator.Interfaces
{
    public interface IPinPolicies
    {
        bool HasConsecutiveSequence(string pin);
        bool HasIncrementalSequence(string pin);
        bool HasDecrementalSequence(string pin);
        IList<Func<string, bool>> GetPolicies();
    }
}
