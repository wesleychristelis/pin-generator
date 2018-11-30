using System;

namespace PinGenerator.Interfaces
{
    public interface IRandomPinService
    {
        string GeneratePin();
        bool HasConsecutiveSequence(string pin);
        bool HasIncrementalSequence(string pin);
        bool HasDecrementalSequence(string pin);
    }
}