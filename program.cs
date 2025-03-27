class Program
   public static void Main()
{
    try
    {
        string filePath = "input.txt";
        
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Missing input.txt at: {Path.GetFullPath(filePath)}");

        var factory = new DeviceManagerFactory();
        var (_, repository, @operator) = factory.CreateWithDependencies(filePath);
        new DeviceService(repository, @operator).DemonstrateDeviceOperations();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: {ex.Message}");
        Console.ResetColor();
        #if DEBUG
        Console.WriteLine(ex.StackTrace);
        #endif
    }
    Console.ReadKey();
}