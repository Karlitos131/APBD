class Program
{
    public static void Main()
    {
        try
        {
            var factory = new DeviceManagerFactory();
            var (_, repository, @operator) = factory.CreateWithDependencies("input.txt");
            
            new DeviceService(repository, @operator)
                .DemonstrateDeviceOperations();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"FATAL ERROR: {ex.Message}");
            Console.ResetColor();
            
            #if DEBUG
            Console.WriteLine(ex.StackTrace);
            #endif
        }
    }
}