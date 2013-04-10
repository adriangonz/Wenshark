
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
public WenSharkGenNHibernate.EN.Default_.ArtistEN GetArtist (WenSharkGenNHibernate.EN.Default_.SongEN song)
{
        /*PROTECTED REGION ID(WenSharkGenNHibernate.CEN.Default__Song_getArtist) ENABLED START*/

        // Write here your custom code...
        ArtistEN artistaEN = null;

        if (song.Artist != null) {
                ArtistCEN artistCEN = new ArtistCEN ();
                artistaEN = artistCEN.ReadOID (song.Artist.Id);
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
