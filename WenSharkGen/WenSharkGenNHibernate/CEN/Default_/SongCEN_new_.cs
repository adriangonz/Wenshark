
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
public WenSharkGenNHibernate.EN.Default_.SongEN New_ (string name, string fname, int artist, int album)
{
        /*PROTECTED REGION ID(WenSharkGenNHibernate.CEN.Default__Song_new_) ENABLED START*/

        SongEN songEN = new SongEN();

        songEN.Name = name;
        songEN.Fname = fname;

        songEN.Created = DateTime.Now;

        if (artist != -1)
        {
            songEN.Artist = new WenSharkGenNHibernate.EN.Default_.ArtistEN();
            songEN.Artist.Id = artist;
        }

        if (album != -1)
        {
            songEN.Album = new WenSharkGenNHibernate.EN.Default_.AlbumEN();
            songEN.Album.Id = album;
        }

        

    
        /*PROTECTED REGION END*/
}
}
}


/*
SongEN songEN = null;
int oid;

//Initialized SongEN
songEN = new SongEN ();
songEN.Fname = p_fname;

songEN.Name = p_name;

songEN.Created = p_created;


if (p_artist != -1) {
        songEN.Artist = new WenSharkGenNHibernate.EN.Default_.ArtistEN ();
        songEN.Artist.Id = p_artist;
}


if (p_album != -1) {
        songEN.Album = new WenSharkGenNHibernate.EN.Default_.AlbumEN ();
        songEN.Album.Id = p_album;
}

//Call to SongCAD

oid = _ISongCAD.New_ (songEN);
return oid;
*/