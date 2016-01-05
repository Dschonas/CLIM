using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIM
{
    class Artist
    {
        int artistID;
        String name, country, artistViewLink;
        List<Album> albumList = new List<Album>();

        public int ArtistID
        {
            get
            {
                return artistID;
            }

            set
            {
                artistID = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
            }
        }

        public string ArtistViewLink
        {
            get
            {
                return artistViewLink;
            }

            set
            {
                artistViewLink = value;
            }
        }

        internal List<Album> AlbumList
        {
            get
            {
                return albumList;
            }

            set
            {
                albumList = value;
            }
        }
    }
}
