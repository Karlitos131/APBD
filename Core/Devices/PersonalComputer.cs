namespace APBD.Core.Devices
{
    /// <summary>
    /// Represents a personal computer device that must have an operating system to turn on.
    /// </summary>
    public class PersonalComputer : Device
    {
        /// <summary>
        /// Gets the operating system installed on the personal computer.
        /// </summary>
        public string? OperatingSystem { get; }

        /// <summary>
        /// Initializes a new instance of the PersonalComputer class.
        /// </summary>
        /// <param name="id">The unique identifier of the device.</param>
        /// <param name="name">The name of the personal computer.</param>
        /// <param name="isEnabled">Indicates whether the device is turned on.</param>
        /// <param name="os">The operating system installed on the device.</param>
        public PersonalComputer(string id, string name, bool isEnabled, string? os) 
            : base(id, name, isEnabled)
        {
            OperatingSystem = os;
        }

        /// <summary>
        /// Turns on the personal computer if an operating system is installed.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when no operating system is installed.</exception>
        public override void TurnOn()
        {
            if (string.IsNullOrEmpty(OperatingSystem))
                throw new InvalidOperationException("No operating system installed");
            base.TurnOn();
        }

        /// <summary>
        /// Returns a string representation of the personal computer state.
        /// </summary>
        /// <returns>A formatted string with device status and operating system.</returns>
        public override string ToString() => 
            $"PC {Name} ({Id}) - {(IsEnabled ? "ON" : "OFF")}, OS: {OperatingSystem ?? "None"}";
    }
}