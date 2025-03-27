namespace APBD
{
    public class DeviceManagerFactory : IDeviceManagerFactory
    {
        public DeviceManager Create(string filePath)
        {
            var repository = new DeviceRepository();
            var parser = new DeviceParser();
            var @operator = new DeviceOperator(repository);
            return new DeviceManager(repository, @operator, parser, filePath);
        }
    }
}
