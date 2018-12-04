using System;

namespace Random.PinGenerator.Interfaces
{
    public interface IRandomPinService
    {
        string GeneratePin(int pinLength);
        int MaxPinCombinations(int pinLength);
    }
}