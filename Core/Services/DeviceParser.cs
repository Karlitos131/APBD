using System;

namespace APBD
{
    public class DeviceParser : IDeviceParser
    {
        private const int MinimumRequiredElements = 4;

        public Device ParseDevice(string line, int lineNumber)
        {
            if (line.StartsWith("P-")) return ParsePC(line, lineNumber);
            if (line.StartsWith("SW-")) return ParseSmartwatch(line, lineNumber);
            if (line.StartsWith("ED-")) return ParseEmbedded(line, lineNumber);
            throw new ArgumentException($"Line {lineNumber} is corrupted.");
        }

        public PersonalComputer ParsePC(string line, int lineNumber)
        {
            var infoSplits = line.Split(',');
            if (infoSplits.Length < MinimumRequiredElements)
                throw new ArgumentException($"Corrupted line {lineNumber}");

            return new PersonalComputer(
                infoSplits[0], 
                infoSplits[1], 
                bool.Parse(infoSplits[2]), 
                infoSplits[3]);
        }

        public Smartwatch ParseSmartwatch(string line, int lineNumber)
        {
            var infoSplits = line.Split(',');
            if (infoSplits.Length < MinimumRequiredElements)
                throw new ArgumentException($"Corrupted line {lineNumber}");

            return new Smartwatch(
                infoSplits[0], 
                infoSplits[1], 
                bool.Parse(infoSplits[2]), 
                int.Parse(infoSplits[3].Replace("%", "")));
        }

        public Embedded ParseEmbedded(string line, int lineNumber)
        {
            var infoSplits = line.Split(',');
            if (infoSplits.Length < MinimumRequiredElements + 1)
                throw new ArgumentException($"Corrupted line {lineNumber}");

            return new Embedded(
                infoSplits[0], 
                infoSplits[1], 
                bool.Parse(infoSplits[2]), 
                infoSplits[3], 
                infoSplits[4]);
        }
    }
}