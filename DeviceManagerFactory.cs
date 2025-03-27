namespace APBD{
public class DeviceManagerFactory : IDeviceManagerFactory
{
    public DeviceManager Create(string filePath)
    {
        var (manager, _, _) = CreateWithDependencies(filePath);
        return manager;
    }

    public (DeviceManager manager, IDeviceRepository repository, IDeviceOperator @operator) CreateWithDependencies(string filePath)
    {
    var repository = new DeviceRepository();
    var parser = new DeviceParser(); // Add this line
    var @operator = new DeviceOperator(repository);
    var manager = new DeviceManager(repository, @operator, parser); // Add parser here
    
    if (!File.Exists(filePath))
        throw new FileNotFoundException("Input file not found");
    
    var lines = File.ReadAllLines(filePath);
    manager.ParseDevices(lines);
    
    return (manager, repository, @operator);
    }
}
}