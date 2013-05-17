using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkCP.WensharkCP;

namespace WenSharkApp.Controllers
{
    public class TimelineController : ApiController
    {
        [Authorize]
        public HttpResponseMessage getTimeline() {
            UserCP userCP = new UserCP();
            PublicationCP publCP = new PublicationCP();

            int userId = int.Parse(this.User.Identity.Name);
            
            List<int> listaIds = userCP.getAllFollowers(userId);

            List<PublicationEN> publicaciones = new List<PublicationEN>();
            foreach (var i in listaIds) {
                publicaciones.AddRange(publCP.getByUser(i));
            }

            //publicaciones = publicaciones.OrderByDescending(o=>o.

            return this.Request.CreateResponse(HttpStatusCode.OK, publicaciones);
        }
    }
}
