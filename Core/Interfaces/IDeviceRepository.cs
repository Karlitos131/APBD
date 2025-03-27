namespace APBD.Core.Interfaces
{
    using APBD.Core.Devices;

    /// <summary>
    /// Defines operations for storing and retrieving devices.
    /// </summary>
    public interface IDeviceRepository
    {
        /// <summary>
        /// Adds a new device to the repository.
        /// </summary>
        /// <param name="device">The device to be added.</param>
        void Add(Device device);

        /// <summary>
        /// Retrieves all devices currently stored in the repository.
        /// </summary>
        /// <returns>An enumerable collection of devices.</returns>
        IEnumerable<Device> GetAll();
    }
}