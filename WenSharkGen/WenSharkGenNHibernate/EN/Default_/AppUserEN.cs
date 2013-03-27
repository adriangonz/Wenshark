
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class AppUserEN                  :                           WenSharkGenNHibernate.EN.Default_.UserEN


{
/**
 *
 */

private string password;





public virtual string Password {
        get { return password; } set { password = value;  }
}





public AppUserEN() : base ()
{
}



public AppUserEN(int id, string password, string name, string username, string email, Nullable<DateTime> created)
{
        this.init (id, password, name, username, email, created);
}


public AppUserEN(AppUserEN appUser)
{
        this.init (appUser.Id, appUser.Password, appUser.Name, appUser.Username, appUser.Email, appUser.Created);
}

private void init (int id, string password, string name, string username, string email, Nullable<DateTime> created)
{
        this.Id = id;


        this.Password = password;

        this.Name = name;

        this.Username = username;

        this.Email = email;

        this.Created = created;
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
