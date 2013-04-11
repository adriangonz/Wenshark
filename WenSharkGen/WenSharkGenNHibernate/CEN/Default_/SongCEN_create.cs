
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
public WenSharkGenNHibernate.EN.Default_.SongEN Create (string name, string fname, string mime, int artist, int album)
{
        /*PROTECTED REGION ID(WenSharkGenNHibernate.CEN.Default__Song_create) ENABLED START*/

        SongEN songEN = new SongEN ();

        songEN.Type = "Song";

        songEN.Name = name;
        songEN.Fname = fname;
        songEN.Mime = mime;
        songEN.Created = DateTime.Now;

        if (artist != -1) {
                songEN.Artist = new ArtistEN ();
                songEN.Artist.Id = artist;
        }

        if (album != -1) {
                songEN.Album = new AlbumEN ();
                songEN.Album.Id = album;
        }

        songEN.Id = _ISongCAD.New_ (songEN);
        return songEN;

        /*PROTECTED REGION END*/
}
}
}
