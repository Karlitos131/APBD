namespace APBD.Core.Services
{
    /// <summary>
    /// Stores and manages the list of added devices.
    /// </summary>
    public class DeviceRepository : IDeviceRepository
    {
        private readonly List<Device> _devices = new();

        /// <summary>
        /// Adds a device to the repository, ensuring no duplicates.
        /// </summary>
        /// <param name="device">The device to add.</param>
        public void Add(Device device)
        {
            if (_devices.Any(d => d.Id == device.Id))
                throw new ArgumentException($"Device {device.Id} already exists");
            _devices.Add(device);
        }

        /// <summary>
        /// Returns all devices stored in the repository.
        /// </summary>
        /// <returns>An enumerable of all stored devices.</returns>
        public IEnumerable<Device> GetAll() => _devices.AsReadOnly();
    }
}