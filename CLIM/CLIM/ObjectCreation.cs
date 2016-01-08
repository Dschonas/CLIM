using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CLIM
{
    class ObjectCreation{
        List<Artist> artists;
        List<Media> medias;

        internal List<Artist> Artists
        {
            get
            {
                return artists;
            }

            set
            {
                artists = value;
            }
        }

        internal List<Media> Medias
        {
            get
            {
                return medias;
            }

            set
            {
                medias = value;
            }
        }

        public void createObjects(string json)
        {
            JObject iTunesSearch = JObject.Parse(json);

            // get JSON result objects into a list
            List<JToken> results = iTunesSearch["results"].Children().ToList();

            // serialize JSON results into .NET objects
            List<Result> searchResults = new List<Result>();
            foreach (JToken result in results)
            {
                Result searchResult = JsonConvert.DeserializeObject<Result>(result.ToString());
                searchResults.Add(searchResult);
            }
            artistCreation(searchResults);
            mediaCreation(searchResults);

            //Duplikate sollen rausgenommen werden
            Artists = Artists.GroupBy(x => x.ArtistID).Select(x => x.FirstOrDefault()).ToList<Artist>();
            Medias = Medias.GroupBy(x => x.MediaID).Select(x => x.FirstOrDefault()).ToList<Media>();
        }
        public void artistCreation(List<Result> searchQuery)
        {
                Artists = new List<Artist>();
                foreach (Result r in searchQuery)
                {
                    Artist artist = new Artist();
                    artist.ArtistID = r.ArtistId;
                    artist.ArtistViewLink = r.ArtistViewUrl;
                    artist.Country = r.Country;
                    artist.Name = r.ArtistName;

                //Wie es aussieht funktioniert diese if noch nicht
                if (!Artists.Contains(artist))
                    Artists.Add(artist);
                }
        }
        public void mediaCreation(List<Result> searchQuery)
        {
                Medias = new List<Media>();
                foreach (Result r in searchQuery)
                {
                    Media media = new Media();
                    media.MediaID = r.TrackId;
                    media.Genre = r.PrimaryGenreName;
                    media.KindOfMedia = r.Kind;
                    media.TrackName = r.TrackName;
                    media.TrackNumber = r.TrackNumber;
                    media.TrackPreviewLink = r.PreviewUrl;
                    media.TrackPrice = r.TrackPrice;
                    media.Tracktime = r.TrackTimeMillis;
                    media.TrackViewLink = r.TrackViewUrl;
                    media.WrapperType = r.WrapperType;
                    Medias.Add(media);
                }
        }

        public void PrintArtistResult()
        {
            if (Artists.Count != 0)
            {
                if (Artists.Count > 1)
                    Console.WriteLine("I found " + Artists.Count + " Artists based on your search!");
                else
                    Console.WriteLine("I found one Artist based on your search!");

                foreach (Artist a in Artists)
                {
                    Console.WriteLine("Name: " + a.Name);
                    Console.WriteLine("Country: " + a.Country);
                    Console.WriteLine("Link: " + a.ArtistViewLink);
                    Console.WriteLine("iTunes ID: " + a.ArtistID);
                    Console.WriteLine("_______________________________________");
                }
            }
        }

        public void PrintMediaResult()
        {
            if (Medias.Count != 0)
            {
                if (Medias.Count > 1)
                    Console.WriteLine("I found " + Medias.Count + " Songs or Podcasts based on your search!");
                else
                    Console.WriteLine("I found one Song or Podcast based on your search!");

                foreach (Media m in Medias)
                {
                    Console.WriteLine("Type: " + m.KindOfMedia);
                    Console.WriteLine("Name: " + m.TrackName);
                    Console.WriteLine("Genre: " + m.Genre);
                    Console.WriteLine("Number: " + m.TrackNumber);
                    Console.WriteLine("Price: " + m.TrackPrice + "$");
                    Console.WriteLine("Duration: " + (m.Tracktime / 1000 / 60).ToString("F") + "min");
                    Console.WriteLine("Link: " + m.TrackViewLink);
                    Console.WriteLine("Song Preview: " + m.TrackPreviewLink);
                    Console.WriteLine("_______________________________________");
                }
            }
        }
    }
}
