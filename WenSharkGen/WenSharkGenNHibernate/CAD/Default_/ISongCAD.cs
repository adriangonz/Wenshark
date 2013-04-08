
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface ISongCAD
{
SongEN ReadOIDDefault (int id);

int New_ (SongEN song);

void Destroy (int id);


void Modify (SongEN song);


System.Collections.Generic.IList<SongEN> ReadAll (int first, int size);
}
}
