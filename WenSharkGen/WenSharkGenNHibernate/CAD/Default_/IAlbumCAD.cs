
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IAlbumCAD
{
AlbumEN ReadOIDDefault (int id);

int New_ (AlbumEN album);

AlbumEN ReadOID (int id);



void Destroy (int id);


void Modify (AlbumEN album);




System.Collections.Generic.IList<WenSharkGenNHibernate.EN.Default_.AlbumEN> Search (string p_filter);
}
}
