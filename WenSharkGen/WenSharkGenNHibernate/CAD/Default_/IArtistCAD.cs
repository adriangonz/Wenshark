
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IArtistCAD
{
ArtistEN ReadOIDDefault (int id);

int New_ (ArtistEN artist);


void Destroy (int id);


void Modify (ArtistEN artist);
}
}
