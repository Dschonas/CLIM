using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIM
{
    class Controller
    {
        public Model Model { get; set; }
        public View View { get; set; }

        public string SearchTerm { get; set; }

        public Controller(Model model, View view)
        {
            Model = model;
            View = view;
        }

        public void InputHandler()
        {
            Console.WriteLine("\nHello, I am CLIM");

            bool done = false;
            do
            {
                Console.WriteLine("\nPossible commands:");
                Console.WriteLine("\t- search online (iTunes Database)");
                Console.WriteLine("\t- search offline (the saved past searches)");
                Console.WriteLine("\t- in future: delete history/to start a track of");
                Console.WriteLine("\t  an artist/to open a preview pic of an artist");

                Console.WriteLine("Type in \"end\" to close CLIM.");
                Console.WriteLine("So, what do you want to do?");

                switch (Console.ReadLine().ToLower())
                {
                    case "search":

                        Console.WriteLine("Online or offline?");
                        String choice = Console.ReadLine();

                        if (choice.ToLower().Equals("online"))
                            goto case "search online";
                        else if (choice.ToLower().Equals("offline"))
                            goto case "search offline";
                        break;

                    case "search online":

                        SearchOnline();
                        break;

                    case "search offline":

                        SearchOffline();
                        break;

                    case "end":

                        done = true;
                        break;

                    case "test":
                        Model.CreateSample();
                        break;

                    case "save":

                        Model.SaveHistory();
                        break;

                    default:

                        Console.WriteLine("This is not a valid command!");
                        break;
                }
            }
            while (!done);
            System.Environment.Exit(1);
        }

        //Save
        //Delete

        public void SearchOnline()
        {
            Console.WriteLine("Enter your search term:");
            SearchTerm = Console.ReadLine();

            string jsonSearch = Model.JsonRequest(SearchTerm);
            //Console.WriteLine("I found " + getNumberOfResults(jsonSearch) + " results!");
            //GetPrintedDataFromJson(0, "artistName", jsonSearch);
            Model.CreateObjects(jsonSearch);
            Model.PrintArtistResult();
            Model.PrintMediaResult();
            //LinqJsonForOneRecord(jsonSearch);

            //possible save commands
            Console.ReadKey();
        }

        public void SearchOffline()
        {

        }
    }
}
