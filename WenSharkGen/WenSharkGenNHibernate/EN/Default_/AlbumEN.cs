
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class AlbumEN                    :                           WenSharkGenNHibernate.EN.Default_.ItemEN


{
/**
 *
 */

private Nullable<DateTime> published;

/**
 *
 */

private WenSharkGenNHibernate.EN.Default_.ArtistEN artist;

/**
 *
 */

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> songs;





public virtual Nullable<DateTime> Published {
        get { return published; } set { published = value;  }
}


public virtual WenSharkGenNHibernate.EN.Default_.ArtistEN Artist {
        get { return artist; } set { artist = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> Songs {
        get { return songs; } set { songs = value;  }
}





public AlbumEN() : base ()
{
        songs = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.SongEN>();
}



public AlbumEN(int id, Nullable<DateTime> published, WenSharkGenNHibernate.EN.Default_.ArtistEN artist, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> songs, string name, Nullable<DateTime> created, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre)
{
        this.init (id, published, artist, songs, name, created, genre);
}


public AlbumEN(AlbumEN album)
{
        this.init (album.Id, album.Published, album.Artist, album.Songs, album.Name, album.Created, album.Genre);
}

private void init (int id, Nullable<DateTime> published, WenSharkGenNHibernate.EN.Default_.ArtistEN artist, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> songs, string name, Nullable<DateTime> created, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre)
{
        this.Id = id;


        this.Published = published;

        this.Artist = artist;

        this.Songs = songs;

        this.Name = name;

        this.Created = created;

        this.Genre = genre;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AlbumEN t = obj as AlbumEN;
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
