using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkCP.WensharkCP;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;

namespace WenSharkApp.Controllers
{
    public class ArtistController : ApiController
    {
        public HttpResponseMessage getArtist(int id)
        {
            //Obtenemos el artista por su ID
            ArtistCP artistcp = new ArtistCP();
            ArtistEN artist = artistcp.getArtist(id);

            if (artist == null) return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new Exception());

            return this.Request.CreateResponse(HttpStatusCode.OK, artist);
            /*
            var serializer = new JsonSerializer
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new NHibernateContractResolver()
            };

            StringWriter stringwriter = new StringWriter();
            JsonWriter jsonwriter = new Newtonsoft.Json.JsonTextWriter(stringwriter);
            serializer.Serialize(jsonwriter, artist);
            string output = stringwriter.ToString();

            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(output)
            };
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
             */
        }
    }
}
