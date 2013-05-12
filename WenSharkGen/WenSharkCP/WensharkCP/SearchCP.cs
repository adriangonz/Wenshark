using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenSharkGenNHibernate.CAD.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.EN.Default_;


namespace WenSharkCP.WensharkCP
{
    public class SearchCP : BasicCP
    {
        public List<SongEN> searchSong(string name)
        {
            SessionInitializeTransaction();
            SongCAD songCAD = new SongCAD(session);
            SongCEN songCEN = new SongCEN(songCAD);

            List<SongEN> resul = songCEN.Search(name).ToList();

            foreach (var song in resul)
            {
                nullSong(song);
            }

            SessionClose();
            return resul;
        }

        public List<ArtistEN> searchArtist(string name)
        {
            SessionInitializeTransaction();
            ArtistCAD artistCAD = new ArtistCAD(session);
            ArtistCEN artistCEN = new ArtistCEN(artistCAD);

            List<ArtistEN> resul = artistCEN.Search(name).ToList();

            foreach (var item in resul)
            {
                nullArtist(item);
            }

            SessionClose();
            return resul;
        }

        public List<AlbumEN> searchAlbum(string name)
        {
            SessionInitializeTransaction();
            List<AlbumEN> resul;
            AlbumCAD albumCAD = new AlbumCAD(session);
            AlbumCEN albumCEN = new AlbumCEN(albumCAD);

            resul = albumCEN.Search(name).ToList();

            foreach (var item in resul)
            {
                nullAlbum(item);
            }

            SessionClose();
            return resul;
        }

        public List<UserEN> searchUsers(string name)
        {
            SessionInitializeTransaction();
            List<UserEN> resul = new List<UserEN>();
            UserCAD userCAD = new UserCAD(session);
            UserCEN userCEN = new UserCEN(userCAD);

            resul = userCEN.Search(name).ToList();

            foreach (var item in resul)
            {
                nullUser(item);
            }
            SessionClose();
            return resul;
        }
 
    }
}
