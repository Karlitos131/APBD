using APBD.Core.Factories;
using APBD.Core.Services;

var parser = new DeviceParser();
var factory = new DeviceManagerFactory();
var manager = factory.Create(parser);
manager.LoadFromFile("input.txt");

foreach (var device in manager.GetAllDevices())
{
    Console.WriteLine(device.ToString());
}