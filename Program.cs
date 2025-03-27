var factory = new DeviceManagerFactory();
var manager = factory.Create(parser);
var parser = new DeviceParser();
manager.LoadFromFile("input.txt");

foreach (var device in manager.GetAllDevices())
{
    Console.WriteLine(device.ToString());
}