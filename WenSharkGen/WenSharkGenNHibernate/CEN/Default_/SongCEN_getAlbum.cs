
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CAD.Default_;

namespace WenSharkGenNHibernate.CEN.Default_
{
public partial class SongCEN
{
public WenSharkGenNHibernate.EN.Default_.AlbumEN GetAlbum (WenSharkGenNHibernate.EN.Default_.SongEN song)
{
        /*PROTECTED REGION ID(WenSharkGenNHibernate.CEN.Default__Song_getAlbum) ENABLED START*/

        AlbumEN albumEN = null;

        if (song.Album != null) {
                AlbumCEN albumCEN = new AlbumCEN ();
                albumEN = albumCEN.ReadOID (song.Album.Id);
                if (albumEN != null) {
                    albumEN.Genre = null;
                    albumEN.Artist = null;
                    albumEN.Songs = null;
                }
        }

        return albumEN;


        /*PROTECTED REGION END*/
}
}
}
