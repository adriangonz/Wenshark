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
            SongCEN songCEN = new SongCEN();
            AlbumCEN albumCEN = new AlbumCEN();
            ArtistCEN artistCEN = new ArtistCEN();

            List<SongEN> lsongs = songCEN.Search(name).ToList();
            List<AlbumEN> lalbums = albumCEN.Search(name).ToList();
            List<ArtistEN> lartists = artistCEN.Search(name).ToList();

            foreach (var item in lsongs)
            {
                item.Genre = null;
                item.Artist = songCEN.GetArtist(item);
                item.Album = songCEN.GetAlbum(item);
            }

            foreach (var item in lalbums)
            {
                item.Genre = null;
                item.Artist = albumCEN.GetArtist(item);
                item.Songs = null;
            }

            foreach (var item in lartists)
            {
                item.Genre = null;
                item.Songs = null;
                item.Albums = null;
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, new { songs = lsongs, albums = lalbums, artists = lartists });
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

