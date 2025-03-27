namespace APBD
public class DeviceManager
{
    private readonly IDeviceRepository _repository;
    private readonly IDeviceOperator _operator;
    private readonly IDeviceParser _parser;

    public DeviceManager(IDeviceRepository repository, IDeviceOperator @operator, IDeviceParser parser)
    {
        _repository = repository;
        _operator = @operator;
        _parser = parser;
    }

    public IDeviceRepository GetRepository() => _repository;
    public IDeviceOperator GetOperator() => _operator;

    public void ParseDevices(string[] lines)
    {
        foreach (var line in lines)
        {
            try
            {
                var device = _parser.ParseDevice(line, Array.IndexOf(lines, line));
                _repository.Add(device);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing line: {ex.Message}");
            }
        }
    }
}