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
using System.IO.MemoryMappedFiles;
using System.Web.Mvc;
using WenSharkCP.WensharkCP;
using System.Drawing;

namespace WenSharkApp.Controllers
{
    public class SongController : ApiController
    {
        public static string defaultExtension(string mimeType)
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
            ItemCEN itCEN = new ItemCEN();
            return provider.FileData.Select((file, i) =>
                {
                    try
                    {
                        //Saco los datos
                        string name = provider.FormData["name-" + i];
                        string album = (provider.FormData["album-" + i]);
                        string artist = (provider.FormData["artist-" + i]);
                        int idAlbum = 5, idArtis = 1;
                        IList<ItemEN> result = null;

                        //Hacemos la busqueda de artista y de album
                        if (artist != "")
                        {
                            result = itCEN.GetByName(artist);
                            Boolean loTenemos = false;
                            foreach (ItemEN it in result)
                            {
                                if (it is ArtistEN)
                                {
                                    idArtis = it.Id;
                                    loTenemos = true;
                                    break;
                                }
                            }
                            //Si no lo tenemos los creamos
                            if (!loTenemos)
                            {
                                ArtistCEN artCEN = new ArtistCEN();
                                idArtis = (artCEN.Create(artist, "Bio autogenerada", "/Assets/img/artists/unknown.png")).Id;
                            }
                        }
                        if (album != "")
                        {
                            //Hacemos la SQL para buscar el album
                            result = itCEN.GetByName(album);
                            Boolean loTenemos = false;
                            foreach (ItemEN it in result)
                            {
                                if (it is AlbumEN)
                                {
                                    idAlbum = it.Id;
                                    loTenemos = true;
                                    break;
                                }
                            }
                            //Si no lo tenemos los creamos
                            if (!loTenemos)
                            {
                                //Setteo la ruta por defecto a la foto
                                String pathToAlbum = "/Assets/img/albums/unknown.png";

                                //Guardo el album y obtengo el id
                                AlbumCEN albCEN = new AlbumCEN();
                                AlbumEN albEn = albCEN.Create(album, DateTime.Now, pathToAlbum, idArtis);//TODO que ponemos aqui, lo sacamos del mime
                                idAlbum = albEn.Id;

                                //Leo la metainfo para guardar la foto
                                TagLib.File tagInfo = TagLib.File.Create(file.LocalFileName, file.Headers.ContentType.MediaType, TagLib.ReadStyle.Average);
                                if (tagInfo.Tag.Pictures.Count() > 0)
                                {
                                    //Hay minimo una imagen, o sea que nos la guardamos
                                    TagLib.IPicture p = tagInfo.Tag.Pictures[0];
                                    MemoryStream stream = new MemoryStream(p.Data.Data);
                                    ImageConverter ic = new ImageConverter();
                                    Image im = (Image)ic.ConvertFrom(p.Data.Data);
                                    var n_path = HttpContext.Current.Server.MapPath("~/Assets/img/albums/");
                                    var n_name = idAlbum + defaultExtension(p.MimeType);
                                    im.Save(n_path + n_name);
                                    pathToAlbum = "/Assets/img/albums/" + n_name;
                                    albCEN.Modify(idAlbum, albEn.Published, albEn.Name, albEn.Created, pathToAlbum);
                                }
                            }
                            
                        }


                        //Guardo la nueva cancion en la BD
                        SongEN new_song = songcen.Create(name, "temp", "temp", idArtis, idAlbum);
                        
                        //Sobrescribo el nombre del fichero
                        var old_path = file.LocalFileName;
                        var old_name = Path.GetFileName(old_path);
                        var ext = defaultExtension(file.Headers.ContentType.MediaType);
                        //Anyadir aqui las extensiones que Windows no tiene por defecto
                        if (ext == "" && file.Headers.ContentType.MediaType.Contains("ogg"))
                            ext = ".ogg";
                        var new_name = new_song.Id.ToString() + ext;
                        var new_path = old_path.Replace(old_name, new_name);
                        File.Move(old_path, new_path);
                        new_song.Fname = new_name;
                        songcen.Modify(new_song.Id, new_name, file.Headers.ContentType.MediaType, new_song.Name, new_song.Type);

                        //Devuelvo 200 (OK)
                        return new HttpResponseMessage(HttpStatusCode.OK);
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

        public List<SongEN> getMostPopular(string popular)
        {
            SongCP songcp = new SongCP();

            return songcp.getMostPopular();
        }

        public HttpResponseMessage getSong(string file, int id)
        {
            SongCP songcp = new SongCP();
            SongEN song = songcp.getSong(id);

            if (song == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            var path = HttpContext.Current.Server.MapPath("~/App_Data/Songs/" + song.Fname);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(song.Mime);
            return result;
        }
    }
}
