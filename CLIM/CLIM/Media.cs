using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIM
{
    class Media
    {
        int mediaID, tracknumber, tracktime; //tracktime in milliseconds
        String kindOfMedia, wrapperType, trackName, trackPrice, genre, trackViewLink, trackPreviewLink;

        public int MediaID
        {
            get
            {
                return mediaID;
            }

            set
            {
                mediaID = value;
            }
        }

        public int Tracknumber
        {
            get
            {
                return tracknumber;
            }

            set
            {
                tracknumber = value;
            }
        }

        public int Tracktime
        {
            get
            {
                return tracktime;
            }

            set
            {
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
                trackName = value;
            }
        }

        public string TrackPrice
        {
            get
            {
                return trackPrice;
            }

            set
            {
                trackPrice = value;
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
                trackPreviewLink = value;
            }
        }
    }
}
