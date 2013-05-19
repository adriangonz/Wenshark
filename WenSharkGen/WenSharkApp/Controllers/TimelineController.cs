using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.CAD.Default_;
using WenSharkCP.WensharkCP;

namespace WenSharkApp.Controllers
{
    public class TimelineController : ApiController
    {
        [Authorize]
        public HttpResponseMessage getTimeline() {

            TimelineCP timelineCP = new TimelineCP();

            int userId = int.Parse(this.User.Identity.Name);

            List<PublicationEN> lpublis = timelineCP.getTimeline(userId);


            List<SongEN> lsongs = timelineCP.getSongs(lpublis);
            List<AlbumEN> lalbums = timelineCP.getAlbums(lpublis);
            List<ArtistEN> lartists = timelineCP.getArtists(lpublis);

            lpublis = lpublis.OrderByDescending(o => o.Id).ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, new { songs = lsongs, albums = lalbums, artists = lartists, publications = lpublis });
        }

        public HttpResponseMessage getTimeline(int userId) {

            TimelineCP timelineCP = new TimelineCP();

            List<PublicationEN> lpublis = timelineCP.getUserTimeline(userId);

            List<SongEN> lsongs = timelineCP.getSongs(lpublis);
            List<AlbumEN> lalbums = timelineCP.getAlbums(lpublis);
            List<ArtistEN> lartists = timelineCP.getArtists(lpublis);

            lpublis = lpublis.OrderByDescending(o => o.Id).ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, new { songs = lsongs, albums = lalbums, artists = lartists, publications = lpublis });
        }
    }
}
