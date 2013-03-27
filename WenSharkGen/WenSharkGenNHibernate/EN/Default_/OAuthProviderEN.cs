
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class OAuthProviderEN
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

private string token_app;

/**
 *
 */

private System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.OAuthUserEN> users;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Name {
        get { return name; } set { name = value;  }
}


public virtual string Token_app {
        get { return token_app; } set { token_app = value;  }
}


public virtual System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.OAuthUserEN> Users {
        get { return users; } set { users = value;  }
}





public OAuthProviderEN()
{
        users = new System.Collections.Generic.List<WenSharkGenNHibernate.EN.Default_.OAuthUserEN>();
}



public OAuthProviderEN(int id, string name, string token_app, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.OAuthUserEN> users)
{
        this.init (id, name, token_app, users);
}


public OAuthProviderEN(OAuthProviderEN oAuthProvider)
{
        this.init (oAuthProvider.Id, oAuthProvider.Name, oAuthProvider.Token_app, oAuthProvider.Users);
}

private void init (int id, string name, string token_app, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.OAuthUserEN> users)
{
        this.Id = id;


        this.Name = name;

        this.Token_app = token_app;

        this.Users = users;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        OAuthProviderEN t = obj as OAuthProviderEN;
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
