

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
public void AddNewPlayList (int p_user, System.Collections.Generic.IList<int> p_playlist)
{
        //Call to UserCAD

        _IUserCAD.AddNewPlayList (p_user, p_playlist);
}
public void AddNewPublication (int p_user, System.Collections.Generic.IList<int> p_publication)
{
        //Call to UserCAD

        _IUserCAD.AddNewPublication (p_user, p_publication);
}
}
}
