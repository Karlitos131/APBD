using APBD.Core.Devices;
using APBD.Core.Devices;

/// <summary>
/// Defines a parser for converting input strings into device objects.
/// </summary>
namespace APBD.Core.Interfaces
{
    public interface IDeviceParser
    {
        /// <summary>
        /// Parses a string line and returns a corresponding device instance.
        /// </summary>
        /// <param name="line">The input string representing a device.</param>
        /// <returns>A parsed Device object.</returns>
        Device Parse(string line);
    }
}