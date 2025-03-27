namespace APBD.Core.Devices
{
    /// <summary>
    /// Represents a smartwatch device with battery level and power control.
    /// </summary>
    public class Smartwatch : Device
    {
        /// <summary>
        /// Gets the current battery level of the smartwatch.
        /// </summary>
        public int BatteryLevel { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Smartwatch class.
        /// </summary>
        /// <param name="id">The unique identifier of the device.</param>
        /// <param name="name">The name of the smartwatch.</param>
        /// <param name="isEnabled">Indicates whether the device is turned on.</param>
        /// <param name="batteryLevel">The initial battery level of the smartwatch.</param>
        public Smartwatch(string id, string name, bool isEnabled, int batteryLevel) 
            : base(id, name, isEnabled)
        {
            BatteryLevel = batteryLevel;
        }

        /// <summary>
        /// Turns on the smartwatch if the battery level is sufficient.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the battery is too low to power on.</exception>
        public override void TurnOn()
        {
            if (BatteryLevel < 10) throw new InvalidOperationException("Battery too low");
            base.TurnOn();
            BatteryLevel -= 5;
        }

        /// <summary>
        /// Returns a string representation of the smartwatch state.
        /// </summary>
        /// <returns>A formatted string with device status and battery level.</returns>
        public override string ToString() => 
            $"Smartwatch {Name} ({Id}) - {(IsEnabled ? "ON" : "OFF")}, Battery: {BatteryLevel}%";
    }
}