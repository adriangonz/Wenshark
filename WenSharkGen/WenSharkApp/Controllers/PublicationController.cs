using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkCP.WensharkCP;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkApp.Controllers
{
    public class PublicationController : ApiController
    {
        [Authorize]
        public HttpResponseMessage getPublications()
        {
            PublicationCP publicationCP = new PublicationCP();

            int id = int.Parse(this.User.Identity.Name);
            IList<PublicationEN> l = publicationCP.getByUser(id);

            return this.Request.CreateResponse(HttpStatusCode.OK, l);
        }
    }
}
