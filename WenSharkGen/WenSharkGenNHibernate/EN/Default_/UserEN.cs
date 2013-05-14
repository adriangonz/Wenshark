
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class UserEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string name;

/**
 *
 */

private string email;

/**
 *
 */

private Nullable<DateTime> created;

/**
 *
 */

private string image;

/**
 *
 */

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> sigues;

/**
 *
 */

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> seguidores;

/**
 *
 */

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist;

/**
 *
 */

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> favorites;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Name {
        get { return name; } set { name = value;  }
}


public virtual string Email {
        get { return email; } set { email = value;  }
}


public virtual Nullable<DateTime> Created {
        get { return created; } set { created = value;  }
}


public virtual string Image {
        get { return image; } set { image = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> Sigues {
        get { return sigues; } set { sigues = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> Seguidores {
        get { return seguidores; } set { seguidores = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> Playlist {
        get { return playlist; } set { playlist = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> Favorites {
        get { return favorites; } set { favorites = value;  }
}





public UserEN()
{
        sigues = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.UserEN>();
        seguidores = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.UserEN>();
        playlist = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.PlayListEN>();
        favorites = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.SongEN>();
}



public UserEN(int id, string name, string email, Nullable<DateTime> created, string image, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> sigues, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> seguidores, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> favorites)
{
        this.init (id, name, email, created, image, sigues, seguidores, playlist, favorites);
}


public UserEN(UserEN user)
{
        this.init (user.Id, user.Name, user.Email, user.Created, user.Image, user.Sigues, user.Seguidores, user.Playlist, user.Favorites);
}

private void init (int id, string name, string email, Nullable<DateTime> created, string image, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> sigues, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> seguidores, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> favorites)
{
        this.Id = id;


        this.Name = name;

        this.Email = email;

        this.Created = created;

        this.Image = image;

        this.Sigues = sigues;

        this.Seguidores = seguidores;

        this.Playlist = playlist;

        this.Favorites = favorites;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UserEN t = obj as UserEN;
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
