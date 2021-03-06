
using System;

namespace WenSharkGenNHibernate.EN.Default_
{
public partial class OAuthUserEN                :                           WenSharkGenNHibernate.EN.Default_.UserEN


{
/**
 *
 */

private string idOAuth;

/**
 *
 */

private string token_oauth;

/**
 *
 */

private WenSharkGenNHibernate.EN.Default_.OAuthProviderEN provider;





public virtual string IdOAuth {
        get { return idOAuth; } set { idOAuth = value;  }
}


public virtual string Token_oauth {
        get { return token_oauth; } set { token_oauth = value;  }
}


public virtual WenSharkGenNHibernate.EN.Default_.OAuthProviderEN Provider {
        get { return provider; } set { provider = value;  }
}





public OAuthUserEN() : base ()
{
}



public OAuthUserEN(int id, string idOAuth, string token_oauth, WenSharkGenNHibernate.EN.Default_.OAuthProviderEN provider, string name, string email, Nullable<DateTime> created, string image, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> sigues, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> seguidores, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> favorites, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PublicationEN> publication)
{
        this.init (id, idOAuth, token_oauth, provider, name, email, created, image, sigues, seguidores, playlist, favorites, publication);
}


public OAuthUserEN(OAuthUserEN oAuthUser)
{
        this.init (oAuthUser.Id, oAuthUser.IdOAuth, oAuthUser.Token_oauth, oAuthUser.Provider, oAuthUser.Name, oAuthUser.Email, oAuthUser.Created, oAuthUser.Image, oAuthUser.Sigues, oAuthUser.Seguidores, oAuthUser.Playlist, oAuthUser.Favorites, oAuthUser.Publication);
}

private void init (int id, string idOAuth, string token_oauth, WenSharkGenNHibernate.EN.Default_.OAuthProviderEN provider, string name, string email, Nullable<DateTime> created, string image, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> sigues, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> seguidores, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PlayListEN> playlist, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> favorites, System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.PublicationEN> publication)
{
        this.Id = id;


        this.IdOAuth = idOAuth;

        this.Token_oauth = token_oauth;

        this.Provider = provider;

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
