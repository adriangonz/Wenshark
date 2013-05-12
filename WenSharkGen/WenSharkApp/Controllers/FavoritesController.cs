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
        [Authorize]
        public HttpResponseMessage getFavorites() {
            FavoritesCP favCP = new FavoritesCP();

            int id = int.Parse(this.User.Identity.Name);
            List<SongEN> lsongs = favCP.getUserFavorites(id);
            
            return this.Request.CreateResponse(HttpStatusCode.OK, new {songs = lsongs});
        }

        [Authorize]
        public HttpResponseMessage getAddFavorite(int song_id, string add) {
            UserCEN userCEN = new UserCEN();
            SongCEN songCEN = new SongCEN();

            int user_id = int.Parse(this.User.Identity.Name);
            SongEN songEN = songCEN.ReadOID(song_id);
            if (songEN == null) {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try {
                List<int> songs = new List<int>();
                songs.Add(song_id);
                userCEN.Relationer_favorites(user_id, songs);

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception) {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [Authorize]
        public HttpResponseMessage getRemoveFavorite(int song_id, string remove) {
            SongCEN songCEN = new SongCEN();

            int user_id = int.Parse(this.User.Identity.Name);
            SongEN songEN = songCEN.ReadOID(song_id);
            if (songEN == null) {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try {
                FavoritesCP favCP = new FavoritesCP();
                favCP.removeUserFavorite(user_id, song_id);

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception) {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
