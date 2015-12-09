using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CLIM
{

    class DataRequest
    {
        public void Request(string searchTerm, string typeOfSearch)
        {
            switch (typeOfSearch)
            {
                case "artist":
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
                    //display the response data
                    Console.WriteLine(dataFromURL);
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }

    }
}
