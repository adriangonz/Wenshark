
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IAlbumCAD
{
AlbumEN ReadOIDDefault (int id);

int New_ (AlbumEN album);


void Destroy (int id);


void Modify (AlbumEN album);
}
}
