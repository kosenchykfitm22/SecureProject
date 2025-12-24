using System;
using System.Diagnostics;

namespace VulnerableVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Vulnerable File Reader (Do NOT use in production) ===");
            Console.WriteLine("Enter the filename to read:");

            string filename = Console.ReadLine();

            if (string.IsNullOrEmpty(filename))
            {
                Console.WriteLine("Invalid filename.");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
                return;
            }

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "cmd.exe";
                psi.Arguments = "/c type " + filename;
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                Process process = Process.Start(psi);
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                Console.WriteLine("File Content:");
                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
