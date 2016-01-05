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
        String collectionName, currency, collectionViewLink, artworkLink;
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
                collectionName = value;
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
                artworkLink = value;
            }
        }
    }
}
