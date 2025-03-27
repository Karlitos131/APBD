namespace APBD.Core.Devices
{
    /// <summary>
    /// Represents the base class for all device types, providing common properties and power control methods.
    /// </summary>
    public abstract class Device
    {
        /// <summary>
        /// Gets the unique identifier of the device.
        /// </summary>
        public string Id { get; }
        
        /// <summary>
        /// Gets the name of the device.
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Indicates whether the device is currently turned on.
        /// </summary>
        public bool IsEnabled { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the Device class.
        /// </summary>
        /// <param name="id">The unique identifier of the device.</param>
        /// <param name="name">The name of the device.</param>
        /// <param name="isEnabled">Indicates whether the device is initially on.</param>
        protected Device(string id, string name, bool isEnabled)
        {
            Id = id;
            Name = name;
            IsEnabled = isEnabled;
        }

        /// <summary>
        /// Turns on the device by setting IsEnabled to true.
        /// </summary>
        public virtual void TurnOn() => IsEnabled = true;
        
        /// <summary>
        /// Turns off the device by setting IsEnabled to false.
        /// </summary>
        public virtual void TurnOff() => IsEnabled = false;
        
        /// <summary>
        /// Returns a string representation of the device.
        /// </summary>
        /// <returns>A string describing the device.</returns>
        public abstract override string ToString();
    }
}