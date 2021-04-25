using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Globalization;

namespace DownloadPng
{
    class Program
    {
        static void Main(string[] args)
        {
            string flagPath = "Files/flag-image-links.txt";
            string isoPath = "Files/country-iso-codes.txt";

            string flagFolderPath = Directory.GetCurrentDirectory() + "\\Flags\\";
            
            if (!Directory.Exists(flagFolderPath))
            {
                Directory.CreateDirectory(flagFolderPath);
            }

            int iterator1 = File.ReadAllLines(flagPath).Count();
            int iterator2 = File.ReadAllLines(isoPath).Count();

            if (iterator1 != iterator2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" > Error: Files must contain the same number of data!");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                StreamReader sr1 = new StreamReader(flagPath);
                StreamReader sr2 = new StreamReader(isoPath);

                int flagCount = 0;
                string url = "", iso = "";

                while (true)
                {
                    url = sr1.ReadLine();
                    iso = sr2.ReadLine();

                    if (url == null) break;

                    flagCount++;
                    string image = iso.ToLower(new CultureInfo("en-US", false)) + ".png";
                    string toBeDownloaded = flagFolderPath + image;

                    WebClient webClient = new WebClient();
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    // Check if file exists with its full path    
                    if (File.Exists(Path.Combine(flagFolderPath, toBeDownloaded)))
                    {
                        // If file found, delete it    
                        File.Delete(Path.Combine(flagFolderPath, toBeDownloaded));
                        // Console.Write("\t > Flag {0,-5} deleted.", flagCount);
                    }

                    // Download multiple files using webclient's DownloadFileAsync and utilizing a text file for URL input for download.
                    webClient.DownloadFileAsync(new Uri(url), toBeDownloaded);

                    Console.WriteLine(" > Flag {0, -3} '{1,-5}' downloaded.", flagCount, image);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n > {0} flag images has been successfully downloaded.", flagCount);
            }

            Console.ReadKey();
        }
    }
}
