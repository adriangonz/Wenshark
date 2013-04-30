using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkCP.WensharkCP;

namespace WenSharkApp.Controllers
{
    public class AlbumController : ApiController
    {
        public HttpResponseMessage getAlbum(int id) 
        {
            //Obtenemos el album
            AlbumCP albumcp = new AlbumCP();
            AlbumEN album = albumcp.getAlbum(id);

            if (album == null) return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, new Exception());

            return this.Request.CreateResponse(HttpStatusCode.OK, album);
        }
    }
}
