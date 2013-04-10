
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
public partial class AlbumCEN
{
public WenSharkGenNHibernate.EN.Default_.ArtistEN GetArtist (WenSharkGenNHibernate.EN.Default_.AlbumEN album)
{
        /*PROTECTED REGION ID(WenSharkGenNHibernate.CEN.Default__Album_getArtist) ENABLED START*/

        // Write here your custom code...
        ArtistEN artistaEN = null;

        if (album.Artist != null) {
                ArtistCEN artistCEN = new ArtistCEN ();
                artistaEN = artistCEN.ReadOID (album.Artist.Id);
                if (artistaEN != null) {
                        artistaEN.Albums = null;
                        artistaEN.Songs = null;
                        artistaEN.Genre = null;
                }
        }

        return artistaEN;

        /*PROTECTED REGION END*/
}
}
}
