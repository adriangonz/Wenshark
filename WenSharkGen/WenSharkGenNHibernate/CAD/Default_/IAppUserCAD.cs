
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IAppUserCAD
{
AppUserEN ReadOIDDefault (int id);

int New_ (AppUserEN appUser);

void Destroy (int id);


void Modify (AppUserEN appUser);


System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.AppUserEN> GetByUsername (string p_filter);
}
}
