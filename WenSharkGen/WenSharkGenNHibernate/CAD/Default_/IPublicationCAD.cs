
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IPublicationCAD
{
PublicationEN ReadOIDDefault (int id);

int New_ (PublicationEN publication);

void Destroy (int id);


void Modify (PublicationEN publication);
}
}
