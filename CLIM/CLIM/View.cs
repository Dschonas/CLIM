using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIM
{
    public class View
    {
        private Controller controller;
        private Model model;

        internal Controller Controller
        {
            get
            {
                return controller;
            }

            set
            {
                controller = value;
            }
        }

        internal Model Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public View()
        {
            Model = new Model();
            Controller = new Controller(this.Model, this);

            Controller.InputHandler();
        }

        public void ShowHelp()
        {

            Console.WriteLine(default(int));
            Console.WriteLine("\nSEARCH ONLINE \t Offers to search for the given term online");
            Console.WriteLine("\t\t (iTunes Database).");
            Console.WriteLine("SEARCH OFFLINE \t Offers to search for the given term based on your");
            Console.WriteLine("\t\t past search history. (XML file)");
            Console.WriteLine("DELETE \t\t Delete a certain artist, album, song or the whole history.");
            Console.WriteLine("SAVE \t\t Stores your last search in a XML file.");
            Console.WriteLine("START TRACK \t Starts a sample of a certain track.");
            Console.WriteLine("OPEN ARTIST \t Opens a preview pic of an artist.\n");
        }

        public void PrintArtistResult()
        {
            if (Model.Artists.Count != 0)
            {
                if (Model.Artists.Count > 1)
                    Console.WriteLine("\nI found " + Model.Artists.Count + " Artists based on your search!\n");
                else
                    Console.WriteLine("\nI found one Artist based on your search!\n");

                foreach (Artist a in Model.Artists)
                {
                    Console.WriteLine("Name: " + a.Name);
                    Console.WriteLine("Country: " + a.Country);
                    Console.WriteLine("Link: " + a.ArtistViewLink);
                    //Console.WriteLine("iTunes ID: " + a.ArtistID);
                    Console.WriteLine("---------------------------------------");
                }
            }
        }

        public void PrintAlbumResult()
        {
            if (Model.Albums.Count != 0)
            {
                if (Model.Albums.Count > 1)
                    Console.WriteLine("\nI found " + Model.Albums.Count + " Albums based on your search!\n");
                else
                    Console.WriteLine("\nI found one Album based on your search!\n");

                foreach (Album a in Model.Albums)
                {
                    Console.WriteLine("Name: " + a.CollectionName);
                    Console.WriteLine("Price: " + a.CollectionPrice + " USD");
                    Console.WriteLine("Date: " + a.ReleaseDate);
                    Console.WriteLine("Number of Tracks:" + a.TrackCount);
                    //Console.WriteLine("Link: " + a.CollectionViewLink);
                    //Console.WriteLine("iTunes ID: " + a.CollectionID);
                    Console.WriteLine("---------------------------------------");
                }
            }
        }

        public void PrintMediaResult()
        {
            if (Model.Medias.Count != 0)
            {
                if (Model.Medias.Count > 1)
                    Console.WriteLine("\nI found " + Model.Medias.Count + " Songs or Podcasts based on your search!\n");
                else
                    Console.WriteLine("\nI found one Song or Podcast based on your search!\n");

                foreach (Media m in Model.Medias)
                {
                    Console.WriteLine("Type: " + m.KindOfMedia);
                    Console.WriteLine("Name: " + m.TrackName);
                    Console.WriteLine("Genre: " + m.Genre);
                    Console.WriteLine("TrackNumber: " + m.TrackNumber);
                    Console.WriteLine("Price: " + m.TrackPrice + "$");
                    Console.WriteLine("Duration: " + (m.Tracktime / 1000 / 60).ToString("F") + "min");
                    Console.WriteLine("Artist: " + m.ArtistName);
                    //Console.WriteLine("Link: " + m.TrackViewLink);
                    //Console.WriteLine("Song Preview: " + m.TrackPreviewLink);
                    Console.WriteLine("---------------------------------------");
                }
            }
        }

        //every printouts
    }
}
