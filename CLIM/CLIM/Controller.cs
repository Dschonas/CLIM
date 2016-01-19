using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIM
{
    public class Controller
    {
        private Model model;
        private View view;

        public string SearchTerm { get; set; }
        public string Position { get; set; }

        public Model Model
        {
            get
            {
                return model;
            }

            set
            {
                if (value != null)
                    model = value;
            }
        }

        public View View
        {
            get
            {
                return view;
            }

            set
            {
                if (value != null)
                    view = value;
            }
        }

        public Controller(Model model, View view)
        {
            Model = model;
            View = view;
        }

        public void InputHandler()
        {
            View.Advisor("\nHello, I am CLIM.");
            View.Advisor("\nType 'help' for more information.");

            bool done = false;
            do
            {
                Position = "#";
                View.InputLine(Position);

                switch (Console.ReadLine().ToLower())
                {

                    case "help":

                        View.ShowHelp();
                        break;

                    case "search":

                        Position = "#search>";
                        View.Advisor("Online or offline?");
                        View.InputLine(Position);
                        String choice = Console.ReadLine();
                        if (choice.ToLower().Equals("online"))
                            goto case "search online";
                        else if (choice.ToLower().Equals("offline"))
                            goto case "search offline";

                        break;

                    case "search online":

                        Position = "#search>online>";
                        SearchOnline();
                        break;

                    case "search offline":

                        Position = "#search>offline>";
                        SearchOffline();
                        break;

                    case "exit":

                        done = true;
                        break;

                    case "test":

                        Model.XmlQueryArtist("name", "adele");
                        Model.XmlQueryAlbum("name", "25");
                        Model.XmlQuerySong("name", "Hello");
                        break;

                    case "save":

                        Save();
                        break;

                    default:

                        View.ErrorMessage("This is not a valid command\n");
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
                View.Advisor("Saved successfully.");
            else
                View.Advisor("Nothing to save.");

        }

        public void SearchOnline()
        {
            //Console.WriteLine("\nEnter your search term:");
            View.InputLine(Position);
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
            View.Advisor("\nArtist, Album or Song?");
            View.InputLine(Position);
            switch (Console.ReadLine().ToLower())
            {
                case "artist":
                    SearchOfflineArtist();
                    break;

                case "album":
                    SearchOfflineAlbum();
                    break;

                case "song":
                    SearchOfflineSong();
                    break;

                default:
                    break;
            }
        }

        public void SearchOfflineArtist()
        {
            Position = "#search>offline>artist>";
            View.Advisor("\nThe attribute and the value you wanna search for.('help' for possible attributes)");
            View.InputLine(Position);
            string attribute = Console.ReadLine().ToLower();

            if (attribute.Equals("help"))
            {
                View.ShowHelpOfflineArtistOutput();
                View.InputLine(Position);
                attribute = Console.ReadLine().ToLower();
            }

            if (!View.ShowHelpOfflineSong().Contains(attribute) || attribute == "")
            {
                View.ErrorMessage("The attribute " + attribute + " was not found!");
                return;
            }

            View.Advisor("\nThe term you want to search for.");
            Position = "#search>offline>artist>" + attribute + ">";
            View.InputLine(Position);
            string term = Console.ReadLine();

            if (term == null || term == "" || term == " ")
                return;

            string queryTerm = term.First().ToString().ToUpper() + term.Substring(1);
            Model.XmlQueryArtist(attribute, queryTerm);
        }

        public void SearchOfflineAlbum()
        {
            Position = "#search>offline>album>";
            View.Advisor("\nThe attribute and the value.");
            View.InputLine(Position);
            string attribute = Console.ReadLine().ToLower();

            if (attribute.Equals("help"))
            {
                View.ShowHelpOfflineAlbumOutput();
                View.InputLine(Position);
                attribute = Console.ReadLine().ToLower();
            }

            if (!View.ShowHelpOfflineSong().Contains(attribute) || attribute == "")
            {
                View.ErrorMessage("The attribute " + attribute + " was not found!");
                return;
            }

            View.Advisor("\nThe term you want to search for.");
            Position = "#search>offline>album>" + attribute + ">";
            View.InputLine(Position);
            string term = Console.ReadLine();

            if (term == null || term == "" || term == " ")
                return;

            string queryTerm = term.First().ToString().ToUpper() + term.Substring(1);
            Model.XmlQueryAlbum(attribute, queryTerm);
        }

        public void SearchOfflineSong()
        {
            Position = "#search>offline>song>";
            View.Advisor("\nThe attribute you want to search for.");
            View.InputLine(Position);
            string attribute = Console.ReadLine().ToLower();

            if (attribute.Equals("help"))
            {
                View.ShowHelpOfflineSongOutput();
                View.InputLine(Position);
                attribute = Console.ReadLine().ToLower();
            }

            if (!View.ShowHelpOfflineSong().Contains(attribute) || attribute == "")
            {
                View.ErrorMessage("The attribute " + attribute + " was not found!");
                return;
            }

            View.Advisor("\nThe term you want to search for.");
            Position = "#search>offline>song>" + attribute + ">";
            View.InputLine(Position);
            string term = Console.ReadLine();

            if (term == "")
            {
                View.ErrorMessage("Invalid search term!");
                return;
            }

            string queryTerm = term.First().ToString().ToUpper() + term.Substring(1);
            Model.XmlQuerySong(attribute, queryTerm);
        }
    }
}