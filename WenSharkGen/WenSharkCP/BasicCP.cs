using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenSharkGenNHibernate.CAD.Default_;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkCP
{
    public class BasicCP
    {
        protected ISession session;

        protected bool sessionStarted;

        protected ITransaction tx;

        protected BasicCP()
        {
            sessionStarted = true;
        }

        protected BasicCP(ISession sessionAux)
        {
            session = sessionAux;
            sessionStarted = false;
        }

        protected void SessionInitializeTransaction()
        {
            if (session == null && sessionStarted == true)
            {
                session = NHibernateHelper.OpenSession();
                tx = session.BeginTransaction();
            }
        }

        protected void SessionCommit()
        {
            if (sessionStarted && session != null)
                tx.Commit();
        }

        protected void SessionRollBack()
        {
            if (sessionStarted && session != null && session.IsOpen)
                tx.Rollback();
        }

        protected void SessionClose()
        {
            if (sessionStarted && session != null && session.IsOpen)
            {
                session.Close();
                session.Dispose();
                session = null;
            }
        }

        protected void nullArtist(ArtistEN artist)
        {
            artist.Songs = null;
            artist.Albums = null;
            artist.Genre = null;
        }

        protected void nullAlbum(AlbumEN album)
        {
            album.Songs = null;
            album.Artist = null;
            album.Genre = null;
        }

        protected void nullSong(SongEN song)
        {
            song.Album = new AlbumEN { Name = song.Album.Name, Id = song.Album.Id, Image = song.Album.Image, Genre = null, Artist = null, Songs = null };
            song.Artist = new ArtistEN { Name = song.Artist.Name, Id = song.Artist.Id, Genre = null, Albums = null };
            song.Genre = null;
            song.Playlist = null;
            song.User = null;
        }

        protected void nullGenre(GenreEN genre)
        {
            genre.Item = null;
        }
    }
}
