
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

private string image;

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


public virtual string Image {
        get { return image; } set { image = value;  }
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



public AlbumEN(int id, Nullable<DateTime> published, string image, WenSharkGenNHibernate.EN.Default_.ArtistEN artist, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> songs, string name, Nullable<DateTime> created, string type, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> user)
{
        this.init (id, published, image, artist, songs, name, created, type, genre, user);
}


public AlbumEN(AlbumEN album)
{
        this.init (album.Id, album.Published, album.Image, album.Artist, album.Songs, album.Name, album.Created, album.Type, album.Genre, album.User);
}

private void init (int id, Nullable<DateTime> published, string image, WenSharkGenNHibernate.EN.Default_.ArtistEN artist, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> songs, string name, Nullable<DateTime> created, string type, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> user)
{
        this.Id = id;


        this.Published = published;

        this.Image = image;

        this.Artist = artist;

        this.Songs = songs;

        this.Name = name;

        this.Created = created;

        this.Type = type;

        this.Genre = genre;

        this.User = user;
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
