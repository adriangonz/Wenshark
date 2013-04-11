
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface ISongCAD
{
SongEN ReadOIDDefault (int id);

int New_ (SongEN song);

SongEN ReadOID (int id);



void Destroy (int id);


void Modify (SongEN song);


System.Collections.Generic.IList<SongEN> GetAll (int first, int size);





System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.SongEN> Search (string p_filter);
}
}
