using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CEN.Default_;

namespace WenSharkApp.Controllers
{
    public class FavoritesController : ApiController
    {
        public HttpResponseMessage getFavorites(int id) {
            UserCEN userCEN = new UserCEN();

            UserEN userEN = userCEN.GetByID(id);
            if(userEN == null){
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            List<SongEN> lsongs = new List<SongEN>();
            List<AlbumEN> lalbums = new List<AlbumEN>();
            List<ArtistEN> lartists = new List<ArtistEN>();

            List<ItemEN> litems = userEN.Favorites.ToList();

            

            return this.Request.CreateResponse(HttpStatusCode.OK, new {items = litems});
        }
    }
}
