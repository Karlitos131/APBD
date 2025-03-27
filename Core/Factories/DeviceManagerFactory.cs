namespace APBD.Core.Factories
{
    /// <summary>
    /// Factory responsible for creating instances of DeviceManager with required dependencies.
    /// </summary>
    public class DeviceManagerFactory
    {
        /// <summary>
        /// Creates and returns a new instance of DeviceManager using default repository and parser.
        /// </summary>
        /// <returns>A fully initialized DeviceManager instance.</returns>
        public DeviceManager Create()
        {
            return new DeviceManager(
                new DeviceRepository(),
                new DeviceParser()
            );
        }
    }
}