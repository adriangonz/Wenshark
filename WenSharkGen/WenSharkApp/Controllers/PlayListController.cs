using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkCP;
using System.Web.Security;


namespace WenSharkApp.Controllers
{
    public class PlayListController : ApiController
    {
        public HttpResponseMessage get(int id)
        {
            PlayListCEN plCEN = new PlayListCEN();
            PlayListEN pl = plCEN.GetById(id);
            if (pl == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "PlayList no encontrada");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, "Bieeeen"+pl.Name);
        }

       
        [Authorize]
        public HttpResponseMessage getPlayLists()
        {
            PlayListCP playlistCP = new PlayListCP();

            int id = int.Parse(this.User.Identity.Name);           
            IList<PlayListEN> l = playlistCP.getByUser(id);
            
            return this.Request.CreateResponse(HttpStatusCode.OK, l);
  
        }
    }
}
