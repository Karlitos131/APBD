namespace APBD{
public class DeviceRepository : IDeviceRepository
{
    private readonly List<Device> _devices;
    private const int MaxCapacity = 15;

    public DeviceRepository()
    {
        _devices = new List<Device>(MaxCapacity);
    }

    public void Add(Device device)
    {
        if (_devices.Any(d => d.Id.Equals(device.Id)))
            throw new ArgumentException($"Device with ID {device.Id} already exists");

        if (_devices.Count >= MaxCapacity)
            throw new InvalidOperationException("Device storage is full");

        _devices.Add(device);
    }

    public void Update(Device device)
    {
        var index = _devices.FindIndex(d => d.Id.Equals(device.Id));
        if (index == -1)
            throw new ArgumentException($"Device with ID {device.Id} not found");

        if (_devices[index].GetType() != device.GetType())
            throw new ArgumentException($"Type mismatch for device {device.Id}");

        _devices[index] = device;
    }

    public void Remove(string deviceId)
    {
        var device = _devices.FirstOrDefault(d => d.Id.Equals(deviceId)) ?? 
            throw new ArgumentException($"Device with ID {deviceId} not found");
        _devices.Remove(device);
    }

    public Device? GetById(string deviceId) => _devices.FirstOrDefault(d => d.Id.Equals(deviceId));

    public IEnumerable<Device> GetAll() => _devices.AsReadOnly();
}
}