using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace CLIM
{
    class ToXML
    {
        public void Conversion()
        {
            DataRequest dr = new DataRequest();
            XmlDocument xml = (XmlDocument)JsonConvert.DeserializeXmlNode(dr.GetJSon(dr.SearchTerm));
            ObjectDumper.Write(xml);
        }

    }
}
