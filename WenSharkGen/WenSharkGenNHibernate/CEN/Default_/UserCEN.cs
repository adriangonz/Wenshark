

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
public partial class UserCEN
{
private IUserCAD _IUserCAD;

public UserCEN()
{
        this._IUserCAD = new UserCAD ();
}

public UserCEN(IUserCAD _IUserCAD)
{
        this._IUserCAD = _IUserCAD;
}

public IUserCAD get_IUserCAD ()
{
        return this._IUserCAD;
}

public int New_ (string p_name, string p_username, string p_email, Nullable<DateTime> p_created)
{
        UserEN userEN = null;
        int oid;

        //Initialized UserEN
        userEN = new UserEN ();
        userEN.Name = p_name;

        userEN.Username = p_username;

        userEN.Email = p_email;

        userEN.Created = p_created;

        //Call to UserCAD

        oid = _IUserCAD.New_ (userEN);
        return oid;
}

public void Destroy (int id)
{
        _IUserCAD.Destroy (id);
}

public void Modify (int p_oid, string p_name, string p_username, string p_email, Nullable<DateTime> p_created)
{
        UserEN userEN = null;

        //Initialized UserEN
        userEN = new UserEN ();
        userEN.Id = p_oid;
        userEN.Name = p_name;
        userEN.Username = p_username;
        userEN.Email = p_email;
        userEN.Created = p_created;
        //Call to UserCAD

        _IUserCAD.Modify (userEN);
}

public UserEN GetByID (int id)
{
        UserEN userEN = null;

        userEN = _IUserCAD.GetByID (id);
        return userEN;
}

public System.Collections.Generic.IList<UserEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<UserEN> list = null;

        list = _IUserCAD.GetAll (first, size);
        return list;
}
public System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> Search (string p_filter)
{
        return _IUserCAD.Search (p_filter);
}
}
}
