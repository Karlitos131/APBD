using APBD.Core.Interfaces;
using APBD.Core.Devices;

namespace APBD.Core.Services
{
    /// <summary>
    /// Manages loading and storing of devices using a parser and repository.
    /// </summary>
    public class DeviceManager
    {
        private readonly IDeviceRepository _repository;
        private readonly IDeviceParser _parser;

        /// <summary>
        /// Initializes a new instance of the DeviceManager class.
        /// </summary>
        /// <param name="repository">The device repository instance.</param>
        /// <param name="parser">The device parser instance.</param>
        public DeviceManager(IDeviceRepository repository, IDeviceParser parser) 
        {
            _repository = repository;
            _parser = parser;
        }

        /// <summary>
        /// Loads devices from the specified file, parses each line, and adds them to the repository.
        /// </summary>
        /// <param name="path">The file path to read device data from.</param>
        public void LoadFromFile(string path)
        {
            foreach (var line in File.ReadAllLines(path))
            {
                var device = _parser.Parse(line);
                _repository.Add(device);
            }
        }
    }
}