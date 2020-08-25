using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    /// <summary>
    /// Download html source code and zip files
    /// </summary>
    class Program
    {
        static string choice;
        static void Main(string[] args)
        {

            Console.WriteLine("*****WELCOME*****");
            bool run = true;
            do
            {
                WebClient client = new WebClient();
                string protocol = "http"; ;
                Console.Write("Enter Site URL of which you want to download html source code:" + protocol + "//www.");
                string url = Console.ReadLine();
                while (url == "")
                {
                    Console.WriteLine("The URL should not be blank");
                    Console.Write("\nEnter Site URL of which you want to download html source code:"+ protocol+"//www.");
                    url = Console.ReadLine();
                }
                Console.WriteLine("Downloading...\nPlease wait");
                try
                {
                    string reply = client.DownloadString($"{protocol}://www.{url}"); //download html source code
                    Console.WriteLine("Downloaded Successfully...\n");
                    string tl = @"..\\..\\html\\";
                    Console.WriteLine("\nThe file will save in .html format");
                    Console.Write("Enter filename: ");
                    string fn = Console.ReadLine(); //file name
                     
                    //file name must not be left blank
                    bool fne = true;
                    do
                    {
                        if (fn == "")
                        {
                            Console.WriteLine("\nThe Filename Should not be empty ");
                            Console.WriteLine("Enter filename: ");
                            fn = Console.ReadLine();
                            fne = true;
                        }
                        else
                        {
                            fne = false;
                        }
                    }
                    while (fne);

                    File.WriteAllText($@"{tl}\{fn}.html", reply);

                }
                catch (WebException err)
                {
                    Console.Write("\nError - " + err.Message);
                }


                Console.WriteLine("\nDo you want to download html source code of another website?");
                Console.WriteLine("Type yes or 1 to download");
                Console.WriteLine("Type no or 2 to exit");
                Console.WriteLine("If you want to zip the downloaded files, type the zip");
                 choice = Console.ReadLine();
                if (choice == "yes" || choice == "1") //download html source code again
                {
                    run = true;
                }
                   
                
                else if (choice == "no" || choice == "2")
                {
                    run = false;
                }
                    
                else if (choice == "zip") //zip files
                {
                    File.Delete(@"..\..\ZIP.zip");
                    ZipFile.CreateFromDirectory(@"..\\..\\html\\", @"..\..\ZIP.zip");
                    Console.WriteLine("\nFiles are zipped\n");
                    Console.WriteLine("\nDo you want to download html source code of another website?");
                    Console.WriteLine("Type yes or 1 to download");
                    Console.WriteLine("Type no or 2 to exit");
                     choice = Console.ReadLine();
                    if (choice == "yes" || choice == "1")
                    {
                        run = true;
                    }


                    else if (choice == "no" || choice == "2")
                    {
                        run = false;
                    }

                }

                else
                    Console.WriteLine("Enter a valid choice");

            }
            while (run);
            Console.WriteLine("***Goodbye***");


            Console.ReadKey();

        }
    }
}
        
   
