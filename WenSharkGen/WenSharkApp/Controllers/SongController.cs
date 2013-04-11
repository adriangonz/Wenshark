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
using Microsoft.Win32;
using System.IO;

namespace WenSharkApp.Controllers
{
    public class SongController : ApiController
    {
        private static string defaultExtension(string mimeType)
        {
            string result;
            RegistryKey key;
            object value;

            key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + mimeType, false);
            value = key != null ? key.GetValue("Extension", null) : null;
            result = value != null ? value.ToString() : string.Empty;

            return result;
        }

        public async Task<IEnumerable<HttpResponseMessage>> postNewSong()
        {
            //Si no es FormData... Exception
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            
            string root = HttpContext.Current.Server.MapPath("~/App_Data/Songs");
            var provider = new MultipartFormDataStreamProvider(root);

            //Leo el form data y magia
            await Request.Content.ReadAsMultipartAsync(provider);
            SongCEN songcen = new SongCEN();
            return provider.FileData.Select((file, i) =>
                {
                    try
                    {
                        //Saco los datos
                        string name = provider.FormData["name-" + i];
                        int album = int.Parse(provider.FormData["album-" + i]);
                        int artist = int.Parse(provider.FormData["artist-" + i]);

                        //Guardo la nueva cancion en la BD
                        SongEN new_song = songcen.Create(name, "mierdas.ogg", artist, album);
                        
                        //Sobrescribo el nombre del fichero
                        var old_path = file.LocalFileName;
                        var old_name = Path.GetFileName(old_path);
                        var ext = defaultExtension(file.Headers.ContentType.MediaType);
                        var new_name = new_song.Id.ToString() + "." + ext;
                        var new_path = old_path.Replace(old_name, new_name);
                        File.Move(old_path, new_path);
                        new_song.Fname = new_name;
                        //TODO: save the mime type on the model
                        songcen.Modify(new_song.Id, new_song.Fname, new_song.Name, new_song.Created);

                        //Devuelvo 200 (OK)
                        return Request.CreateResponse(HttpStatusCode.OK);
                    } 
                    catch(System.Exception e) 
                    {
                        //Si algo falla devuelvo 500
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                    }
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
