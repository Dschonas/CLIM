using Newtonsoft.Json;
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
        public string Postition { get; set; }

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
                Postition = "#";
                Console.Write(Postition);

                switch (Console.ReadLine().ToLower())
                {

                    case "help":

                        View.ShowHelp();
                        break;

                    case "search":

                        Postition = "#search>";
                        Console.Write(Postition);
                        String choice = Console.ReadLine();
                        if (choice.ToLower().Equals("online"))
                            goto case "search online";
                        else if (choice.ToLower().Equals("offline"))
                            goto case "search offline";

                        break;

                    case "search online":

                        Postition = "#search>online>";
                        SearchOnline();
                        break;

                    case "search offline":

                        Postition = "#search>offline>";
                        SearchOffline();
                        break;

                    case "exit":

                        done = true;
                        break;

                    case "test":

                        Console.WriteLine("Nothing to test atm.");
                        break;

                    case "save":

                        Save();
                        break;

                    default:

                        Console.Write("This is not a valid command\n");
                        break;
                }
            }
            while (!done);
            System.Environment.Exit(1);
        }

        //Save
        //Delete



        public void Save()
        {
            if (Model.SaveHistoryFinal())
                Console.WriteLine("Saved successfully.");
            else
                Console.WriteLine("Nothing to save.");

        }

        public void SearchOnline()
        {
            //Console.WriteLine("\nEnter your search term:");
            Console.Write(Postition);
            SearchTerm = Console.ReadLine();

            string jsonSearch = Model.JsonRequest(SearchTerm);
            //Console.WriteLine("I found " + getNumberOfResults(jsonSearch) + " results!");
            //GetPrintedDataFromJson(0, "artistName", jsonSearch);
            Model.CreateObjects(jsonSearch);
            View.PrintArtistResult();
            View.PrintAlbumResult();
            View.PrintMediaResult();
            //LinqJsonForOneRecord(jsonSearch);

            //possible save commands
        }

        public void SearchOffline()
        {

        }
    }
}