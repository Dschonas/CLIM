using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIM
{
    //general notes
    //  - case sensetive

    class Program
    {
        static void Main(string[] args)
        {
            DataRequest re = new DataRequest();
            re.Request("Adele", "artist");
        }
    }
}
