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
    public class ArtistController : ApiController
    {
        public HttpResponseMessage getArtist(int id)
        {
            //Obtenemos el artista por su ID
            ArtistCEN artistcen = new ArtistCEN();
            ArtistEN artist = artistcen.ReadOID(id);

            if (artist == null) return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new Exception());

            //Esto petara porque no hay aun sesiones ni mierdas
            artist.Albums = null;
            artist.Genre = null;
            artist.Songs = null;

            return this.Request.CreateResponse(HttpStatusCode.OK, artist);
        }
    }
}
