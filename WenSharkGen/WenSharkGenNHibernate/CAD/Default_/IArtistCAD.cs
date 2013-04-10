
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IArtistCAD
{
ArtistEN ReadOIDDefault (int id);

int New_ (ArtistEN artist);

ArtistEN ReadOID (int id);



void Destroy (int id);


void Modify (ArtistEN artist);



System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.ArtistEN> Search (string p_filter);
}
}
