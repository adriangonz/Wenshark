
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class SongEN                     :                           WenSharkGenNHibernate.EN.Default_.ItemEN


{
/**
 *
 */

private string fname;

/**
 *
 */

private string mime;

/**
 *
 */

private WenSharkGenNHibernate.EN.Default_.ArtistEN artist;

/**
 *
 */

private WenSharkGenNHibernate.EN.Default_.AlbumEN album;





public virtual string Fname {
        get { return fname; } set { fname = value;  }
}


public virtual string Mime {
        get { return mime; } set { mime = value;  }
}


public virtual WenSharkGenNHibernate.EN.Default_.ArtistEN Artist {
        get { return artist; } set { artist = value;  }
}


public virtual WenSharkGenNHibernate.EN.Default_.AlbumEN Album {
        get { return album; } set { album = value;  }
}





public SongEN() : base ()
{
}



public SongEN(int id, string fname, string mime, WenSharkGenNHibernate.EN.Default_.ArtistEN artist, WenSharkGenNHibernate.EN.Default_.AlbumEN album, string name, Nullable<DateTime> created, string type, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre)
{
        this.init (id, fname, mime, artist, album, name, created, type, genre);
}


public SongEN(SongEN song)
{
        this.init (song.Id, song.Fname, song.Mime, song.Artist, song.Album, song.Name, song.Created, song.Type, song.Genre);
}

private void init (int id, string fname, string mime, WenSharkGenNHibernate.EN.Default_.ArtistEN artist, WenSharkGenNHibernate.EN.Default_.AlbumEN album, string name, Nullable<DateTime> created, string type, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre)
{
        this.Id = id;


        this.Fname = fname;

        this.Mime = mime;

        this.Artist = artist;

        this.Album = album;

        this.Name = name;

        this.Created = created;

        this.Type = type;

        this.Genre = genre;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SongEN t = obj as SongEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
