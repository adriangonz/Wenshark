using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenSharkGenNHibernate.CAD.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkCP.WensharkCP {
    public class TimelineCP : BasicCP {
        
        /**
         * Devuelve el timeline de la gente a la que sigue userID
         */ 
        public List<PublicationEN> getTimeline(int userId) {

            SessionInitializeTransaction();

            UserCP userCP = new UserCP();
            List<int> listaIds = userCP.getAllFollowers(userId);

            PublicationCP publCP = new PublicationCP();
            List<PublicationEN> publicaciones = new List<PublicationEN>();
            foreach (var i in listaIds) {
                publicaciones.AddRange(publCP.getByUser(i));
            }

            SessionClose();

            return publicaciones;
        }

        /**
         * Devuelve el timeline de las publicaciones de userId
         */ 
        public List<PublicationEN> getUserTimeline(int userId) {

            SessionInitializeTransaction();

            UserCP userCP = new UserCP();

            PublicationCP publCP = new PublicationCP();
            List<PublicationEN> publicaciones = publCP.getByUser(userId);

            SessionClose();

            return publicaciones;
        }

        public List<SongEN> getSongs(List<PublicationEN> publications) {

            SessionInitializeTransaction();

            SongCAD songCAD = new SongCAD(session);
            SongCEN songCEN = new SongCEN(songCAD);
            List<SongEN> lsongs = new List<SongEN>();
            foreach(var publi in publications) {
                if (publi.Item.Type == "Song") {
                    SongEN song = songCEN.ReadOID(publi.Item.Id);
                    nullSong(song);
                    lsongs.Add(song);
                }
            }

            SessionClose();

            return lsongs;
        }

        public List<AlbumEN> getAlbums(List<PublicationEN> publications) {

            SessionInitializeTransaction();

            AlbumCAD albumCAD = new AlbumCAD(session);
            AlbumCEN albumCEN = new AlbumCEN(albumCAD);
            List<AlbumEN> lalbums = new List<AlbumEN>();
            foreach (var publi in publications) {
                if (publi.Item.Type == "Album") {
                    AlbumEN album = albumCEN.ReadOID(publi.Item.Id);
                    nullAlbum(album);
                    lalbums.Add(album);
                }
            }

            SessionClose();

            return lalbums;
        }

        public List<ArtistEN> getArtists(List<PublicationEN> publications) {

            SessionInitializeTransaction();

            ArtistCAD artistCAD = new ArtistCAD(session);
            ArtistCEN artistCEN = new ArtistCEN(artistCAD);
            List<ArtistEN> lartists = new List<ArtistEN>();
            foreach (var publi in publications) {
                if (publi.Item.Type == "Artist") {
                    ArtistEN artist = artistCEN.ReadOID(publi.Item.Id);
                    nullArtist(artist);
                    lartists.Add(artist);
                }
            }

            SessionClose();

            return lartists;
        }
    }
}
