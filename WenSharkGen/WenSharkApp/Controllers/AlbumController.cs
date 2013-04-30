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
        public AlbumEN getAlbum(int id) 
        {
            //Obtenemos el album
            AlbumCEN albumcen = new AlbumCEN();
            AlbumEN album = albumcen.ReadOID(id);

            if (album == null) throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            //Esto no ira por culpa de los lazy y tal

            return album;
        }
    }
}
