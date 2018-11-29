using System;

namespace PinGenerator.Interfaces
{
    public interface IRandomPinService
    {
        string GeneratePin(Func<string, bool> hasConsecutiveSequence, Func<string, bool> hasIncrementalSequence);
        bool HasConsecutiveSequence(string pin);
        bool HasIncrementalSequence(string pin);
    }
}