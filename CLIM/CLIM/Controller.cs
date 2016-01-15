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
            Console.WriteLine("\nHello, I am CLIM.");
            Console.WriteLine("\nType 'help' for more information.");
            

            bool done = false;
            do
            {
                Console.Write("\n#");

                switch (Console.ReadLine().ToLower())
                {

                    case "help":

                        ShowHelp();
                        break;

                    case "search":

                        Console.WriteLine("\nOnline or offline?");
                        Console.Write("\n#search/");
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

                    case "exit":

                        done = true;
                        break;

                    case "test":

                        Model.Artists.First().ToString();
                        Model.Artists.Last().ToString();
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

        public void ShowHelp()
        {
            Console.WriteLine("\nSEARCH ONLINE \t Offers to search for the given term online");
            Console.WriteLine("\t\t (iTunes Database).");
            Console.WriteLine("SEARCH OFFLINE \t Offers to search for the given term based on your");
            Console.WriteLine("\t\t past search history. (XML file)");
            Console.WriteLine("DELETE \t\t Delete a certain artist, album, song or the whole history.");
            Console.WriteLine("SAVE \t\t Stores your last search in a XML file.");
            Console.WriteLine("START TRACK \t Starts a sample of a certain track.");
            Console.WriteLine("OPEN ARTIST \t Opens a preview pic of an artist.\n");
        }

        public void SearchOnline()
        {
            Console.WriteLine("\nEnter your search term:");
            Console.Write("\n#search/online/");
            SearchTerm = Console.ReadLine();

            string jsonSearch = Model.JsonRequest(SearchTerm);
            //Console.WriteLine("I found " + getNumberOfResults(jsonSearch) + " results!");
            //GetPrintedDataFromJson(0, "artistName", jsonSearch);
            Model.CreateObjects(jsonSearch);
            Model.PrintArtistResult();
            Model.PrintAlbumResult();
            Model.PrintMediaResult();
            //LinqJsonForOneRecord(jsonSearch);

            //possible save commands
        }

        public void SearchOffline()
        {

        }
    }
}
