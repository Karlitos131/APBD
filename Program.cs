using System;
using System.IO;

namespace APBD
{
    class Program
    {
        public static void Main()
        {
            try
            {
                string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
                Console.WriteLine($"Looking for input file at: {inputPath}");

                if (!File.Exists(inputPath))
                {
                    throw new FileNotFoundException($"Cannot find input.txt at {inputPath}");
                }

                var factory = new DeviceManagerFactory();
                var (_, repository, @operator) = factory.CreateWithDependencies(inputPath);
                
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
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
