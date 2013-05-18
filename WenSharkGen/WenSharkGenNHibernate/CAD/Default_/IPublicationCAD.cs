
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



void SetItem (int p_publication, int p_item);

void SetUser (int p_publication, int p_user);

void Unrelate_Item (int p_publication, int p_item);

void Unrelate_User (int p_publication, int p_user);
}
}
