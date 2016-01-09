using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIM
{
    class Media
    {
        int mediaID, trackNumber, artistId;
        decimal tracktime; //tracktime in milliseconds
        String kindOfMedia, wrapperType, trackName, genre, trackViewLink, trackPreviewLink, collectionName, artistName;
        decimal trackPrice;

        public int MediaID
        {
            get
            {
                return mediaID;
            }

            set
            {
                if (value >= 0)
                    mediaID = value;
            }
        }

        public int TrackNumber
        {
            get
            {
                return trackNumber;
            }

            set
            {
                if (value >= 0)
                    trackNumber = value;
            }
        }

        public decimal Tracktime
        {
            get
            {
                return tracktime;
            }

            set
            {
                if (value >= 0)
                    tracktime = value;
            }
        }

        public string KindOfMedia
        {
            get
            {
                return kindOfMedia;
            }

            set
            {
                if (value != null && value.Length > 0)
                    kindOfMedia = value;
            }
        }

        public string WrapperType
        {
            get
            {
                return wrapperType;
            }

            set
            {
                if (value != null && value.Length > 0)
                    wrapperType = value;
            }
        }

        public string TrackName
        {
            get
            {
                return trackName;
            }

            set
            {
                if (value != null && value.Length > 0)
                    trackName = value;
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }

            set
            {
                if (value != null && value.Length > 0)
                    genre = value;
            }
        }

        public string TrackViewLink
        {
            get
            {
                return trackViewLink;
            }

            set
            {
                if (value != null && value.Length > 0)
                    trackViewLink = value;
            }
        }

        public string TrackPreviewLink
        {
            get
            {
                return trackPreviewLink;
            }

            set
            {
                if (value != null && value.Length > 0)
                    trackPreviewLink = value;
            }
        }

        public decimal TrackPrice
        {
            get
            {
                return trackPrice;
            }

            set
            {
                if (value >= 0)
                    trackPrice = value;
            }
        }

        public string CollectionName
        {
            get
            {
                return collectionName;
            }

            set
            {
                if (value != null && value.Length > 0)
                    collectionName = value;
            }
        }

        public int ArtistId
        {
            get
            {
                return artistId;
            }

            set
            {
                if (value >= 0)
                    artistId = value;
            }
        }

        public string ArtistName
        {
            get
            {
                return artistName;
            }

            set
            {
                if (value != null && value.Length > 0)
                    artistName = value;
            }
        }
    }
}
