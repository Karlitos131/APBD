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
                // Get the absolute path to input.txt
                string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
                Console.WriteLine($"Looking for input file at: {inputPath}");

                if (!File.Exists(inputPath))
                {
                    throw new FileNotFoundException($"Cannot find input.txt at {inputPath}");
                }

                // Initialize system
                var factory = new DeviceManagerFactory();
                var (_, repository, @operator) = factory.CreateWithDependencies(inputPath);
                
                // Run demonstration
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