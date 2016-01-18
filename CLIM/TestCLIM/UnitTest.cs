using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CLIM;
using System.Collections.Generic;

namespace TestCLIM
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestAlbum_TestInserts_AllPassed()
        {
            Album a = new Album();
            a.ArtworkLink = "Link";
            a.CollectionID = 1;
            a.CollectionName = "CollectionName";
            a.CollectionPrice = -332;
            a.CollectionViewLink = "Link";
            DateTime now = new DateTime();
            now = DateTime.Now;
            a.ReleaseDate = now;
            a.Currency = "USD";

            Media m = new Media();
            List<Media> m_list = new List<Media>();
            m_list.Add(m);
            m_list.Add(m);
            m_list.Add(m);
            a.MediaList = m_list;

            Assert.AreEqual(a.TrackCount, 3);
            Assert.AreEqual(a.CollectionPrice, 0);
        }
        [TestMethod]
        public void TestArtist_TestInserts_AllPassed()
        {
            Artist ar = new Artist();
            ar.ArtistID = 1;
            ar.ArtistViewLink = "Link";
            ar.Country = "Country";
            ar.Name = "Name";

            List<Media> lm = new List<Media>();
            Media me = new Media();
            lm.Add(me);
            lm.Add(me);
            lm.Add(me);
            lm.Add(me);

            ar.SongList = lm;

            List <Album> la = new List<Album>();

            Album a = new Album();
            a.ArtworkLink = "Link";
            a.CollectionID = 1;
            a.CollectionName = "CollectionName";
            a.CollectionPrice = -332;
            a.CollectionViewLink = "Link";
            DateTime now = new DateTime();
            now = DateTime.Now;
            a.ReleaseDate = now;
            a.Currency = "USD";

            la.Add(a);
            la.Add(a);
            la.Add(a);
            la.Add(a);
            
            ar.AlbumList = la;

            Assert.IsNotNull(ar);
        }
    }
}
