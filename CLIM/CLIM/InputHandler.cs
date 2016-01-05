using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CLIM
{
    class InputHandler
    {
        //possible inputs
        //  - search
        //      - online    searches via the web URL
        //      - offline   searches via the provided offline XML file
        //                  - the search term

        //      - after you have searched, you can decide whether it is saved offline or not

        public InputHandler()
        {
            DataRequest re = new DataRequest();
            //re.Request("Adele", "artist");

            bool done = false;
            do
            {
                Console.WriteLine("Hello, what do you want to do?");
                //string searchTerm = "";
                switch (Console.ReadLine().ToLower())
                {

                    case "search online":

                        Console.WriteLine("Enter your search term: ");
                        re.SearchTerm = Console.ReadLine();
                        re.Request(re.SearchTerm, "artist");

                        //JsonLinqQuery t = new JsonLinqQuery();
                        // t.Conversion();
                        done = true;
                        break;

                    case "search offline":

                        Console.WriteLine("Enter your search term: ");
                        re.SearchTerm = Console.ReadLine();
                        re.Request(re.SearchTerm, "artist");//no sense of splitting the search

                        //JsonLinqQuery t = new JsonLinqQuery();
                        // t.Conversion();
                        done = true;
                        break;

                    case "test":

                        string json = re.GetJSon(re.SearchTerm);
                        //string json = "{'resultCount':2,'results': [{'wrapperType':'track', 'kind':'podcast', 'collectionId':1016200886, 'trackId':1016200886, 'artistName':'Pietcast']}]";
                        XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "root");

                        //Console.WriteLine();
                        ObjectDumper.Write(doc);

                        done = true;

                        break;

                    default:

                        Console.WriteLine(Console.ReadLine() + " is not a valid command!");
                        break;
                }
            }
            while (!done);
        }
    }
}
