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
    public class SongCP : BasicCP
    {
        public List<SongEN> getMostPopular()
        {
            List<SongEN> mostPoular = new List<SongEN>();
            try
            {
                SessionInitializeTransaction();

                String query = "FROM SongEN ORDER BY listenedTimes DESC";
                int maxResults = 20;

                var q = session.CreateQuery(query);
                q.SetMaxResults(maxResults);

                mostPoular = (List<SongEN>)q.List<SongEN>();

                foreach (SongEN song in mostPoular)
                {
                    nullSong(song);
                }
            }
            catch (Exception ex)
            {
                SessionRollBack();
                //throw ex;
            }
            finally
            {
                SessionClose();
            }

            return mostPoular;
        }

        /// <summary>
        /// Metodo que devuelve una cancion a partir de un OID.
        /// Tambien incrementa el numero de veces que esa cancion se
        /// ha escuchado.
        /// (La cancion no esta preparada para serializarse).
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public SongEN getSong(int oid)
        {
            SongEN res = null;

            try
            {
                SessionInitializeTransaction();

                SongCAD songcad = new SongCAD(session);
                SongCEN songcen = new SongCEN(songcad);

                res = songcen.ReadOID(oid);

                if (res == null) throw new Exception();

                res.ListenedTimes++;

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                //throw ex;
            }
            finally
            {
                SessionClose();
            }

            return res;
        }
    }
}
