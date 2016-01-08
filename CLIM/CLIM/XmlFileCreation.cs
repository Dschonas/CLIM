using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLIM
{
    class XmlFileCreation
    {
        public XmlFileCreation()
        {

        }

        public void CreateSample()
        {
            XElement xel = new XElement("Artist",
                                new XElement("Name", "Adele"),
                                new XElement("Country", "USA"),
                                new XElement("Link", "http"),
                                new XElement("iTunesID", "32423"),
                                new XElement("Album",
                                        new XElement("Name", "HELLO"),
                                        new XElement("Song",
                                                new XElement("Type", "track/podcast"),
                                                new XElement("Name", "Hello"),
                                                new XElement("Genre", "Pop"),
                                                new XElement("TrackNumber", "3"),
                                                new XElement("Price", "2$"),
                                                new XElement("Duration", "3min"),
                                                new XElement("Link", "http"),
                                                new XElement("Preview", "http")
                                        )
                                )
                            );

            Console.WriteLine(xel.ToString());
        }

        public void CreateHistory()
        {
            XElement xel = new XElement("Artist",
                                new XElement("Name", "Adele"),
                                new XElement("Country", "USA"),
                                new XElement("Link", "http"),
                                new XElement("iTunesID", "32423"),
                                new XElement("Album",
                                        new XElement("Name", "HELLO"),
                                        new XElement("Song",
                                                new XElement("Type", "track/podcast"),
                                                new XElement("Name", "Hello"),
                                                new XElement("Genre", "Pop"),
                                                new XElement("TrackNumber", "3"),
                                                new XElement("Price", "2$"),
                                                new XElement("Duration", "3min"),
                                                new XElement("Link", "http"),
                                                new XElement("Preview", "http")
                                        )
                                )
                            );
        }
    }
}
