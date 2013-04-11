using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using NHibernate;
using System.Net.Http.Formatting;
using System.Web;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WenSharkApp.Controllers
{
    public class SongController : ApiController
    {
        public async Task<IEnumerable<HttpResponseMessage>> postNewSong()
        {
            //Si no es FormData... Exception
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            
            string root = HttpContext.Current.Server.MapPath("~/App_Data/Songs");
            var provider = new MultipartFormDataStreamProvider(root);

            //Leo el form data y magia
            await Request.Content.ReadAsMultipartAsync(provider);
            
            return provider.FileData.Select((file, i) =>
                {
                    string name = provider.FormData["name-" + i];
                    string album = provider.FormData["album-" + i];
                    string artist = provider.FormData["artist-" + i];

                    return Request.CreateResponse(HttpStatusCode.OK);
                });
        }

        public List<SongEN> getAll()
        {
            SongCEN songCEN = new SongCEN();
            List<SongEN> resul = songCEN.GetAll(0, 10).ToList();


            foreach (var song in resul)
            {
                
                foreach (var gen in song.Genre)
                {
                    gen.Item = null;
                }

                song.Album.Genre = null;
                song.Artist.Genre = null;

                song.Album.Artist = null;
                song.Album.Songs = null;

                song.Artist.Albums = null;
                song.Artist.Songs = null;
                
            }

            return resul;
        }
    }
}
