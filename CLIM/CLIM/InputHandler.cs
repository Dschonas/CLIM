using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CLIM
{
    class InputHandler
    {

//DESCRIPTION

        //possible inputs
        //  - search
        //      - online    searches via the web URL
        //      - offline   searches via the provided offline XML file
        //                  - the search term

        //      - after you have searched, you can decide whether it is saved offline or not

//PROPERTIES
        public string SearchTerm { get; set; }

//CONSTRUCTOR
        public InputHandler()
        {
            bool done = false;
            do
            {
                Console.WriteLine("Hello,");
                Console.WriteLine("Possible commands:");
                Console.WriteLine("\t- search online (searches the wanted term via the Itunes URL)");
                Console.WriteLine("\t- search offline (searches the wanted term via a)");
                Console.WriteLine("\t- custom XML file based on previous search requests");
                Console.WriteLine("\t- test");
                Console.WriteLine("\t- possible ones: delete history/to start a track of");
                Console.WriteLine("\t- an artist/to open a preview pic of an artist");


                Console.WriteLine("So, what do you want to do?");

                switch (Console.ReadLine().ToLower())
                {

                    case "search online":

                        Console.WriteLine("Enter your search term: ");
                        SearchTerm = Console.ReadLine();

                        LinqJsonForOneRecord(JsonRequest(SearchTerm));
                        //Console.WriteLine(GetDataFromJson(3, "artistName", JsonRequest(SearchTerm)));
                        //Console.WriteLine(GetPrintedDataFromJson(3, "artistName", JsonRequest(SearchTerm)));
                        Console.ReadKey();

                        done = true;
                        break;

                    case "search offline":

                        done = true;
                        break;

                    case "test":

                        string json = JsonRequest("adele");

                        JObject rss = JObject.Parse(json);

                        var postTitles =
                            from p in rss["results"]
                            select (string)p["artistId"];
                        ObjectDumper.Write(postTitles);

                //Console.WriteLine(rssTitle);

                Console.ReadKey();

                        done = true;

                        break;

                    default:

                        Console.WriteLine(Console.ReadLine() + " is not a valid command!");
                        break;
                }
            }
            while (!done);
        }



//DATA REQUEST SECTION

        //Requests the Json file with the URL
        public string JsonRequest(string searchTerm)
        {
            //request from the URL
            WebRequest request = WebRequest.Create("https://itunes.apple.com/search?term=" + searchTerm);
            //getting the response
            WebResponse response = request.GetResponse();
            //checking the status of the response
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            //returning the stream of the request
            Stream dataStream = response.GetResponseStream();
            //reading the dataStream
            StreamReader reader = new StreamReader(dataStream);
            string dataFromURL = reader.ReadToEnd();

            return dataFromURL;
        }

        //Fetches the necessary data from the JSON
        //  - numberOfRecord    which record of the JsonRequest() should be taken
        //  - attribute         the name of the attribute you want to get the information about
        //  - json              the json file of the searched term
        public string GetDataFromJson(int numberOfRecord, string attribute, string json)
        {
            JObject rss = JObject.Parse(json);
            string data = (string)rss["results"][0][attribute];
            return data;
        }

        public string GetPrintedDataFromJson(int numberOfRecord, string attribute, string json)
        {
            JObject rss = JObject.Parse(json);
            string data = (string)rss["results"][0][attribute];
            string print = attribute + ": " + data;
            return print;
        }

        //LinqJsonForOneRecord returns selected attributes of one record of the JsonRequest()
        public void LinqJsonForOneRecord(string json)
        {
            JObject rss = JObject.Parse(json);

            var artistId =
                            from p in rss["results"]
                            select (string)p["trackName"];

            var artistName =
                            from p in rss["results"]
                            select (string)p["artistName"];

            var country =
                            from p in rss["results"]
                            select (string)p["country"];

            var artistViewUrl =
                            from p in rss["results"]
                            select (string)p["artistViewUrl"];

            ObjectDumper.Write(artistId);
            ObjectDumper.Write(artistName);
            ObjectDumper.Write(country);
            ObjectDumper.Write(artistViewUrl);
        }

        //diese Art der LINQ query funktioniert nicht --> genau genommen das select statement
        //
        //var listOfArtist =
        //                    from p in rss["results"]
        //                    select new { (string)p["artistID"], (string)p["artistName"], (string)p["country"], (string)p["artistViewLink"] };
        //ObjectDumper.Write(listOfArtist);

        public void QueryArtist()
        {
            string json = JsonRequest(SearchTerm);
            //string json = "{'resultCount':2,'results': [{'wrapperType':'track', 'kind':'podcast', 'collectionId':1016200886, 'trackId':1016200886, 'artistName':'Pietcast']}]";
            JObject jo = JObject.Parse(json);

            //string rrr = jo["resultCount"];

            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(json);
            ObjectDumper.Write(doc);



        }







        //{
        // "resultCount":2,
        // "results": [
        //{"wrapperType":"track", "kind":"podcast", "collectionId":1016200886, "trackId":1016200886, "artistName":"Pietcast", 
        //    "collectionName":"Pietcast Fakten gibt es woanders", "trackName":"Pietcast Fakten gibt es woanders", "collectionCensoredName":"Pietcast Fakten gibt es woanders", 
        //    "trackCensoredName":"Pietcast Fakten gibt es woanders", "collectionViewUrl":"https://itunes.apple.com/us/podcast/pietcast-fakten-gibt-es-woanders/id1016200886?mt=2&uo=4", 
        //    "feedUrl":"http://www.pietcast.com/feed/m4a/", "trackViewUrl":"https://itunes.apple.com/us/podcast/pietcast-fakten-gibt-es-woanders/id1016200886?mt=2&uo=4", 
        //    "artworkUrl30":"http://is2.mzstatic.com/image/thumb/Music5/v4/c2/dc/e9/c2dce919-e156-8ddc-f95f-b5a93a0b2829/source/30x30bb.jpg", 
        //    "artworkUrl60":"http://is2.mzstatic.com/image/thumb/Music5/v4/c2/dc/e9/c2dce919-e156-8ddc-f95f-b5a93a0b2829/source/60x60bb.jpg", 
        //    "artworkUrl100":"http://is2.mzstatic.com/image/thumb/Music5/v4/c2/dc/e9/c2dce919-e156-8ddc-f95f-b5a93a0b2829/source/100x100bb.jpg", "collectionPrice":0.00, 
        //    "trackPrice":0.00, "trackRentalPrice":0, "collectionHdPrice":0, "trackHdPrice":0, "trackHdRentalPrice":0, "releaseDate":"2015-11-30T20:18:00Z", 
        //    "collectionExplicitness":"notExplicit", "trackExplicitness":"notExplicit", "trackCount":21, "country":"USA", "currency":"USD", "primaryGenreName":"Philosophy", 
        //    "radioStationUrl":"https://itunes.apple.com/station/idra.1016200886", "artworkUrl600":"http://is2.mzstatic.com/image/thumb/Music5/v4/c2/dc/e9/c2dce919-e156-8ddc-f95f-b5a93a0b2829/source/600x600bb.jpg", 
        //    "genreIds":["1443", "26", "1324", "1318", "1450"], "genres":["Philosophy", "Podcasts", "Society & Culture", "Technology", "Podcasting"]
        //    }
        //}




        //TO XML SECTION
        public void QueryMedia()
        {
            //--------------------------------------------------
            string json = JsonRequest(SearchTerm);
            //string json = "{'resultCount':2,'results': [{'wrapperType':'track', 'kind':'podcast', 'collectionId':1016200886, 'trackId':1016200886, 'artistName':'Pietcast']}]";
            XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "results");

            Console.WriteLine();
            //ObjectDumper.Write(doc);

            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);

            doc.WriteTo(xmlTextWriter);

            Console.WriteLine(stringWriter.ToString());
            Console.ReadKey();

        }

        public void FirstMehod()
        {
            string json = JsonRequest("adele");

            JObject rss = JObject.Parse(json);
            Console.WriteLine(rss.Last.First().First().First().First());
            Console.WriteLine(rss.Last.First().First().Next.First().First());

            //string rssTitle = (string)rss["results"]["wrapperType"];
            //ObjectDumper.Write(rssTitle);

            //Console.WriteLine(rssTitle);

            Console.ReadKey();
        }
    }

}
