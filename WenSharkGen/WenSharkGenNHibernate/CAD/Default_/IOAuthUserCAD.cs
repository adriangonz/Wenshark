
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IOAuthUserCAD
{
OAuthUserEN ReadOIDDefault (int id);

int New_ (OAuthUserEN oAuthUser);

void Modify (OAuthUserEN oAuthUser);


void Destroy (int id);
}
}
