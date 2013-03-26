

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

public int New_ (string p_name, Nullable<DateTime> p_created)
{
        ItemEN itemEN = null;
        int oid;

        //Initialized ItemEN
        itemEN = new ItemEN ();
        itemEN.Name = p_name;

        itemEN.Created = p_created;

        //Call to ItemCAD

        oid = _IItemCAD.New_ (itemEN);
        return oid;
}

public void Destroy (int id)
{
        _IItemCAD.Destroy (id);
}

public void Modify (int p_oid, string p_name, Nullable<DateTime> p_created)
{
        ItemEN itemEN = null;

        //Initialized ItemEN
        itemEN = new ItemEN ();
        itemEN.Id = p_oid;
        itemEN.Name = p_name;
        itemEN.Created = p_created;
        //Call to ItemCAD

        _IItemCAD.Modify (itemEN);
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
public System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.ItemEN> Search (string p_filter)
{
        return _IItemCAD.Search (p_filter);
}
}
}
