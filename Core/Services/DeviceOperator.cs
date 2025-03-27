namespace APBD{
public class DeviceOperator : IDeviceOperator
{
    private readonly IDeviceRepository _repository;

    public DeviceOperator(IDeviceRepository repository)
    {
        _repository = repository;
    }

    public void TurnOn(string deviceId)
    {
        var device = _repository.GetById(deviceId) ?? 
            throw new ArgumentException($"Device with ID {deviceId} not found");
        device.TurnOn();
    }

    public void TurnOff(string deviceId)
    {
        var device = _repository.GetById(deviceId) ?? 
            throw new ArgumentException($"Device with ID {deviceId} not found");
        device.TurnOff();
    }
}
}