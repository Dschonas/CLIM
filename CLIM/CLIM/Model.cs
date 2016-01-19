using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace CLIM
{
    //WebRequest
    //JSON query
    //ObjectCreation
    public class Model
    {
        internal List<Artist> Artists { get; set; }
        internal List<Media> Medias { get; set; }
        internal List<Album> Albums { get; set; }

        public Model()
        {
            Artists = new List<Artist>();
            Medias = new List<Media>();
            Albums = new List<Album>();
        }


        //JSON queries

        //Requests the Json file with the URL
        public string JsonRequest(string searchTerm)
        {
            try
            {
                //request from the URL
                WebRequest request = WebRequest.Create("https://itunes.apple.com/search?term=" + searchTerm);
                //getting the response
                WebResponse response = request.GetResponse();
                //checking the status of the response
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                //returning the stream of the request
                Stream dataStream = response.GetResponseStream();
                //reading the dataStream
                StreamReader reader = new StreamReader(dataStream);
                string dataFromURL = reader.ReadToEnd();

                return dataFromURL;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //Fetches the necessary and returns data from the JSON
        //  - numberOfRecord    which record of the JsonRequest() should be taken
        //  - attribute         the name of the attribute you want to get the information about
        //  - json              the json file of the searched term
        public string GetDataFromJson(int numberOfRecord, string attribute, string json)
        {
            try
            {
                JObject rss = JObject.Parse(json);
                string data = (string)rss["results"][0][attribute];
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string GetPrintedDataFromJson(int numberOfRecord, string attribute, string json)
        {
            try
            {
                JObject rss = JObject.Parse(json);
                string data = (string)rss["results"][0][attribute];
                return attribute + ": " + data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //LinqJsonForOneRecord returns selected attributes of one record of the JsonRequest()
        public void LinqJsonForOneRecord(string json)
        {
            try
            {
                JObject rss = JObject.Parse(json);

                var artistId = from p in rss["results"]
                               select (string)p["trackName"];

                var artistName = from p in rss["results"]
                                 select (string)p["artistName"];

                var country = from p in rss["results"]
                              select (string)p["country"];

                var artistViewUrl =
                                from p in rss["results"]
                                select (string)p["artistViewUrl"];

                ObjectDumper.Write(artistId);
                ObjectDumper.Write(artistName);
                ObjectDumper.Write(country);
                ObjectDumper.Write(artistViewUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //LinqJsonForOneRecord returns selected attributes of one record of the JsonRequest()
        public string GetNumberOfResults(string json)
        {
            try
            {
                JObject rss = JObject.Parse(json);
                return (string)rss["resultCount"];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //Object creation
        public void CreateObjects(string json)
        {
            try
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

                ArtistCreation(searchResults);
                MediaCreation(searchResults);
                AlbumCreation(searchResults);

                Artists = Artists.GroupBy(x => x.ArtistID).Select(x => x.FirstOrDefault()).ToList<Artist>();
                Medias = Medias.GroupBy(x => x.MediaID).Select(x => x.FirstOrDefault()).ToList<Media>();
                Albums = Albums.GroupBy(x => x.CollectionID).Select(x => x.FirstOrDefault()).ToList<Album>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ArtistCreation(List<Result> searchQuery)
        {
            if (searchQuery != null)
                foreach (Result r in searchQuery)
                {
                    Artist artist = new Artist();
                    artist.ArtistID = r.ArtistId;
                    artist.ArtistViewLink = r.ArtistViewUrl;
                    artist.Country = r.Country;
                    artist.Name = r.ArtistName;

                    if (!Artists.Contains(artist))
                    {
                        Artists.Add(artist);

                    }
                }
        }
        public void AlbumCreation(List<Result> searchQuery)
        {
            if (searchQuery != null)
                foreach (Result r in searchQuery)
                {
                    Album album = new Album();
                    album.ArtworkLink = r.ArtworkUrl100;
                    album.CollectionID = r.CollectionId;
                    album.CollectionName = r.CollectionName;
                    album.CollectionPrice = r.CollectionPrice;
                    album.CollectionViewLink = r.CollectionViewUrl;
                    album.ReleaseDate = r.ReleaseDate;
                    album.Currency = "USD";
                    if (Medias != null)
                        foreach (Media m in Medias)
                        {
                            if (m.CollectionName == album.CollectionName)
                                album.MediaList.Add(m);
                        }
                    album.updateTrackCount();

                    Albums.Add(album);
                }
        }
        public void MediaCreation(List<Result> searchQuery)
        {
            if (searchQuery != null)
                foreach (Result r in searchQuery)
                {
                    Medias.Add(CreateMediaFromResult(r));
                }
        }

        public Media CreateMediaFromResult(Result r)
        {
            if (r != null)
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
                media.CollectionName = r.CollectionName;
                media.ArtistId = r.ArtistId;
                media.ArtistName = r.ArtistName;
                media.CollectionId = r.CollectionId;
                return media;
            }
            else return null;
        }

        public bool SaveHistory()
        {
            if (Artists.Count != 0)
            {
                XmlDocument xdoc = new XmlDocument();
                XElement xml = new XElement("XML");

                foreach (var artist in Artists)
                {
                    XElement xartist = new XElement("Artist",
                                        new XElement("Name", artist.Name),
                                        new XElement("Country", artist.Country),
                                        new XElement("Link", artist.ArtistViewLink),
                                        new XElement("iTunesID", artist.ArtistID));
                    foreach (var album in Albums)
                    {
                        if (album.MediaList.First().ArtistName.Equals(artist.Name))
                        {
                            XElement xalbum = new XElement("Album",
                                                        new XElement("Name", album.CollectionName),
                                                        new XElement("ID", album.CollectionID),
                                                        new XElement("Price", album.CollectionPrice),
                                                        new XElement("Currency", album.Currency),
                                                        new XElement("ArtworkLink", album.ArtworkLink),
                                                        new XElement("Link", album.CollectionViewLink));

                            foreach (var media in album.MediaList)
                            {
                                XElement xsong = new XElement("Song",
                                                                   new XElement("Type", media.WrapperType),
                                                                   new XElement("Name", media.TrackName),
                                                                   new XElement("Genre", media.Genre),
                                                                   new XElement("TrackNumber", media.TrackNumber),
                                                                   new XElement("Price", media.TrackPrice),
                                                                   new XElement("Duration", media.Tracktime),
                                                                   new XElement("Link", media.TrackViewLink),
                                                                   new XElement("Preview", media.TrackPreviewLink),
                                                                   new XElement("AlbumName", media.CollectionName)
                                                           );
                                xalbum.Add(xsong);
                            }
                            xartist.Add(xalbum);
                        }
                    }
                    xml.Add(xartist);
                    xdoc.LoadXml(xml.ToString());
                }
                xdoc.Save("..//..//clim_history.xml");
                return true;
            }
            return false;
        }

        public bool SaveHistoryFinal()
        {
            if (Artists.Count != 0)
            {
                XmlDocument xdoc = new XmlDocument();
                XElement xml = new XElement("xml");

                foreach (var artist in Artists)
                {
                    XElement xartist = new XElement("artist",
                                        new XAttribute("itunesid", artist.ArtistID),
                                        new XAttribute("country", artist.Country),
                                        new XAttribute("name", artist.Name),
                                        new XElement("link", artist.ArtistViewLink)
                                        );
                    foreach (var album in Albums)
                    {
                        if (album.MediaList.Count != 0)
                        {
                            XElement xalbum = new XElement("album",
                                                        new XAttribute("currency", album.Currency),
                                                        new XAttribute("price", album.CollectionPrice),
                                                        new XAttribute("id", album.CollectionID),
                                                        new XAttribute("name", album.CollectionName),
                                                        new XElement("link", album.CollectionViewLink),
                                                        new XElement("artworklink", album.ArtworkLink)
                                                        );
                            foreach (var media in album.MediaList)
                            {
                                XElement xsong = new XElement("track",
                                                                   new XElement("song",
                                                                   new XAttribute("albumname", media.CollectionName),
                                                                   new XAttribute("duration", media.Tracktime),
                                                                   new XAttribute("price", media.TrackPrice),
                                                                   new XAttribute("tracknumber", media.TrackNumber),
                                                                   new XAttribute("genre", media.Genre),
                                                                   new XAttribute("name", media.TrackName),
                                                                   new XAttribute("type", media.WrapperType),
                                                                   new XElement("link", media.TrackViewLink),
                                                                   new XElement("preview", media.TrackPreviewLink)
                                                                   ));
                                xalbum.Add(xsong);
                            }
                            xartist.Add(xalbum);
                        }
                    }
                    xml.Add(xartist);
                    xdoc.LoadXml(xml.ToString());
                }
                xdoc.Save("..//..//clim_history.xml");
                return true;
            }
            return false;
        }

        public void XmlQuery(string attribute, string term)
        {
            XElement xel = XElement.Load("..//..//clim_history.xml");

            var query =
                    from x in xel.Descendants("artist")
                    where x.Attribute(attribute).Value.Equals(term)
                    select new
                    {
                        Name = x.Attribute("name").Value,
                        Country = x.Attribute("country").Value,
                        iTunesID = x.Attribute("itunesid").Value
                    };
            ObjectDumper.Write(query);
        }

        public void XmlQueryArtist(string attribute, string term)
        {
            XElement xel = XElement.Load("..//..//clim_history.xml");

            var query =
                    from x in xel.Descendants("artist")
                    where x.Attribute(attribute).Value.Equals(term)
                    select new
                    {
                        Name = x.Attribute("name").Value,
                        Country = x.Attribute("country").Value,
                        iTunesID = x.Attribute("itunesid").Value
                    };
            ObjectDumper.Write(query);
        }

        public void XmlQueryAlbum(string attribute, string term)
        {
            XElement xel = XElement.Load("..//..//clim_history.xml");

            var query =
                    from x in xel.Descendants("album")
                    where x.Attribute(attribute).Value.Equals(term)
                    select new
                    {
                        Name = x.Attribute("name").Value,
                        ID = x.Attribute("country").Value,
                        Price = x.Attribute("price").Value,
                        Currency = x.Attribute("currncy").Value
                    };
            ObjectDumper.Write(query);
        }

        public void XmlQuerySong(string attribute, string term)
        {
            XElement xel = XElement.Load("..//..//clim_history.xml");

            var query =
                    from x in xel.Descendants("song")
                    where x.Attribute(attribute).Value.Equals(term)
                    select new
                    {
                        Name = x.Attribute("name").Value,
                        Price = x.Attribute("price").Value,
                        Type = x.Attribute("type").Value,
                        Genre = x.Attribute("genre").Value,
                        TrackNumber = x.Attribute("tracknumber").Value,
                        Duration = x.Attribute("duration").Value,
                        AlbumName = x.Attribute("albumname").Value
                    };
            ObjectDumper.Write(query);
        }

        //samples, UNUSED
        public void CreateSample()
        {
            XElement xel = new XElement("Artist",
                                new XElement("Name", "Adele"),
                                new XElement("Country", "USA"),
                                new XElement("Link", "http"),
                                new XElement("iTunesID", "32423"));

            XElement xel2 = new XElement("Album",
                                        new XElement("Name", "HELLO"));

            XElement xel3 = new XElement("Song",
                                                new XElement("Type", "track/podcast"),
                                                new XElement("Name", "Hello"),
                                                new XElement("Genre", "Pop"),
                                                new XElement("TrackNumber", "3"),
                                                new XElement("Price", "2$"),
                                                new XElement("Duration", "3min"),
                                                new XElement("Link", "http"),
                                                new XElement("Preview", "http")
                                        );
            xel2.Add(xel3);
            xel.Add(xel2);

            Console.WriteLine(xel.ToString());
        }
        public void CreateHistoryNotUsed()
        {
            for (int i = 0; i < Artists.Count(); i++)
            {

                XElement xartist = new XElement("Artist",
                                    new XElement("Name", Artists.ElementAt(i).Name),
                                    new XElement("Country", Artists.ElementAt(i).Country),
                                    new XElement("Link", Artists.ElementAt(i).ArtistViewLink),
                                    new XElement("iTunesID", Artists.ElementAt(i).ArtistID));

                XElement xalbum = new XElement("Album",
                                            new XElement("Name", "HELLO"));

                XElement xsong = new XElement("Song",
                                                   new XElement("Type", Medias.ElementAt(i).WrapperType),
                                                   new XElement("Name", Medias.ElementAt(i).TrackName),
                                                   new XElement("Genre", Medias.ElementAt(i).Genre),
                                                   new XElement("TrackNumber", Medias.ElementAt(i).TrackNumber),
                                                   new XElement("Price", Medias.ElementAt(i).TrackPrice),
                                                   new XElement("Duration", Medias.ElementAt(i).Tracktime),
                                                   new XElement("Link", Medias.ElementAt(i).TrackViewLink),
                                                   new XElement("Preview", Medias.ElementAt(i).TrackPreviewLink)
                                           );

                xalbum.Add(xsong);
                xartist.Add(xalbum);
            }
        }
    }


}