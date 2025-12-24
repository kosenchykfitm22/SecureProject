using System;
using System.IO;

namespace SecureProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Secure File Reader ===");
            Console.WriteLine("Enter the filename to read:");

            string filename = Console.ReadLine();

            if (string.IsNullOrEmpty(filename))
            {
                Console.WriteLine("Invalid filename.");
                return;
            }

            try
            {
                if (File.Exists(filename))
                {
                   string content = File.ReadAllText(filename);
                   Console.WriteLine("File Content:");
                   Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine("Error: File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
        }
    }
}
