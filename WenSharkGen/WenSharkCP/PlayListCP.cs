using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using WenSharkGenNHibernate.CAD.Default_;

namespace WenSharkCP
{
    public class PlayListCP : BasicCP
    {
        public List<PlayListEN> getByUser(int idUser)
        {
            List<PlayListEN> lplaylist = new List<PlayListEN>();
            SessionInitializeTransaction();
           

            UserCAD userCAD = new UserCAD(session);
            UserCEN userCEN = new UserCEN(userCAD);

            UserEN user = userCEN.GetByID(idUser);

            if (user != null)
            {
                lplaylist = user.Playlist.ToList();
            }

            SessionClose();

            foreach (var item in lplaylist)
            {
                item.Song = null;
                item.User = null;
            }
            
            return lplaylist;
        }
    }
}
