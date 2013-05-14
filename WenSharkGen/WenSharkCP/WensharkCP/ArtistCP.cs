using NHibernate;
using NHibernate.Criterion;
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
    public class ArtistCP : BasicCP
    {
        public ArtistCP() : base() { }

        public ArtistCP(ISession sess) : base(sess) { }

        public ArtistEN getArtist(int oid)
        {
            ArtistEN artista = null;
            try
            {
                SessionInitializeTransaction();

                ArtistCAD artistcad = new ArtistCAD(session);
                ArtistCEN artistcen = new ArtistCEN(artistcad);

                //Obtenemos el artista
                artista = artistcen.ReadOID(oid);

                if (artista == null) throw new Exception();

                //Setteamos a null las relaciones que van mas alla de lo que
                //queremos (dependencias circulares)
                foreach(SongEN song in artista.Songs)
                {
                    nullSong(song);
                }

                foreach (AlbumEN alb in artista.Albums)
                {
                    nullAlbum(alb);
                }

                foreach (GenreEN genre in artista.Genre)
                {
                    nullGenre(genre);
                }

                artista.Publication = null;
                //No queremos que se modifique la BD
                //SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }

            return artista;
        }
    }
}
