

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
public partial class OAuthProviderCEN
{
private IOAuthProviderCAD _IOAuthProviderCAD;

public OAuthProviderCEN()
{
        this._IOAuthProviderCAD = new OAuthProviderCAD ();
}

public OAuthProviderCEN(IOAuthProviderCAD _IOAuthProviderCAD)
{
        this._IOAuthProviderCAD = _IOAuthProviderCAD;
}

public IOAuthProviderCAD get_IOAuthProviderCAD ()
{
        return this._IOAuthProviderCAD;
}

public int New_ (string p_name, string p_token_app)
{
        OAuthProviderEN oAuthProviderEN = null;
        int oid;

        //Initialized OAuthProviderEN
        oAuthProviderEN = new OAuthProviderEN ();
        oAuthProviderEN.Name = p_name;

        oAuthProviderEN.Token_app = p_token_app;

        //Call to OAuthProviderCAD

        oid = _IOAuthProviderCAD.New_ (oAuthProviderEN);
        return oid;
}

public void Destroy (int id)
{
        _IOAuthProviderCAD.Destroy (id);
}

public void Modify (int p_oid, string p_name, string p_token_app)
{
        OAuthProviderEN oAuthProviderEN = null;

        //Initialized OAuthProviderEN
        oAuthProviderEN = new OAuthProviderEN ();
        oAuthProviderEN.Id = p_oid;
        oAuthProviderEN.Name = p_name;
        oAuthProviderEN.Token_app = p_token_app;
        //Call to OAuthProviderCAD

        _IOAuthProviderCAD.Modify (oAuthProviderEN);
}

public OAuthProviderEN GetByID (int id)
{
        OAuthProviderEN oAuthProviderEN = null;

        oAuthProviderEN = _IOAuthProviderCAD.GetByID (id);
        return oAuthProviderEN;
}

public System.Collections.Generic.IList<OAuthProviderEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<OAuthProviderEN> list = null;

        list = _IOAuthProviderCAD.GetAll (first, size);
        return list;
}
}
}
