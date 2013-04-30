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
        public ArtistEN getArtist(int i)
        {
            //Obtenemos el artista por su ID
            ArtistCEN artistcen = new ArtistCEN();
            ArtistEN artist = artistcen.ReadOID(i);

            if (artist == null) throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            //Esto petara porque no hay aun sesiones ni mierdas

            return artist;
        }
    }
}
