
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

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist;





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


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> Playlist {
        get { return playlist; } set { playlist = value;  }
}





public UserEN()
{
        playlist = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.PlayListEN>();
}



public UserEN(int id, string name, string email, Nullable<DateTime> created, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist)
{
        this.init (id, name, email, created, playlist);
}


public UserEN(UserEN user)
{
        this.init (user.Id, user.Name, user.Email, user.Created, user.Playlist);
}

private void init (int id, string name, string email, Nullable<DateTime> created, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist)
{
        this.Id = id;


        this.Name = name;

        this.Email = email;

        this.Created = created;

        this.Playlist = playlist;
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
