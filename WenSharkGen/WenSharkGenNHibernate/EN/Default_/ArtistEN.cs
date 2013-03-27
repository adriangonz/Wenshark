
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class ArtistEN                   :                           WenSharkGenNHibernate.EN.Default_.ItemEN


{
/**
 *
 */

private string bio;

/**
 *
 */

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> songs;

/**
 *
 */

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.AlbumEN> albums;





public virtual string Bio {
        get { return bio; } set { bio = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> Songs {
        get { return songs; } set { songs = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.AlbumEN> Albums {
        get { return albums; } set { albums = value;  }
}





public ArtistEN() : base ()
{
        songs = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.SongEN>();
        albums = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.AlbumEN>();
}



public ArtistEN(int id, string bio, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> songs, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.AlbumEN> albums, string name, Nullable<DateTime> created, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre)
{
        this.init (id, bio, songs, albums, name, created, genre);
}


public ArtistEN(ArtistEN artist)
{
        this.init (artist.Id, artist.Bio, artist.Songs, artist.Albums, artist.Name, artist.Created, artist.Genre);
}

private void init (int id, string bio, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> songs, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.AlbumEN> albums, string name, Nullable<DateTime> created, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.GenreEN> genre)
{
        this.Id = id;


        this.Bio = bio;

        this.Songs = songs;

        this.Albums = albums;

        this.Name = name;

        this.Created = created;

        this.Genre = genre;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ArtistEN t = obj as ArtistEN;
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