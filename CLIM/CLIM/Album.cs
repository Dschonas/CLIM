using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIM
{
    class Album
    {
        int collectionID, trackCount;
        string collectionName, currency, collectionViewLink, artworkLink;
        Decimal collectionPrice;
        DateTime releaseDate;
        List<Media> mediaList = new List<Media>();

        public int CollectionID
        {
            get
            {
                return collectionID;
            }

            set
            {
                if(value >= 0)
                    collectionID = value;
            }
        }

        public int TrackCount
        {
            get
            {
                return trackCount;
            }

            set
            {
                if (value >= 0)
                    trackCount = value;
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
                else
                    collectionName = "----";
            }
        }

        public DateTime ReleaseDate
        {
            get
            {
                return releaseDate;
            }

            set
            {
                if(value != null)
                    releaseDate = value;
            }
        }

        public decimal CollectionPrice
        {
            get
            {
                return collectionPrice;
            }

            set
            {
                if(value >= 0)
                    collectionPrice = value;
            }
        }

        public string Currency
        {
            get
            {
                return currency;
            }

            set
            {
                if (value != null && value.Length > 0)
                    currency = value;
            }
        }

        internal List<Media> MediaList
        {
            get
            {
                return mediaList;
            }

            set
            {
                if (value != null)
                    mediaList = value;
            }
        }

        public string CollectionViewLink
        {
            get
            {
                return collectionViewLink;
            }

            set
            {
                if (value != null && value.Length > 0)
                    collectionViewLink = value;
            }
        }

        public string ArtworkLink
        {
            get
            {
                return artworkLink;
            }

            set
            {
                if (value != null && value.Length > 0)
                    artworkLink = value;
            }
        }

        public int updateAndGetTrackCount()
        {
            TrackCount = MediaList.Count;
            return TrackCount;
        }
    }
}
