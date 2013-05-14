
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

private int listenedTimes;

/**
 *
 */

private WenSharkGenNHibernate.EN.Default_.ArtistEN artist;

/**
 *
 */

private WenSharkGenNHibernate.EN.Default_.AlbumEN album;

/**
 *
 */

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist;

/**
 *
 */

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> user;





public virtual string Fname {
        get { return fname; } set { fname = value;  }
}


public virtual string Mime {
        get { return mime; } set { mime = value;  }
}


public virtual int ListenedTimes {
        get { return listenedTimes; } set { listenedTimes = value;  }
}


public virtual WenSharkGenNHibernate.EN.Default_.ArtistEN Artist {
        get { return artist; } set { artist = value;  }
}


public virtual WenSharkGenNHibernate.EN.Default_.AlbumEN Album {
        get { return album; } set { album = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> Playlist {
        get { return playlist; } set { playlist = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> User {
        get { return user; } set { user = value;  }
}





public SongEN() : base ()
{
        playlist = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.PlayListEN>();
        user = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.UserEN>();
}



public SongEN(int id, string fname, string mime, int listenedTimes, WenSharkGenNHibernate.EN.Default_.ArtistEN artist, WenSharkGenNHibernate.EN.Default_.AlbumEN album, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> user, string name, Nullable<DateTime> created, string type, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PublicationEN> publication)
{
        this.init (id, fname, mime, listenedTimes, artist, album, playlist, user, name, created, type, genre, publication);
}


public SongEN(SongEN song)
{
        this.init (song.Id, song.Fname, song.Mime, song.ListenedTimes, song.Artist, song.Album, song.Playlist, song.User, song.Name, song.Created, song.Type, song.Genre, song.Publication);
}

private void init (int id, string fname, string mime, int listenedTimes, WenSharkGenNHibernate.EN.Default_.ArtistEN artist, WenSharkGenNHibernate.EN.Default_.AlbumEN album, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> user, string name, Nullable<DateTime> created, string type, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PublicationEN> publication)
{
        this.Id = id;


        this.Fname = fname;

        this.Mime = mime;

        this.ListenedTimes = listenedTimes;

        this.Artist = artist;

        this.Album = album;

        this.Playlist = playlist;

        this.User = user;

        this.Name = name;

        this.Created = created;

        this.Type = type;

        this.Genre = genre;

        this.Publication = publication;
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
