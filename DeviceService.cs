public class DeviceService
{
    private readonly IDeviceRepository _repository;
    private readonly IDeviceOperator _operator;

    public DeviceService(IDeviceRepository repository, IDeviceOperator @operator)
    {
        _repository = repository;
        _operator = @operator;
    }

    public void DemonstrateDeviceOperations()
    {
        Console.WriteLine("Devices presented after file read.");
        ShowAllDevices();
        
        AddAndTestNewComputer();
        
        Console.WriteLine("Devices presented after all operations.");
        ShowAllDevices();
    }

    private void AddAndTestNewComputer()
    {
        Console.WriteLine("Create new computer with correct data and add it to device store.");
        var computer = new PersonalComputer("P-2", "ThinkPad T440", false, null);
        _repository.Add(computer);
        
        TestComputerOperations("P-2");
        
        Console.WriteLine("Delete this PC");
        _repository.Remove("P-2");
    }

    private void TestComputerOperations(string deviceId)
    {
        Console.WriteLine("Let's try to enable this PC");
        try
        {
            _operator.TurnOn(deviceId);
        }
        catch (EmptySystemException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Let's install OS for this PC");
        var editComputer = new PersonalComputer("P-2", "ThinkPad T440", true, "Arch Linux");
        _repository.Update(editComputer);
        
        Console.WriteLine("Let's try to enable this PC");
        _operator.TurnOn(deviceId);
        
        Console.WriteLine("Let's turn off this PC");
        _operator.TurnOff(deviceId);
    }

    private void ShowAllDevices()
    {
        foreach (var device in _repository.GetAll())
        {
            Console.WriteLine(device.ToString());
        }
    }
}