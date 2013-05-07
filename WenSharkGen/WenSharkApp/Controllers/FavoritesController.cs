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
    public class FavoritesController : ApiController
    {
        public HttpResponseMessage getFavorites(int user_id) {
            FavoritesCP favCP = new FavoritesCP();

            List<SongEN> lsongs = favCP.getUserFavorites(user_id);
            
            return this.Request.CreateResponse(HttpStatusCode.OK, new {songs = lsongs});
        }

        public HttpResponseMessage getAddFavorite(int user_id, int song_id, string add) {
            UserCEN userCEN = new UserCEN();
            SongCEN songCEN = new SongCEN();

            UserEN userEN = userCEN.GetByID(user_id);
            SongEN songEN = songCEN.ReadOID(song_id);
            if (userEN == null || songEN == null) {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try {
                userEN.Favorites.Add(songEN);
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception) {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        public HttpResponseMessage getRemoveFavorite(int user_id, int song_id, string remove) {
            UserCEN userCEN = new UserCEN();
            SongCEN songCEN = new SongCEN();

            UserEN userEN = userCEN.GetByID(user_id);
            SongEN songEN = songCEN.ReadOID(song_id);
            if (userEN == null || songEN == null) {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            userEN.Favorites.Remove(songEN);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
