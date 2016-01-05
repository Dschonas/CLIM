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
        public string SearchTerm { get; set; }

        public void Request(string searchTerm, string typeOfSearch)
        {
            switch (typeOfSearch.ToLower())
            {
                case "artist":
                    //display the response data
                    Console.WriteLine(GetJSon(searchTerm));
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }

        public string GetJSon(string term)
        {
            //request from the URL
            WebRequest request = WebRequest.Create("https://itunes.apple.com/search?term=" + term);
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

        public void Test() {
            GetJSon("test");
        }

    }
}
