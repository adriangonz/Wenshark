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
        public HttpResponseMessage getPlayLists(int idUser)
        {
            UserCEN userCEN = new UserCEN();
            UserEN user = userCEN.GetByID(idUser);

            if (user == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, "El usuario no existe");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, "Play lists de usuarios de "+user.Name);
        }
    }
}
