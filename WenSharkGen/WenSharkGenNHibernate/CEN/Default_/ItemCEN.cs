

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
public partial class ItemCEN
{
private IItemCAD _IItemCAD;

public ItemCEN()
{
        this._IItemCAD = new ItemCAD ();
}

public ItemCEN(IItemCAD _IItemCAD)
{
        this._IItemCAD = _IItemCAD;
}

public IItemCAD get_IItemCAD ()
{
        return this._IItemCAD;
}

public ItemEN GetByID (int id)
{
        ItemEN itemEN = null;

        itemEN = _IItemCAD.GetByID (id);
        return itemEN;
}

public System.Collections.Generic.IList<ItemEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<ItemEN> list = null;

        list = _IItemCAD.GetAll (first, size);
        return list;
}
public System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.ItemEN> GetByName (string p_filter)
{
        return _IItemCAD.GetByName (p_filter);
}
public System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.ItemEN> Search (string p_filter)
{
        return _IItemCAD.Search (p_filter);
}
}
}
