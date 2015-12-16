using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace CLIM
{
    //general notes
    //  - case sensetive

    class Program
    {
        static void Main(string[] args)
        {
            DataRequest re = new DataRequest();
            //re.Request("Adele", "artist");
            Console.WriteLine("Hello, what do you want to do?");

            switch (Console.ReadLine())
            {
                case "search":
                    Console.WriteLine("Enter your search term: ");
                    string searchTerm = Console.ReadLine();
                    re.Request(searchTerm, "artist");

                    JsonLinqQuery t = new JsonLinqQuery();
                   // t.Conversion();
                    break;

                case "test":

                    
                    
                    break;


                default:
                    break;
            }
        }
    }
}
