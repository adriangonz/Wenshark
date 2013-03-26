
using System;
using WenSharkGenNHibernate.EN.Default_;

namespace WenSharkGenNHibernate.CAD.Default_
{
public partial interface IOAuthProviderCAD
{
OAuthProviderEN ReadOIDDefault (int id);

int New_ (OAuthProviderEN oAuthProvider);

void Destroy (int id);


void Modify (OAuthProviderEN oAuthProvider);


OAuthProviderEN GetByID (int id);


System.Collections.Generic.IList<OAuthProviderEN> GetAll (int first, int size);
}
}
