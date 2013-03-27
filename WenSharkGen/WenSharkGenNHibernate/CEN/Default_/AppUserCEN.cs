

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
public partial class AppUserCEN
{
private IAppUserCAD _IAppUserCAD;

public AppUserCEN()
{
        this._IAppUserCAD = new AppUserCAD ();
}

public AppUserCEN(IAppUserCAD _IAppUserCAD)
{
        this._IAppUserCAD = _IAppUserCAD;
}

public IAppUserCAD get_IAppUserCAD ()
{
        return this._IAppUserCAD;
}

public int New_ (string p_password, string p_name, string p_username, string p_email)
{
        AppUserEN appUserEN = null;
        int oid;

        //Initialized AppUserEN
        appUserEN = new AppUserEN ();
        appUserEN.Password = p_password;

        appUserEN.Name = p_name;

        appUserEN.Username = p_username;

        appUserEN.Email = p_email;

        //Call to AppUserCAD

        oid = _IAppUserCAD.New_ (appUserEN);
        return oid;
}

public void Destroy (int id)
{
        _IAppUserCAD.Destroy (id);
}

public void Modify (int p_oid, string p_password, string p_name, string p_username, string p_email, Nullable<DateTime> p_created)
{
        AppUserEN appUserEN = null;

        //Initialized AppUserEN
        appUserEN = new AppUserEN ();
        appUserEN.Id = p_oid;
        appUserEN.Password = p_password;
        appUserEN.Name = p_name;
        appUserEN.Username = p_username;
        appUserEN.Email = p_email;
        appUserEN.Created = p_created;
        //Call to AppUserCAD

        _IAppUserCAD.Modify (appUserEN);
}
}
}
