
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IItemCAD
{
ItemEN ReadOIDDefault (int id);

int New_ (ItemEN item);

void Destroy (int id);


void Modify (ItemEN item);


ItemEN GetByID (int id);


System.Collections.Generic.IList<ItemEN> GetAll (int first, int size);


System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.ItemEN> Search (string p_filter);
}
}