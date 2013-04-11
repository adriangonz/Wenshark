

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
private ISongCAD _ISongCAD;

public SongCEN()
{
        this._ISongCAD = new SongCAD ();
}

public SongCEN(ISongCAD _ISongCAD)
{
        this._ISongCAD = _ISongCAD;
}

public ISongCAD get_ISongCAD ()
{
        return this._ISongCAD;
}

public int New_ (string p_fname, string p_mime, string p_name, Nullable<DateTime> p_created, string p_type, int p_artist, int p_album)
{
        SongEN songEN = null;
        int oid;

        //Initialized SongEN
        songEN = new SongEN ();
        songEN.Fname = p_fname;

        songEN.Mime = p_mime;

        songEN.Name = p_name;

        songEN.Created = p_created;

        songEN.Type = p_type;


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
}

public SongEN ReadOID (int id)
{
        SongEN songEN = null;

        songEN = _ISongCAD.ReadOID (id);
        return songEN;
}

public void Destroy (int id)
{
        _ISongCAD.Destroy (id);
}

public void Modify (int p_oid, string p_fname, string p_mime, string p_name, string p_type)
{
        SongEN songEN = null;

        //Initialized SongEN
        songEN = new SongEN ();
        songEN.Id = p_oid;
        songEN.Fname = p_fname;
        songEN.Mime = p_mime;
        songEN.Name = p_name;
        songEN.Type = p_type;
        //Call to SongCAD

        _ISongCAD.Modify (songEN);
}

public System.Collections.Generic.IList<SongEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<SongEN> list = null;

        list = _ISongCAD.GetAll (first, size);
        return list;
}
public System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> Search (string p_filter)
{
        return _ISongCAD.Search (p_filter);
}
}
}
