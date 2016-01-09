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
        List<Media> songList = new List<Media>();

        public int ArtistID
        {
            get
            {
                return artistID;
            }

            set
            {
                if (value >= 0)
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
                if (value != null && value.Length > 0)
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
                if (value != null && value.Length > 0)
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
                if (value != null && value.Length > 0)
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
                if (value != null && value.Any())
                    albumList = value;
            }
        }

        internal List<Media> SongList
        {
            get
            {
                return songList;
            }

            set
            {
                if (value != null && value.Any())
                    songList = value;
            }
        }
    }
}
