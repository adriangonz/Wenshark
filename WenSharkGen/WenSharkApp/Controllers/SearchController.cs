using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using NHibernate;

namespace WenSharkApp.Controllers
{
    public class SearchController : ApiController
    {
        public HttpResponseMessage getSearch(string name)
        {
            ItemCEN itemCEN = new ItemCEN();
            
            List<ItemEN> itemList = itemCEN.Search(name).ToList();
            List<SongEN> lsongs = new List<SongEN>();
            List<AlbumEN> lalbums = new List<AlbumEN>();
            List<ArtistEN> lartists = new List<ArtistEN>();


            foreach (var item in itemList)
            {
                item.Genre = null;

                if (item.GetType() == typeof(SongEN))
                {
                    ((SongEN)item).Artist = null;
                    ((SongEN)item).Album = null;
                    lsongs.Add((SongEN)item);
                }
                else if (item.GetType() == typeof(AlbumEN))
                {
                    ((AlbumEN)item).Artist = null;
                    ((AlbumEN)item).Songs = null;
                    lalbums.Add((AlbumEN)item);
                }
                else if (item.GetType() == typeof(ArtistEN))
                {
                    ((ArtistEN)item).Songs = null;
                    ((ArtistEN)item).Albums = null;
                    lartists.Add((ArtistEN)item);
                }
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, new { songs = lsongs, albums = lalbums, artits = lartists });
        }

        public HttpResponseMessage getSearch()
        {
            SongCEN songcen = new SongCEN();
            var res = songcen.GetAll(0, 10).ToList();

            foreach (var song in res)
            {
                song.Artist = null;
                song.Genre = null;
                song.Album = null;
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, new { pru = res });
        }
    }

    public class pru
    {
        public List<SongEN> res;
    }
}

