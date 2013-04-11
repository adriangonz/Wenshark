

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CAD.Default_;

namespace WenSharkGenNHibernate.CEN.Default_
{
public partial class OAuthUserCEN
{
private IOAuthUserCAD _IOAuthUserCAD;

public OAuthUserCEN()
{
        this._IOAuthUserCAD = new OAuthUserCAD ();
}

public OAuthUserCEN(IOAuthUserCAD _IOAuthUserCAD)
{
        this._IOAuthUserCAD = _IOAuthUserCAD;
}

public IOAuthUserCAD get_IOAuthUserCAD ()
{
        return this._IOAuthUserCAD;
}

public int New_ (string p_token_oauth, string p_name, string p_email, Nullable<DateTime> p_created, int p_provider)
{
        OAuthUserEN oAuthUserEN = null;
        int oid;

        //Initialized OAuthUserEN
        oAuthUserEN = new OAuthUserEN ();
        oAuthUserEN.Token_oauth = p_token_oauth;

        oAuthUserEN.Name = p_name;

        oAuthUserEN.Email = p_email;

        oAuthUserEN.Created = p_created;


        if (p_provider != -1) {
                oAuthUserEN.Provider = new WenSharkGenNHibernate.EN.Default_.OAuthProviderEN ();
                oAuthUserEN.Provider.Id = p_provider;
        }

        //Call to OAuthUserCAD

        oid = _IOAuthUserCAD.New_ (oAuthUserEN);
        return oid;
}

public void Modify (int p_oid, string p_token_oauth, string p_name, string p_email, Nullable<DateTime> p_created)
{
        OAuthUserEN oAuthUserEN = null;

        //Initialized OAuthUserEN
        oAuthUserEN = new OAuthUserEN ();
        oAuthUserEN.Id = p_oid;
        oAuthUserEN.Token_oauth = p_token_oauth;
        oAuthUserEN.Name = p_name;
        oAuthUserEN.Email = p_email;
        oAuthUserEN.Created = p_created;
        //Call to OAuthUserCAD

        _IOAuthUserCAD.Modify (oAuthUserEN);
}

public void Destroy (int id)
{
        _IOAuthUserCAD.Destroy (id);
}
}
}
