using System.Net;

namespace APBD.Core.Devices
{
    /// <summary>
    /// Represents an embedded device that can only connect to specific networks.
    /// </summary>
    public class Embedded : Device
    {
        /// <summary>
        /// Gets the IP address of the embedded device.
        /// </summary>
        public string IPAddress { get; }
        
        /// <summary>
        /// Gets the name of the network the device is connected to.
        /// </summary>
        public string NetworkName { get; }

        /// <summary>
        /// Initializes a new instance of the Embedded class.
        /// </summary>
        /// <param name="id">The unique identifier of the device.</param>
        /// <param name="name">The name of the device.</param>
        /// <param name="isEnabled">Indicates whether the device is turned on.</param>
        /// <param name="ip">The IP address of the device.</param>
        /// <param name="network">The name of the network the device connects to.</param>
        /// <exception cref="FormatException">Thrown if the IP address format is invalid.</exception>
        public Embedded(string id, string name, bool isEnabled, string ip, string network) 
            : base(id, name, isEnabled)
        {
            if (!IPAddress.TryParse(ip, out _))
                throw new FormatException("Invalid IP address format");
            
            IPAddress = ip;
            NetworkName = network;
        }

        /// <summary>
        /// Turns on the device only if it is connected to an authorized network.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when attempting to connect to an unauthorized network.</exception>
        public override void TurnOn()
        {
            if (NetworkName.Contains("MD Ltd"))
                base.TurnOn();
            else
                throw new InvalidOperationException("Cannot connect to unauthorized network");
        }

        /// <summary>
        /// Returns a string representation of the embedded device status and network info.
        /// </summary>
        /// <returns>A formatted string including device state, IP, and network name.</returns>
        public override string ToString() =>
            $"Embedded {Name} ({Id}) - {(IsEnabled ? "ON" : "OFF")}, IP: {IPAddress}, Network: {NetworkName}";
    }
}