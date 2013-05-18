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

        public HttpResponseMessage getSearchSong(string name, int offset, string song)
        {
            SearchCP searchCP = new SearchCP();

            List<SongEN> songs = searchCP.searchSong(name, offset);

            return this.Request.CreateResponse(HttpStatusCode.OK, songs);
        }

        public HttpResponseMessage getSearchAlbum(string name, int offset, string album)
        {
            SearchCP searchCP = new SearchCP();

            List<AlbumEN> albums = searchCP.searchAlbum(name, offset);

            return this.Request.CreateResponse(HttpStatusCode.OK, albums);
        }

        public HttpResponseMessage getSearchArtist(string name, int offset, string artist)
        {
            SearchCP searchCP = new SearchCP();

            List<ArtistEN> songs = searchCP.searchArtist(name, offset);

            return this.Request.CreateResponse(HttpStatusCode.OK, songs);
        }

        [Authorize]
        public HttpResponseMessage getSearchUser(string name, int offset, string user)
        {
            SearchCP searchCP = new SearchCP();

            int idUser = int.Parse(this.User.Identity.Name);
            List<UserDTO> users = searchCP.searchUsers(idUser,name, offset);

            return this.Request.CreateResponse(HttpStatusCode.OK, users);
        }
    }

    public class pru
    {
        public List<SongEN> res;
    }
}

