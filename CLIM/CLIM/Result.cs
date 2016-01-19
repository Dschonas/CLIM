using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIM
{
    public class Result
    {
        string wrapperType, kind;
        int artistId, collectionId, trackId;
        string artistName, collectionName, trackName;
        string collectionCensoredName;
        string trackCensoredName;
        string artistViewUrl;
        string collectionViewUrl;
        string trackViewUrl;
        string previewUrl;
        string artworkUrl30;
        string artworkUrl60;
        string artworkUrl100;
        decimal collectionPrice;
        decimal trackPrice;
        DateTime releaseDate;
        string collectionExplicitness;
        string trackExplicitness;
        int discCount;
        int discNumber;
        int trackCount;
        int trackNumber;
        decimal trackTimeMillis;
        string country;
        string primaryGenreName;
        string radioStationUrl;
        string isStreamable;

        public string WrapperType
        {
            get
            {
                return wrapperType;
            }

            set
            {
                wrapperType = value;
            }
        }

        public string Kind
        {
            get
            {
                return kind;
            }

            set
            {
                if (value != null && value.Length > 0)
                    kind = value;
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

        public int CollectionId
        {
            get
            {
                return collectionId;
            }

            set
            {
                if (value >= 0)
                    collectionId = value;
            }
        }

        public int TrackId
        {
            get
            {
                return trackId;
            }

            set
            {
                if (value >= 0)
                    trackId = value;
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

        public string CollectionCensoredName
        {
            get
            {
                return collectionCensoredName;
            }

            set
            {
                if (value != null && value.Length > 0)
                    collectionCensoredName = value;
            }
        }

        public string TrackCensoredName
        {
            get
            {
                return trackCensoredName;
            }

            set
            {
                if (value != null && value.Length > 0)
                    trackCensoredName = value;
            }
        }

        public string ArtistViewUrl
        {
            get
            {
                return artistViewUrl;
            }

            set
            {
                if (value != null && value.Length > 0)
                    artistViewUrl = value;
            }
        }

        public string CollectionViewUrl
        {
            get
            {
                return collectionViewUrl;
            }

            set
            {
                if (value != null && value.Length > 0)
                    collectionViewUrl = value;
            }
        }

        public string TrackViewUrl
        {
            get
            {
                return trackViewUrl;
            }

            set
            {
                if (value != null && value.Length > 0)
                    trackViewUrl = value;
            }
        }

        public string PreviewUrl
        {
            get
            {
                return previewUrl;
            }

            set
            {
                if (value != null && value.Length > 0)
                    previewUrl = value;
            }
        }

        public string ArtworkUrl30
        {
            get
            {
                return artworkUrl30;
            }

            set
            {
                if (value != null && value.Length > 0)
                    artworkUrl30 = value;
            }
        }

        public string ArtworkUrl60
        {
            get
            {
                return artworkUrl60;
            }

            set
            {
                if (value != null && value.Length > 0)
                    artworkUrl60 = value;
            }
        }

        public string ArtworkUrl100
        {
            get
            {
                return artworkUrl100;
            }

            set
            {
                if (value != null && value.Length > 0)
                    artworkUrl100 = value;
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
                if (value >= 0)
                    collectionPrice = value;
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

        public DateTime ReleaseDate
        {
            get
            {
                return releaseDate;
            }

            set
            {
                if (value != null)
                    releaseDate = value;
            }
        }

        public string CollectionExplicitness
        {
            get
            {
                return collectionExplicitness;
            }

            set
            {
                if (value != null && value.Length > 0)
                    collectionExplicitness = value;
            }
        }

        public string TrackExplicitness
        {
            get
            {
                return trackExplicitness;
            }

            set
            {
                if (value != null && value.Length > 0)
                    trackExplicitness = value;
            }
        }

        public int DiscCount
        {
            get
            {
                return discCount;
            }

            set
            {
                if (value >= 0)
                    discCount = value;
            }
        }

        public int DiscNumber
        {
            get
            {
                return discNumber;
            }

            set
            {
                if (value >= 0)
                    discNumber = value;
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

        public decimal TrackTimeMillis
        {
            get
            {
                return trackTimeMillis;
            }

            set
            {
                if (value >= 0)
                    trackTimeMillis = value;
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

        public string PrimaryGenreName
        {
            get
            {
                return primaryGenreName;
            }

            set
            {
                if (value != null && value.Length > 0)
                    primaryGenreName = value;
            }
        }

        public string RadioStationUrl
        {
            get
            {
                return radioStationUrl;
            }

            set
            {
                if (value != null && value.Length > 0)
                    radioStationUrl = value;
            }
        }

        public string IsStreamable
        {
            get
            {
                return isStreamable;
            }

            set
            {
                if (value != null && value.Length > 0)
                    isStreamable = value;
            }
        }
    }
}
