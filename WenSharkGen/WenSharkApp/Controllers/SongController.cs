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
    public class SongController : ApiController
    {
        public List<SongEN> getAll()
        {
            SongCEN songCEN = new SongCEN();
            List<SongEN> resul = songCEN.GetAll(0, 10).ToList();


            foreach (var song in resul)
            {
                
                foreach (var gen in song.Genre)
                {
                    gen.Item = null;
                }

                song.Album.Genre = null;
                song.Artist.Genre = null;

                song.Album.Artist = null;
                song.Album.Songs = null;

                song.Artist.Albums = null;
                song.Artist.Songs = null;
                
            }

            return resul;
        }
    }
}
