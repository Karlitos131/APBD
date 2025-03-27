using APBD.Core.Devices;
using APBD.Core.Interfaces;

namespace APBD.Core.Services
{
    /// <summary>
    /// Parses raw input lines into specific device types based on their identifiers.
    /// </summary>
    public class DeviceParser : IDeviceParser
    {
        /// <summary>
        /// Parses a single input line and returns a corresponding Device object.
        /// </summary>
        /// <param name="line">The input string representing a device.</param>
        /// <returns>A parsed Device instance.</returns>
        public Device Parse(string line)
        {
            var parts = line.Split(',');
            if (parts.Length < 4) throw new FormatException("Invalid device format");

            return parts[0] switch
            {
                string id when id.StartsWith("SW-") => ParseSmartwatch(parts),
                string id when id.StartsWith("P-") => ParsePersonalComputer(parts),
                string id when id.StartsWith("ED-") => ParseEmbedded(parts),
                _ => throw new FormatException("Unknown device type")
            };
        }

        /// <summary>
        /// Parses the data into a Smartwatch object.
        /// </summary>
        /// <param name="parts">String array representing smartwatch fields.</param>
        /// <returns>A Smartwatch device instance.</returns>
        private Smartwatch ParseSmartwatch(string[] parts)
        {
            return new Smartwatch(
                parts[0], 
                parts[1], 
                bool.Parse(parts[2]), 
                int.Parse(parts[3].Trim('%')));
        }

        /// <summary>
        /// Parses the data into a PersonalComputer object.
        /// </summary>
        /// <param name="parts">String array representing personal computer fields.</param>
        /// <returns>A PersonalComputer device instance.</returns>
        private PersonalComputer ParsePersonalComputer(string[] parts)
        {
            return new PersonalComputer(
                parts[0],
                parts[1],
                bool.Parse(parts[2]),
                parts.Length > 3 ? parts[3] : null);
        }

        /// <summary>
        /// Parses the data into an Embedded device object.
        /// </summary>
        /// <param name="parts">String array representing embedded device fields.</param>
        /// <returns>An Embedded device instance.</returns>
        private Embedded ParseEmbedded(string[] parts)
        {
            if (parts.Length < 5) throw new FormatException("Embedded device requires 5 fields");
            return new Embedded(
                parts[0],
                parts[1],
                bool.Parse(parts[2]),
                parts[3],
                parts[4]);
        }
    }
}