
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class AppUserEN                  :                           WenSharkGenNHibernate.EN.Default_.UserEN


{
/**
 *
 */

private string username;

/**
 *
 */

private string password;





public virtual string Username {
        get { return username; } set { username = value;  }
}


public virtual string Password {
        get { return password; } set { password = value;  }
}





public AppUserEN() : base ()
{
}



public AppUserEN(int id, string username, string password, string name, string email, Nullable<DateTime> created, string image, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> sigues, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> seguidores, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> favorites, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PublicationEN> publication)
{
        this.init (id, username, password, name, email, created, image, sigues, seguidores, playlist, favorites, publication);
}


public AppUserEN(AppUserEN appUser)
{
        this.init (appUser.Id, appUser.Username, appUser.Password, appUser.Name, appUser.Email, appUser.Created, appUser.Image, appUser.Sigues, appUser.Seguidores, appUser.Playlist, appUser.Favorites, appUser.Publication);
}

private void init (int id, string username, string password, string name, string email, Nullable<DateTime> created, string image, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> sigues, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> seguidores, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> favorites, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PublicationEN> publication)
{
        this.Id = id;


        this.Username = username;

        this.Password = password;

        this.Name = name;

        this.Email = email;

        this.Created = created;

        this.Image = image;

        this.Sigues = sigues;

        this.Seguidores = seguidores;

        this.Playlist = playlist;

        this.Favorites = favorites;

        this.Publication = publication;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AppUserEN t = obj as AppUserEN;
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
