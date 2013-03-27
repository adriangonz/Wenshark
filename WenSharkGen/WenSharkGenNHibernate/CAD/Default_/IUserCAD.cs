
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IUserCAD
{
UserEN ReadOIDDefault (int id);

int New_ (UserEN user);

void Destroy (int id);


void Modify (UserEN user);


UserEN GetByID (int id);


System.Collections.Generic.IList<UserEN> GetAll (int first, int size);


System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.UserEN> Search (string p_filter);
}
}