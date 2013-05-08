using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenSharkGenNHibernate.CAD.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkCP.WensharkCP {
    public class FavoritesCP : BasicCP {
        public List<SongEN> getUserFavorites(int user_id) {

            List<SongEN> lsongs = null;

            SessionInitializeTransaction();

            UserCAD userCAD = new UserCAD(session);
            UserCEN userCEN = new UserCEN(userCAD);

            UserEN user = userCEN.GetByID(user_id);
            if(user != null)
                lsongs = user.Favorites.ToList();

            foreach(SongEN s in lsongs){
                nullSong(s);
            }

            SessionClose();

            return lsongs;
        }

        public Boolean removeUserFavorite(int user_id, int song_id) {

            List<int> lsongs = null;

            SessionInitializeTransaction();

            UserCAD userCAD = new UserCAD(session);
            UserCEN userCEN = new UserCEN(userCAD);
            UserEN user = userCEN.GetByID(user_id);
            if (user == null)
                return false;
            
            SongCAD songCAD = new SongCAD(session);
            SongCEN songCEN = new SongCEN(songCAD);
            SongEN song = songCEN.ReadOID(song_id);
            if (song == null)
                return false;

            lsongs = new List<int>();
            lsongs.Add(song_id);

            userCAD.Unrelationer_favorites(user_id, lsongs);

            SessionCommit();
            SessionClose();

            return true;

        }

    }
}
