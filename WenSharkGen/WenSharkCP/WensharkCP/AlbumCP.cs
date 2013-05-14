using NHibernate;
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
    public class AlbumCP : BasicCP
    {
        public AlbumCP() : base() { }

        public AlbumCP(ISession sess) : base(sess) { }

        public AlbumEN getAlbum(int oid)
        {
            AlbumEN album = null;
            try
            {
                SessionInitializeTransaction();

                AlbumCAD albumcad = new AlbumCAD(session);
                AlbumCEN albumcen = new AlbumCEN(albumcad);

                album = albumcen.ReadOID(oid);

                if (album == null) throw new Exception();

                foreach(SongEN song in album.Songs)
                {
                    nullSong(song);
                }

                foreach (GenreEN genre in album.Genre)
                {
                    nullGenre(genre);
                }

                nullArtist(album.Artist);
                album.Publication = null;

                //No queremos que se modifique la BD
                //SessionCommit();
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

            return album;
        }
    }
}
