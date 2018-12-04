using System.Collections.Generic;

namespace Random.PinGenerator.Interfaces
{
    public interface IRandomPinGenerator
    {
        HashSet<string> GetPins(int batchSize, int pinLength);
    }
}