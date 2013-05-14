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
using WenSharkCP.WensharkCP;
using WenSharkCP.DTO;

namespace WenSharkApp.Controllers
{
    public class SearchController : ApiController
    {
        public HttpResponseMessage getSearch(string name)
        {
            SearchCP searchCP = new SearchCP();

            List<SongEN> lsongs = searchCP.searchSong(name);
            List<AlbumEN> lalbums = searchCP.searchAlbum(name);
            List<ArtistEN> lartists = searchCP.searchArtist(name);

            List<UserDTO> lusers = new List<UserDTO>();

            if (this.User.Identity.IsAuthenticated)
            {
                int idUser = int.Parse(this.User.Identity.Name);
                lusers = searchCP.searchUsers(idUser,name);
            }
            return this.Request.CreateResponse(HttpStatusCode.OK, new { songs = lsongs, albums = lalbums, artists = lartists, users = lusers });
        }

        public HttpResponseMessage getSearch()
        {
        
            return this.Request.CreateResponse(HttpStatusCode.OK, "hola");
        }
    }

    public class pru
    {
        public List<SongEN> res;
    }
}

