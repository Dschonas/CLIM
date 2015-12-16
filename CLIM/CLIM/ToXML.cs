using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CLIM
{
    class JsonLinqQuery
    {
        DataRequest dr = new DataRequest();
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








        public void QueryArtist()
        {
            string json = dr.GetJSon(dr.SearchTerm);
            //string json = "{'resultCount':2,'results': [{'wrapperType':'track', 'kind':'podcast', 'collectionId':1016200886, 'trackId':1016200886, 'artistName':'Pietcast']}]";
            JObject jo = JObject.Parse(json);

            //string rrr = jo["resultCount"];

            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(json);
            ObjectDumper.Write(doc);

            

        }

        public void QueryMedia()
        {
            //--------------------------------------------------
            string json = dr.GetJSon(dr.SearchTerm);
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

        public void QueryAlbum()
        {
            DataRequest dr = new DataRequest();
            string json = dr.GetJSon(dr.SearchTerm);



        }

    }
}
