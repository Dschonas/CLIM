using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Hello, what do you want to do?\n");

            switch (Console.ReadLine())
            {
                case "search":
                    Console.WriteLine("Enter your search term: ");
                    string searchTerm = Console.ReadLine();
                    re.Request(searchTerm, "artist");
                    break;
                default:
                    break;
            }
        }
    }
}
