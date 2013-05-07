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
    public class UserCP  : BasicCP
    {
        public UserEN getUser(int oid)
        {
            UserEN user = null;

            try
            {
                SessionInitializeTransaction();

                UserCAD usercad = new UserCAD(session);
                UserCEN usercen = new UserCEN(usercad);

                user = usercen.GetByID(oid);

                if (user == null) throw new Exception();

                //TODO (Adri): Cargar y mostrar las playlists
                user.Playlist = null;
            }
            catch (Exception ex)
            {
                SessionRollBack();
            }
            finally
            {
                SessionClose();
            }


            return user;
        }
    }
}
