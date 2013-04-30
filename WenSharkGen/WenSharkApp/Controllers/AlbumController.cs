using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkApp.Controllers
{
    public class AlbumController : ApiController
    {
        public HttpResponseMessage getAlbum(int id) 
        {
            //Obtenemos el album
            AlbumCEN albumcen = new AlbumCEN();
            AlbumEN album = albumcen.ReadOID(id);

            if (album == null) return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, new Exception());

            //Esto no ira por culpa de los lazy y tal
            album.Artist = null;
            album.Genre = null;
            album.Songs = null;
            
            return this.Request.CreateResponse(HttpStatusCode.OK, album);
        }
    }
}
