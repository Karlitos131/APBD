namespace APBD
{
    public interface IDeviceRepository
    {
        void Add(Device device);
        void Update(Device device);
        void Remove(string deviceId);
        Device? GetById(string deviceId);
        IEnumerable<Device> GetAll();
    }

    public interface IDeviceOperator
    {
        void TurnOn(string deviceId);
        void TurnOff(string deviceId);
    }

    public interface IDeviceParser
    {
        Device ParseDevice(string line, int lineNumber);
        PersonalComputer ParsePC(string line, int lineNumber);
        Smartwatch ParseSmartwatch(string line, int lineNumber);
        Embedded ParseEmbedded(string line, int lineNumber);
    }

    public interface IDeviceManagerFactory
    {
        DeviceManager Create(string filePath);
    }

    public interface IPowerNotify
    {
        void Notify();
    }
}
