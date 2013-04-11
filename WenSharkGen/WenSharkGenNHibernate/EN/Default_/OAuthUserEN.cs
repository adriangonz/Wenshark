
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class OAuthUserEN                :                           WenSharkGenNHibernate.EN.Default_.UserEN


{
/**
 *
 */

private string token_oauth;

/**
 *
 */

private WenSharkGenNHibernate.EN.Default_.OAuthProviderEN provider;





public virtual string Token_oauth {
        get { return token_oauth; } set { token_oauth = value;  }
}


public virtual WenSharkGenNHibernate.EN.Default_.OAuthProviderEN Provider {
        get { return provider; } set { provider = value;  }
}





public OAuthUserEN() : base ()
{
}



public OAuthUserEN(int id, string token_oauth, WenSharkGenNHibernate.EN.Default_.OAuthProviderEN provider, string name, string email, Nullable<DateTime> created)
{
        this.init (id, token_oauth, provider, name, email, created);
}


public OAuthUserEN(OAuthUserEN oAuthUser)
{
        this.init (oAuthUser.Id, oAuthUser.Token_oauth, oAuthUser.Provider, oAuthUser.Name, oAuthUser.Email, oAuthUser.Created);
}

private void init (int id, string token_oauth, WenSharkGenNHibernate.EN.Default_.OAuthProviderEN provider, string name, string email, Nullable<DateTime> created)
{
        this.Id = id;


        this.Token_oauth = token_oauth;

        this.Provider = provider;

        this.Name = name;

        this.Email = email;

        this.Created = created;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        OAuthUserEN t = obj as OAuthUserEN;
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
