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
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*****WELCOME*****");
            bool getSrc = true;
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
                    string reply = client.DownloadString($"{protocol}://www.{url}");
                    Console.WriteLine("Downloaded Successfully...\n");
                    string tl = @"..\\..\\html\\";
                    Console.WriteLine("\nThe file will save in .html format");
                    Console.Write("Enter filename: ");
                    string fn = Console.ReadLine();
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
                Console.WriteLine("Type yes or 1 to continue");
                Console.WriteLine("Type no or 2 to exit");
                string choice = Console.ReadLine();
                if (choice == "yes" || choice == "1")
                    getSrc = true;
                
                else if (choice == "no" || choice == "2")
                    getSrc = false;

                else
                    Console.WriteLine("Enter a valid choice");

            }
            while (getSrc);
            Console.WriteLine("***Goodbye***");


            Console.ReadKey();

        }
    }
}
        
   
